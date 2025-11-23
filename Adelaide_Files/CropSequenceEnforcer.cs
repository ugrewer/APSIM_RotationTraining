using System;
using Models.Core;

namespace Models
{
    [Serializable]
    public class CropSequenceEnforcer : Model
    {
        // Crop history
        private string previousCrop1 = null;   // Most recent harvested crop
        private string previousCrop2 = null;   // Second most recent harvested crop

        // Check if the proposed crop is allowed under given cropping sequence rules
        public bool AllowsSowing(string crop)
        {
            crop = crop.ToLower();

            bool isCereal  = crop == "sorghum" || crop == "wheat";
            bool isLegume  = crop == "mungbean" || crop == "chickpea";

            if (!isCereal && !isLegume)
                throw new Exception($"CropSequenceEnforcer: Unknown crop '{crop}'.");

            // No history yet → allow only cereals
            if (previousCrop1 == null || previousCrop2 == null)
                return isCereal;

            bool previous_1_wasCereal =
                previousCrop1 == "sorghum" || previousCrop1 == "wheat";

            bool previous_2_wasCereal =
                previousCrop2 == "sorghum" || previousCrop2 == "wheat";

            // Two cereals in a row → enforce a legume
            if (previous_1_wasCereal && previous_2_wasCereal)
                return isLegume;

            // Otherwise → enforce a cereal
            return isCereal;
        }

        // Called at harvest time to update crop sequence history
        public void RecordHarvest(string crop)
        {
            crop = crop.ToLower();

            bool isRotationCrop =
                crop == "sorghum" ||
                crop == "wheat"   ||
                crop == "mungbean"||
                crop == "chickpea";

            if (isRotationCrop)
            {
                previousCrop2 = previousCrop1;
                previousCrop1 = crop;
            }
        }

        // Public read-only accessors
        public string PreviousCrop1 => previousCrop1;
        public string PreviousCrop2 => previousCrop2;
    }
}
