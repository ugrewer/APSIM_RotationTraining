Flexible Cropping Sequences
========================================
The previous tutorial section introduced how to represent predetermined crop rotations in APSIM.
However, whenever cropping system research aims to simulate likely farmer behaviour in a forward looking manner,
the simulation of a fixed, predetermined crop rotation is hardly realistic.
Instead, farm managers often have a couple of typical cropping strategies, between which they will shift quite flexibly based on changing context conditions.
For example, in south-east Queensland, farmers can flexibly change between summer- and winter-dominant cropping patterns based on seasonally changing water availability and soil moisture storage from preceding months.
Another driver of rapid shifts in crop choice can be pest outbreaks (such as the transition out of maize following the introduction and spread of fall armyworm in Australia) 
or pronounced and sudden changes in price incentives (for example, as a consequence to the 30% tariff imposed on chickpea and lentil imports into India in 2017).

In this section, we will explore how to define such flexible cropping sequences that dynamically determine crop choice based on external conditions.


Case Study Context
----------------------------------------
This tutorial focusses on representing a flexible cropping strategy within the exemplary agro-ecological context of the *Darling Downs* growing region.
This production region in South-East Queensland (Australia) is characterised by two major crop growing periods, summer and winter.
The region is characterised by a summer-dominant rainfall pattern and most farmers correspondingly practice a primarily summer-dominant cropping strategy.
However, over the last two decades, the planted area of winter crops has steadily increased.
Many farmers have adopted highly climate-responsive, opportunistic cropping strategies, 
implementing a high cropping intensity whenever adequate water resources are available, regardless of the season.
Evidence of this flexible alternation between summer- and winter-dominant cropping is visible even in aggregate government statistics on the seasonal planted area across Queensland (`ABARES, 2024`_).

In the following, we will aim to represent such an opportunistic cropping strategy within the ``RotationManager`` of APSIM.
It is important to remember, that this scenario serves as an illustrative example only.
Our core focus is to demonstrate a workflow in APSIM that can readily be transferred to other agro-ecological settings and applications.
For example, in production regions where a wheat-dominant crop rotation is largely predetermined, such as in parts of Western Australia, 
there is little value in configuring a ``RotationManager`` that represents flexible crop choices.

In such contexts, the design logic presented in this tutorial can instead be applied to other dynamic aspects of the local cropping system, for example, 
simulating flexible soil management decisions rather than flexible crop choices. 
This could include, for instance, the occasional application of soil amendments such as lime when selected soil properties fall below specified thresholds.


Cropping Scenario
----------------------------------------
As flexible cropping scenario, we consider a hypothetical broadacre farmer in the Darling Downs region
that is generally willing to grow both summer and winter crops, depending on seasonal conditions.
As summer crops, the farmer commonly grows sorghum and mungbean, 
while as winter crops, wheat and chickpea are readily available options.

To keep some realism, but avoid some of the complicated detail that will be involved in simulating a real case study farm,
we will consider here that the farmer determines the crop choice on only two subsequent decisions:

- Absolute water availability
    During the sowing window, a threshold for water availability determines if a crop is sown at all or if the field is left fallow.
    This is exactly similar to the decision logic presented in the previous tutorial section on basic crop rotations.

- Crop sequence: Disease pressure and nitrogen management
    The continuous cropping of cereals or legumes can lead to increased disease pressure and suboptimal nitrogen management.
    Here we will implement the following simple rule: If the previous two cultivated crops were cereals,
    the next crop must be a legume. In all other cases, the next crop must be a cereal.
    Thereby, we will simply consider the last cultivated crops, regardless of whether the plot has intermittently been left fallow.

The above rules have been chosen on purpose for this tutorial, 
as they demonstrate how to implement conditions that depend on both 
(i) the progression of the simulation (i.e., the previous crops grown), and 
(ii) the prevailing environmental conditions (i.e., water availability).
While the specific rules that you will require for your own study cases are likely to differ,
many cases can be represented by the general logic presented here.


