.. image:: _static/ApsimNextGenerationLogo.png
   :alt: APSIM NextGen Logo
   :align: right
   :width: 170px

Continuous Cropping and Crop Rotations Using the APSIM Cropping Systems Model
===============================================


A Comprehensive Tutorial for APSIM Users
-----------------------------------------------------
The Agricultural Production Systems sIMulator (APSIM) is a biophysical, mass-balance model that mathematically represents crop growth and development, accounting for interactions among soil, plant, and atmosphere components (`Holzworth et al., 2018`_).
Cropping system models enable the simulation of continuous crop production on a given field, explicitly capturing the intertemporal, season-to-season dynamics of soil water and nutrient resources.
This tutorial is intended to guide users through the process of setting up and executing APSIM simulations for continuous cropping and crop rotation scenarios.
It focuses on the technical specification and correct code implementation within APSIM and provides practical examples alongside step-by-step instructions.
This material does not offer any introduction to the theory of crop physiology, soil science, or soil-plant-atmosphere interactions. 
Furthermore, it does not serve as a general introduction to the APSIM model and is designed for users who have a basic understanding of APSIM and are familiar with using its Graphical User Interface for basic crop simulation analyses.
For foundational and reference material as well as for installation instructions, please consult the `APSIM Next Generation documentation <https://apsimnextgeneration.netlify.app/>`_ and the `APSIM website <https://www.apsim.info/>`_.
This tutorial was developed for the APSIM Advanced Training Workshop held in conjunction with the 26th International Congress on Modelling and Simulation (MODSIM 2025) in Adelaide. The material was developed and tested with APSIM version *2025.10.7895*. Using substantially older versions of APSIM may prevent the included APSIM files from running or produce differing results.

The simulation of crop rotations with cropping system models aims to explore long-term impacts of management practices and the structure of cropping systems on crop productivity, soil characteristics, and resource use efficiency. 
Typical research questions include evaluating the sustainability of crop rotations, assessing the effects of climate variability or change on production systems, optimising fertilizer and irrigation strategies, and estimating trade-offs between yield, environmental outcomes, and economic returns. 
In this context, the APSIM model is particularly valuable for simulating complex, multi-year scenarios that are difficult or impractical to study through field trials or the analysis of survey data.

While APSIM offers robust capabilities for simulating complex cropping systems, the practical specification of continuous simulations—such as multi-year monocultures, crop rotations, and fallow periods—requires precise configuration of simulation components. 
This includes defining crop sequences, transition rules, and associated crop management strategies. 
Implementing such scenarios often involves coordinating multiple APSIM components, which can be technically challenging without guidance.
This tutorial introduces several approaches for representing continuous cropping in APSIM, including the use of the APSIM Rotation Manager, a graphical interface designed to simplify the specification of crop rotation sequences.


APSIM Acknowledgement
-----------------------------------------------------
The APSIM Initiative would appreciate an acknowledgement in your research paper if you or your team have utilised APSIM in its development. For ease, we suggest the following wording:
"Acknowledgment is made to the APSIM Initiative which takes responsibility for quality assurance and a structured innovation programme for APSIM's modelling software, which is provided free for research and development use (see apsim.info for details)."

Acknowledgment of Country
-----------------------------------------------------
We acknowledges the First Nations of southern Queensland and their ongoing connection to Country, lands, and waterways. Further, we recognise Aboriginal and Torres Strait Islander peoples as the first educators and researchers of Australia. We pay our respect to Elders past, present, and emerging.


References
-----------------------------------------------------

.. _Holzworth et al., 2018:

Holzworth, D., Huth, N. I., Fainges, J., Brown, H., Zurcher, E., Cichota, R., Verrall, S., Herrmann, N. I., Zheng, B., & Snow, V. (2018). *APSIM Next Generation: Overcoming challenges in modernising a farming systems model.* Environmental Modelling & Software, 103, 43–51. https://doi.org/10.1016/j.envsoft.2018.02.002
