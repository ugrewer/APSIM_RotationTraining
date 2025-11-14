Conclusion
========================================
This tutorial covered various aspects of how to represent continous cropping within the cropping systems model APSIM.
The material focussed on providing guidance about the correct technical handling of the APSIM software.
Instead, the tutorial does neither cover how to conceptualise cropping systems research nor how to analyse APSIM results once they are available.

The tutorial showed that APSIM simulation files that cover a single cropping season from sowing to harvest, 
which constitute the most classical entry point to crop modelling,
can be easily extended to simulate the same crop continuously over multiple years.
Thereby, a core choice is whether to reset the simulation state prior to each season start or 
to consider carry-over impacts from season to season, e.g., of soil water and soil nutrient state variables.
Using this setup for long-term simulations with annual resetting, can e.g., be used for studies on climate change impacts.
Instead, using this setup for representing continuous cropping with carry-over impacts is very limiting.
It only allows to represent monocultures that are identically managed every year,
a situation that will not be of practical relevance in many contexts.

A flexible and versatile way to represent multi-year cropping sequences with carry-over impacts in APSIM is the ``RotationManager``.
Our tutorial centrally focuses on showing how to first setup a basic ``RotationManager``
as well as how to use it for representing more complex cropping scenarios.
The ``RotationManager`` provides a graphical user interface which makes its operation quite intuitive.
Basic managment scenarios can be setup in APSIM by combining the ``RotationManager`` with existing manager scripts that are distributed via the ``Management Toolbox`` in APSIM.
However, to represent highly user-driven scenarios, the tutorial provided guidance and examples of how to modify existing C# manager scripts or write new ones from scratch.
While all of the above assumed that each *APSIMX file* only represents a single paddock, the tutorial then identified how multiple paddocks can be considered.
Finally, we provided some useful routines of how to diagnose errors and correct simulations when one encounters errors or unexpected simulation results.

