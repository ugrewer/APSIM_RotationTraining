using APSIM.Core;
using Models.Interfaces;
using APSIM.Shared.Utilities;
using Models.Utilities;
using Models.Soils;
using Models.PMF;
using Models.PMF.Organs;
using Models.Core;
using System;
using System.Linq;
using Models.Climate;
using APSIM.Numerics;

namespace Models
{
    [Serializable]
    public class Script : Model, IStructureDependency
    {
        [Link] private Clock Clock;
        [Link] private Summary Summary;
        [Link] private Soil Soil;
        [Link] private ISoilWater waterBalance;
        [Link] private CropSequenceEnforcer cropSequenceEnforcer;

        public IStructure Structure { private get; set; }

        [Separator("Script Configuration")]
        [Description("Crop to manage")]
        public IPlant Crop { get; set; }

        [Separator("Sowing Conditions")]
        [Description("Start of sowing window (d-mmm)")]
        public string StartDate { get; set; }
        [Description("End of sowing window (d-mmm)")]
        public string EndDate { get; set; }
        [Description("Minimum extractable soil water for sowing (mm)")]
        public double MinESW { get; set; }
        [Description("Accumulated rainfall required for sowing (mm)")]
        public double MinRain { get; set; }
        [Description("Duration of rainfall accumulation (d)")]
        public int RainDays { get; set; }
        [Tooltip("If enabled, and if sowing conditions are not met, the crop will be sown on the final day of the sowing window.")]
        [Description("Must sow (yes/no)")]
        public bool MustSow { get; set; }

        [Separator("Sowing Properties")]
        [Description("Cultivar to be sown")]
        [Display(Type = DisplayType.CultivarName)]
        public string CultivarName { get; set; }
        [Description("Sowing depth (mm)")]
        public double SowingDepth { get; set; }
        [Description("Row spacing (mm)")]
        public double RowSpacing { get; set; }
        [Description("Plant population (/m2)")]
        public double Population { get; set; }

        public Accumulator accumulatedRain { get; private set; }
        private bool afterInit = false;

        private string GetCropName()
        {
            return (Crop as Model).Name.ToLower();            
        }

        [EventSubscribe("StartOfSimulation")]
        private void OnSimulationCommencing(object sender, EventArgs e)
        {
            if (Crop == null)
                throw new Exception("Crop must not be null in rotations");
            accumulatedRain = new Accumulator(this, "[Weather].Rain", RainDays);
            Summary.WriteMessage(this, this.FullPath + " - Commence, crop=" + (Crop as Model).Name, MessageType.Diagnostic);
            afterInit = true;
            MonthlyHarvestedWt = 0;
        }
        
        [EventSubscribe("DoManagement")]
        private void DoManagement(object sender, EventArgs e)
        {
            accumulatedRain.Update();
        }

        // Test whether we can sow a crop today
        // +ve number - yes
        // 0          - no
        // -ve number - no, out of scope (planting window)
        [Units("0-1")]
        public int CanSow
        {
            get
            {
                if (!afterInit)
                    return 0;

                bool isPossibleToday = false;
                bool inWindow = DateUtilities.WithinDates(StartDate, Clock.Today, EndDate);
                bool endOfWindow = DateUtilities.DatesEqual(EndDate, Clock.Today);

                if (!Crop.IsAlive && inWindow &&
                    accumulatedRain.Sum > MinRain &&
                    MathUtilities.Sum(waterBalance.ESW) > MinESW)
                    isPossibleToday = true;

                string cropName = GetCropName();

                // Case 1: normal sowing
                if (isPossibleToday && cropSequenceEnforcer.AllowsSowing(cropName))
                {
                    Summary.WriteMessage(this,
                        $"Field history → PreviousCrop1={cropSequenceEnforcer.PreviousCrop1 ?? "null"}, PreviousCrop2={cropSequenceEnforcer.PreviousCrop2 ?? "null"}",
                        MessageType.Diagnostic);

                    return 1;
                }

                // Case 2: Must sow on last day of window
                if (!Crop.IsAlive && endOfWindow && MustSow &&
                    cropSequenceEnforcer.AllowsSowing(cropName))
                {
                    Summary.WriteMessage(this,
                        $"Field history (end window) → PreviousCrop1={cropSequenceEnforcer.PreviousCrop1 ?? "null"}, PreviousCrop2={cropSequenceEnforcer.PreviousCrop2 ?? "null"}",
                        MessageType.Diagnostic);

                    return 1;
                }

                // Out of window
                if (!Crop.IsAlive && !inWindow)
                    return -1;

                return 0;
            }
        }


        public void SowCrop()
        {
            Summary.WriteMessage(this, this.FullPath + " - sowing " + GetCropName(), MessageType.Diagnostic);
            Crop.Sow(population: Population, cultivar: CultivarName, depth: SowingDepth, rowSpacing: RowSpacing);
        }

        [Units("0-1")] 
        public int CanHarvest
        {
            get
            {
                if (!afterInit)
                    return (0);
                //Summary.WriteMessage(this, "canLeave:" + Crop.IsReadyForHarvesting, MessageType.Diagnostic);
                return Crop.IsReadyForHarvesting ? 1 : 0;
            }
        }


        public void HarvestCrop()
        {
            Summary.WriteMessage(this,
                this.FullPath + " - harvesting " + (Crop as Model).Name,
                MessageType.Diagnostic);

            MonthlyHarvestedWt = 
                (Structure.FindChild<IModel>("Grain", relativeTo: (INodeModel)Crop) 
                as ReproductiveOrgan).Wt;

            Crop.Harvest();
            Crop.EndCrop();

            string harvested = GetCropName();

            cropSequenceEnforcer.RecordHarvest(harvested);

            Summary.WriteMessage(this,
                $"Updated field history → PreviousCrop1={cropSequenceEnforcer.PreviousCrop1 ?? "null"}, PreviousCrop2={cropSequenceEnforcer.PreviousCrop2 ?? "null"}",
                MessageType.Diagnostic);
        }


        public double MonthlyHarvestedWt { get; set; }

        [EventSubscribe("StartOfMonth")]
        private void DoStartOfMonth(object sender, EventArgs e)
        {
            MonthlyHarvestedWt = 0;
        }
    }
}