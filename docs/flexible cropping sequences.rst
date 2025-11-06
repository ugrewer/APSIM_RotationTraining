Flexible Cropping Sequences
========================================
The previous tutorial section introduced how to represent predetermined crop rotations in APSIM.
However, whenever cropping system research aims to simulate likely farmer behaviour in a forward looking manner,
the simulation of a fixed, predetermined crop rotation is hardly realistic.
Instead, farm managers often have a couple of typical cropping strategies, between which they will shift quite flexibly based on changing context conditions.
For example, in south-east Queensland, farmers can flexibly change between summer- and winter-dominant cropping patterns based on seasonally changing water availability and soil moisture storage from preceding months.
Another driver of rapid shifts in crop choice can be pest outbreaks (such as the shift out of maize following the first appearance and spread of fall armyworm in Australia) 
or pronounced and sudden changes in price incentives (for example, as a consequence to the 30% tariff imposed on chickpea and lentil imports into India in 2017).

In this section, we will explore how to define such flexible cropping sequences that dynamically determine crop choice based on external conditions.


Case Study Context
----------------------------------------
This tutorial focusses on representing a flexible cropping strategy within the exemplary agro-ecological context of the *Darling Downs* growing region.
This production region in South-East Queensland (Australia) is characterised by two major crop growing periods, summer and winter.
The region is characterised by a summer-dominant rainfall pattern and most farmers correspondingly adopt predominantly a summer-dominant cropping strategy.
However, over the last two decades, the planted area of winter crops has steadily increased.
Many farmers have adopted highly climate-responsive, opportunistic cropping strategies, 
implementing high cropping intensity whenever adequate water resources are available, regardless of the season.
Evidence of this flexible alternation between summer- and winter-dominant cropping is visible even in aggregate government statistics on seasonal planted area across Queensland (`ABARES, 2024`_).

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
we will consider here that the farmer determines the crop choice on three subsequent decisions:

- Absolute water availability
    During the sowing window, a threshold for water availability determines if a crop is sown at all or if the field is left fallow.
    This is exactly similar to the decision logic presented in the previous tutorial section on basic crop rotations.

- Crop sequence (Disease pressure and nitrogen management)
    The continuous cropping of cereals or legumes can lead to increased disease pressure and suboptimal nitrogen management.
    Here we will implement the following simple rule: If the previous two cultivated crops were cereals,
    the next crop must be a legume. Instead, if the previous crop was a legume, the next crop must be a cereal.

- Time of season and relative water availability
    The above two rules will determine in most seasons which crop will be sown.
    However, the above still leaves flexibility in some seasons, where none of the above rules is binding 
    (e.g., when the past two crops were a legume followed by a cereal, the above rules do not determine which crop will be sown).
    In such cases, the farmer will sow a legume if sowing conditions are fulfilled early in the season,
    and otherwise sow cereals.

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

Currently, the ``RotationManager`` canvas is empty.
Please take a moment to try and represent the above defined cropping sequence via a suitable bubble chart.
If you work on this solution with a colleague, 
please note that there are many possible ways to represent the desired crop sequence within the ``RotationManager`` canvas.




.. raw:: html

   <details>
   <summary>Show Solution: Crop Sequence Diagram</summary>

   <p>The most concise way of representing the cropping sequence (that we could think of) is shown below.
   It avoids redundant crop nodes and minimises the number of required transitions.
   </p>

   <img src="docs/_static/APSIMscreenshot_AddedMungbeanModel.png" alt="Crop Sequence Solution" width="80%">

   <p>Additional explanation text can go here.</p>

   <img src="docs/_static/APSIMscreenshot_AddedMungbeanModel.png" alt="Crop Sequence Solution" width="80%">

   </details>



Subheading
----------------------------------------

Sub-Subheading
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^




References
----------------------------------------

.. _ABARES, 2024:

ABARES. (2024). Snapshot of Australian Agriculture 2024. Australian Bureau of Agricultural and Resource Economics and Science (ABARES). https://doi.org/10.25814/473z-7187
