Continuous Cropping on Fixed Dates
========================================
The previous tutorial section discussed the case of generating flexible cropping sequences to represent typical farmer behaviour that responds rapidly to changing seasonal conditions.
However, cropping system models are not always used for such forward-looking analyses.
Instead, they are also sometimes applied to represent past cropping histories.
This is, for example, the case when crop models are used to represent observed crop sequences from research farms or farmer-managed on-farm trials.
A classical application is the use of crop modelling to temporally interpolate the values of state variables (such as soil water or soil nitrogen) between observed data points, 
thereby helping to uncover the likely causes of end-of-season outcomes (e.g., grain yield or soil carbon levels).
A more recent example is the use of crop models in developing so called *Digital Twins*, which aim to represent observed cropping systems in a detailed, mechanistic manner within data-rich environments.

These use cases can readily be simulated with the previously presented ``RotationManager`` *model*.
However, as crop sequences are recorded via observed datasets and are thus predetermined,
none of the flexibility and rule-based logic of the ``RotationManager`` is needed.
Indeed, the ``RotationManager`` can make the specification of a cropping sequence with predetermined, fixed dates unnecessarily complicated.

This section will instead introduce how to use the ``Operations`` *model* to conduct management activities upon fixed dates.


Subheading
----------------------------------------

Sub-Subheading
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^




References
----------------------------------------