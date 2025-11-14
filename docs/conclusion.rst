Conclusion
========================================
This tutorial covered various aspects of how to represent continous cropping within the cropping systems model APSIM.
The material focussed on providing guidance for the correct technical handling of the APSIM software.
In contrast, the tutorial does not cover how to conceptualise cropping systems research or how to analyse APSIM results once they have been generated.

The tutorial showed that APSIM simulations that cover a single cropping season from sowing to harvest, 
which constitutes the most classical entry point to crop modelling,
can be readily extended to simulate the same crop over multiple years.
A key decision in this context is whether to reset the simulation state at the beginning of each season, or to allow state variables (e.g., soil water and soil nutrients) to carry over from one season to the next.
Using this setup for long-term simulations with annual resetting, can e.g., be used for studies on climate change impacts.
Instead, using this setup for representing continuous cropping with carry-over impacts is very limiting.
It only allows to represent monocultures that are identically managed every year,
a scenario that will not be of practical relevance in many contexts.

A flexible and versatile approach to representing multi-year cropping sequences with carry-over impacts in APSIM is provided by the ``RotationManager``.
The tutorial centrally demonstrates how to setup a basic crop rotation 
as well as how to represent more complex cropping scenarios.
The ``RotationManager`` provides a graphical user interface which makes its operation quite intuitive.
Basic managment scenarios can be setup in APSIM by combining the ``RotationManager`` with existing manager scripts that are distributed via the ``Management Toolbox``.
However, to represent highly user-defined scenarios, the tutorial provided guidance and examples of how to modify existing C# manager scripts or write new ones from scratch.
While all above cases assumed that each *APSIMX file* only represents a single paddock, the tutorial then identified how multiple paddocks can be incorporated within a single simulation file.
Finally, we provided a set of useful routines for diagnosing and resolving errors, including strategies for identifying and correcting unexpected simulation behaviour.

