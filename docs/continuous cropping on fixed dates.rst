Continuous Cropping on Fixed Dates
========================================
The previous tutorial section discussed the case of generating flexible cropping sequences to represent typical farmer behaviour 
that responds dynamically to changing seasonal conditions.
However, cropping system models are not always used for such forward-looking analyses.
Instead, they are also sometimes applied to represent past cropping histories.
This is, for example, the case when crop models are used to represent observed crop sequences from research farms or farmer-managed on-farm trials.
A classical application is the use of crop modelling to temporally interpolate the values of state variables (such as soil water or soil nitrogen) between observed data points, 
thereby helping to uncover the likely causes of end-of-season outcomes in such experiments (e.g., grain yield or soil carbon levels).
A more recent example is the use of crop models in developing so called *Digital Twins*, 
which aim to replicate observed cropping systems in a detailed, mechanistic manner based on data-rich environments.

These use cases can readily be simulated with the previously presented ``RotationManager`` *model*.
However, as crop sequences are recorded via observed datasets and are thus predetermined,
none of the flexibility and rule-based logic of the ``RotationManager`` is needed.
Indeed, the ``RotationManager`` can make the specification of a cropping sequence with predetermined, fixed dates unnecessarily complicated.

This section will introduce how to use the ``Operations`` *model* to conduct management activities on fixed dates.
As a case study, we will focus on generating the same cropping system simulation that had organically emerged from the imposed rules on minimum soil moisture, minimum rainfall,
and specific crop sequencing rules as defined in the previous tutorial section:
:doc:`Flexible Cropping Sequences</flexible cropping sequences>`.
Only now, we will pretend that all management activities would have been communicated to us based on records of on-farm observation.
Our task is to represent that information in APSIM.

Operations Model
----------------------------------------
As the starting point, let us use the final final *APSIMX file* from the previous tutorial section:  
`CropRotation_flexible_final.apsimx <CropRotation_flexible_final/CropRotation_flexible_final.apsimx>`_.
Please save the file under the new name “CropRotation_fixedDates.apsimx” and 
also rename the simulation node from “Continuous_Sorghum” to “CropRotation_fixedDates”.
Let us clean up the simulation by removing all *manager* scripts as they are no longer needed:
- CropSequenceEnforcer
- SowHarvest_sorghum
- SowHarvest_wheat
- SowHarvest_mungbean
- SowHarvest_chickpea
- Fert_sorghum
- Fert_wheat
- Fert_mungbean
- Fert_chickpea

Further, please also delete the ``RotationManager``.
Instead of controling management actions via the ``RotationManager`` and linked *manager* scripts 
that are triggered on certain events (such as based on: soil moisture thresholds, the day of sowing, or crop maturity),
we will explicitly define all actions fully deterministically on predefined dates.
For this, we need to add the ``Operations`` *model* via right-clicking on the ``Paddock`` *node*,
selecting ``Add model...`` and then double clicking on ``Operations`` 
(alternatively, you can drag-and-drop the ``Operations`` *model* onto the ``Paddock`` *node*).

As you will see, the ``Operations`` *model* provides you with an empty text file.
It is a fixed schedule manager.
Management operations are specified in a row-by-row manner.
Given that we want to reproduce the scenario from previously generated tutorial section 
:doc:`Flexible Cropping Sequences</flexible cropping sequences>`,
we are interested in specifying the following activities:

- Sowing crops
- Applying Urea fertiliser
- Harvesting crops

The first actions of interest happens on 1985-06-05 and consist of:

 - Sowing of Wheat
 - Application of Urea fertiliser at a rate of 100.0 kg/ha (at a depth of 100 mm)

Let us try to implement these two actions in the ``Operations`` *model* with the help of IntelliSense.
The first information that the ``Operations`` *model* expects is the date in the standard format "1985-06-05".
Subsequently, we need to reference the model that we want to conduct an action.
For sowing of wheat, this is the crop model "[Wheat]".
When adding a dot (.) after the reference to the crop model, we can explore the available methods and properties via IntelliSense.
Evidently, in this case, we are interested in the method "sow()".


Looking up Method Signatures
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
So far so good. However, IntelliSense does not tell us the method signature 
that identifies which arguments are required by "sow()".
To find this out, we have a couple of options:

- **Inspect existing manager scripts**: A common operation as "sow()" is implemented in many existing manager scripts.
For example, we could navigate back to the ``SowHarvest_wheat`` manager in our previous *APSIMX file*
`CropRotation_flexible_final.apsimx <CropRotation_flexible_final/CropRotation_flexible_final.apsimx>`_.
When we navigate to the ``Script`` tab, the method ``SowCrop()`` is defined as:

.. code-block:: csharp
   :caption: "SowCrop()" Method in the manager script "SowHarvest_wheat"
   :linenos:
   
        public void SowCrop()
        {
            Summary.WriteMessage(this, this.FullPath + " - sowing " + GetCropName(), MessageType.Diagnostic);
            Crop.Sow(population: Population, cultivar: CultivarName, depth: SowingDepth, rowSpacing: RowSpacing);
        }


Paddock.Fertiliser: 100.0 kg/ha of UreaN added at depth 100 layer 1


Subheading
----------------------------------------

Sub-Subheading
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^




References
----------------------------------------

.. _Brown et al., 2014:

Brown, H. E., Huth, N. I., Holzworth, D. P., Teixeira, E. I., Zyskowski, R. F., Hargreaves, J. N. G., & Moot, D. J. (2014). Plant Modelling Framework: Software for building and running crop models on the APSIM platform. Environmental Modelling & Software, 62, 385-398. https://doi.org/10.1016/j.envsoft.2014.09.005 