Crop Sequence Diagram
----------------------------------------
The first step in implementing the above flexible cropping strategy 
is to represent the desired crop sequences within the ``RotationManager``.
In other words, we have to generate a suitable bubble chart.

As a starting point for this tutorial section, please utilise the following *APSIMX file*:
`CropRotation_flexible_start.apsimx <_APSIM_code/CropRotation_flexible_start/CropRotation_flexible_start.apsimx>`_.
Using an existing *APSIMX file* as the starting point, allows to skip over some aspects already covered in previous tutorial sections
and instead focus on the new aspects relevant for flexible cropping sequences. If you compare the simulation tree in the provided *APSIMX file* with the one shown in the previous tutorial section on basic crop rotations (`CropRotation_basic.apsimx <_APSIM_code/CropRotation_basic/CropRotation_basic.apsimx>`_),
you will notice that there are a number of modifications and updates already done:

- Crop models for a total of four crops are included in the simulation tree (sorghum, mungbean, wheat, chickpea).
- Draft *manager* scripts for sowing and harvesting have been created for each crop (as simple adaptations of the previously used *manager* scripts in *CropRotation_basic.apsimx* and without any thorough update to our new simulation scenario).
- Fertiliser *manager* scripts have been added for each crop.
- Parameters for the soil-crop interactions, specifically the Plant Available Water Capacity (PAWC), have been added for the new crops (under the *Soil node* ``HRS`` -> ``Physical``). 
- The data reporting notes (both daily reports and at harvest) have been updated to account for the new crops.
- The graphing nodes have been updated to account for the new crops.

All these changes require skills and procedures that we have already covered in previous tutorial sections.
Therefore, to keep the tutorial focused on the new aspects and save you from some repetitive tasks,
we have included these scripts and updates as starting point within the provided *APSIMX file*.

Currently, the ``RotationManager`` canvas is empty.
Please take a moment to try and represent the above defined cropping sequence via a suitable bubble chart.
If you work on this solution with a colleague, 
please note that there are many possible ways to represent the desired crop sequence within the ``RotationManager`` canvas.
At this point, it is useful for you to first try to come up with your own solution,
as this will assist you in developing a better conceptual understanding of representing cropping sequences within the ``RotationManager``.
Once you have tried to come up with your own solution, please proceed by unhiding the suggested solutions here below.

.. raw:: html

   <details>
   <summary><b>Show/Hide Solution: Crop Sequence Diagram</b></summary>

   <p>The most concise way of representing the cropping sequence (that we could think of) is shown below.
   It minimises the number of crop nodes and transitions (i.e., arcs) required to represent the system.
   Thereby, it is important to not that the <b>"Fallow"</b> node is used to represent both:
   (i) summer as well as winter fallows that last an entire season, and
   (ii) short break periods in autumn and spring that occur between the cultivation of two directly adjacent summer and winter crops.
   </p>

   <img src="_static/APSIMscreenshot_BubbleChart_flexible.png" alt="BubbleChart_flexible" width="80%">

   <p>However, there are many different ways in which one can conceptualise and setup the bubble chart.
   Here below, we show another commonly used alternative, where a separate node for the off-season periods in autumn and spring is created.
   While such nodes are not strictly necessary for representing the system in APSIM, 
   they allow to keep the summer and winter seasons more neatly separated within the bubble chart.
   On the downside, this solution requires slightly more nodes and transitions (i.e., arcs) to represent the system.
   </p>

   <img src="_static/APSIMscreenshot_BubbleChart_flexible_withBreakPeriod.png" alt="BubbleChart_flexible_withBreakPeriod" width="80%">

   <p>
    It is important to note that, while an equivalent APSIM simulation can be generated with different bubble chart designs,
    they may often require different manager scripts.
    For the remainder of the tutorial, we will proceed with the first solution shown above.
    We also recommend that you continue working with the same setup,
    as this will make it easier to follow along.
    </p>
    At this stage, we can also add descriptive names to the transitions within the bubble chart.
    When referencing the name of specific transitions, a clear and unambiguous naming convention will avoid any confusion later on.
   </p>

   <img src="_static/APSIMscreenshot_BubbleChart_flexible_withTransitionNames.png" alt="APSIMscreenshot_BubbleChart_flexible_withTransitionNames" width="80%">

   </details>

