Flexible Cropping Sequences
========================================
The previous tutorial section introduced how to represent predetermined crop rotations in APSIM.
However, whenever cropping system research aims to simulate likely farmer behaviour in a forward looking manner,
the simulation of a fixed, predetermined crop rotation is hardly realistic.
Instead, farm managers often have a couple of typical cropping strategies, between which they will shift quite flexibly based on changing context conditions.
For example, in south-east Queensland, farmers can flexibly change between summer- and winter-dominant cropping patterns based on seasonally changing water availability and soil moisture storage from preceding months.
Another driver of rapid shifts in crop choice can be pest outbreaks (such the first appearance and diffusion of fall armyworm), 
or strong and rapid changes in price incentives (such as the introduction of a 30% tarif on chickpea and lentil imports into India in 2017).

In this section, we will explore how to define such flexible cropping sequences that dynamically determine crop choice based on external conditions.

Context
----------------------------------------
This tutorial focusses on representing a flexible cropping strategy within the exemplary agro-ecological context of the *Darling Downs* growing region.
This production region in South-East Queensland (Australia) is characterised by two major crop growing periods, summer and winter.
The region is characterised by a summer-dominant rainfall pattern and farmers correspondingly adopt predominantly a summer-dominant cropping strategy.
However, over the last two decades, the planted area of winter crops has steadily increased.
Many farmers have adopted highly climate-responsive, opportunistic cropping strategies that implement a high cropping intensity whenever sufficient water resources are available.
Evidence for this flexible shifting between summer- and winter-dominant cropping can even be found within aggregate government statistics of the seasonally planted area across Queensland (`ABARES, 2024`_).

In the following, we will aim to represent such an opportunistic cropping strategy within the ``RotationManager`` of APSIM.
It is important to remember, that the scenario presented herein serves as an illustrative example only.
Thereby, the core focus is to demonstrate a workflow in APSIM that can readily be transferred to other agro-ecological settings and applications.
For example, in production regions where a wheat-dominent crop rotation is rather pre-determined, such as in parts of Western Australia,
it may be of no interest to setup a ``RotationManager`` that represents flexible crop choices.
Instead, in such contexts, the same design logic presented in this tutorial could be applied to represent other dynamic aspects of the local cropping system,
such as a focus on simulating flexibly changing soil management decisions (as opposed to flexibly changing crops).
E.g., this could refer to the occassional application of soil amendments such as lime, whenever selected soil property variables reach specified thresholds.


Cropping Scenario
----------------------------------------








Subheading
----------------------------------------

Sub-Subheading
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^




References
----------------------------------------

.. _ABARES, 2024:

ABARES. (2024). Snapshot of Australian Agriculture 2024. Australian Bureau of Agricultural and Resource Economics and Science (ABARES). https://doi.org/10.25814/473z-7187