.. raw:: html

   <br><br>


Transitioning between Plot States
----------------------------------------
The next step in the ``RotationManager`` is to specify:

- the conditions that trigger each transition (i.e., arc) between nodes, and
- the actions to be executed whenever a given transition is taken.

For this, we again have to link to *manager* scripts within the ``Paddock`` node of the simulation tree by calling them in the ``RotationManager``.
The overall setup of transition conditions and transition actions is quite trivial,
as it is identical to the procedures presented in the previous tutorial section on basic crop rotations.
Please complete the conditions and action fields in the ``RotationManager``,
so that all *"Enter"* *arcs* have the condition *"CanSow"* and the action *"SowCrop()"*.
Instead, all *"Exit"* *arcs* should have the condition *"CanHarvest"* and the action *"HarvestCrop()"*.
Please make sure to always reference the *manager* scripts of the intended crop.
For example, the completed box of “Conditions” and “Actions” for wheat (i.e., the two arcs *"Enter WH"* and *"Exit WH"*) should look like the following:

.. figure:: _static/APSIMscreenshot_TransitionActionConditions_EnterWH.png
   :alt: TransitionActionConditions_EnterWH
   :width: 80%

.. figure:: _static/APSIMscreenshot_TransitionActionConditions_ExitWH.png
   :alt: TransitionActionConditions_ExitWH
   :width: 80%

Now that the overall structure of nodes and transition rules of the cropping sequence has been defined in the ``RotationManager``,
the next step is to update these *manager* scripts that are called upon by the transition rules.
This is the actual more tricky part.
As specified further above, our current *"manager"* scripts for sowing and harvesting were simply copied from the previous tutorial example.
The only updates that have been implemented so far (as part of the provided starting *APSIMX file*) was to update the parameter values within the *"manager"* scripts to consider reasonable values for each crop (sowing window, planting density, etc.).
Instead, we now need to modify the **C# code** of the *manager* scripts in a more substantial way
to represent the further above defined cropping sequencing rules.


Absolute water availability
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
As identified in the section *Cropping Scenario* above, 
the first decision rule to be implemented is that a crop is only sown if sufficient water is available during the sowing window, 
while otherwise the plot is left in fallow.
When you select an arbitrary of the current *manger* scripts for sowing and harvesting, e.g. ``SowHarvest_sorghum``,
you can identify that the existing script already contains a water availability check identical to the one presented in the previous tutorial section on basic crop rotations.
Accordingly, a crop is only sown if sufficient water resources are available during the sowing window.
No further changes are required from our side.
When you click through the various four sowing and harvest *manager* scripts,
you will notice that the sowing windows slightly vary by crop, 
while the water thresholds only differ between summer and winter crops.

Crop sequence: Disease pressure and nitrogen management
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
When now shifting to the issue of representing the crop sequence rules,
you will notice that no corresponding variables and drop-down menus are available in the current *manager* scripts for sowing and harvesting.
Accordingly, we will again need to make modifications to the **C# code** of *manager* scripts.
Arbitrarily, let us start with the ``SowHarvest_sorghum`` *manager* script and select the ``Script`` tab. 

In the previous cases, when we worked with **C# code** in APSIM *manager* scripts,
we predominantly accessed the namespaces, classes, and properties that are defined within the APSIM source code.
We accessed those APSIM components by copying using directives (i.e., namespace imports) from existing *manager* scripts and 
by exploring available object methods and properties through IntelliSense in the APSIM code editor.
In the current case, we will instead define our own variables to keep track of the previously grown crops.










Subheading
----------------------------------------

Sub-Subheading
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^




References
----------------------------------------

.. _ABARES, 2024:

ABARES. (2024). Snapshot of Australian Agriculture 2024. Australian Bureau of Agricultural and Resource Economics and Science (ABARES). https://doi.org/10.25814/473z-7187
