.. image:: _static/Logo_APSIM_Initiative_03.png
   :alt: APSIM Initiative Logo
   :align: right
   :width: 200px

Continuous Cropping and Crop Rotations Using the APSIM Cropping Systems Model
===============================================

A Comprehensive Tutorial for APSIM Users
-----------------------------------------------------

The Agricultural Production Systems sIMulator (APSIM) is a biophysical, mass-balance model that mathematically represents crop growth and development, accounting for interactions among soil, plant, and atmosphere components [Holzworth et al. (2018)]_.
Cropping system models enable the simulation of continuous crop production on a given field, explicitly capturing the intertemporal, season-to-season dynamics of soil water and nutrient resources.
This tutorial is intended to guide users through the process of setting up and executing APSIM simulations for continuous cropping and crop rotation scenarios.
It focuses on the technical specification and correct code implementation of continuous cropping and rotational practices within APSIM and provides practical examples alongside step-by-step instructions.
This material does not offer any introduction to the theory of crop physiology, soil science, or soil-plant-atmosphere interactions. 
Furthermore, it does not serve as a general introduction the the APSIM model and is designed for users who have a basic understanding of APSIM and are familiar with using its General User Interface for basic crop simulation analyses.
For foundational and reference material, please consult the APSIM Next Generation documentation <https://apsimnextgeneration.netlify.app/>_ and the APSIM official website <https://www.apsim.info/>_.
This tutorial was developed for the APSIM Advanced Training Workshop held in conjunction with the 26th International Congress on Modelling and Simulation (MODSIM 2025) in Adelaide.

Continuous simulations using cropping system models are widely applied in agricultural research to explore long-term impacts of management practices on crop productivity, soil health, and resource use efficiency. 
Typical research questions include evaluating the sustainability of crop rotations, assessing the effects of climate variability or change on production systems, optimizing fertilizer and irrigation strategies, and estimating trade-offs between yield, environmental outcomes, and economic returns. 
These models are particularly valuable for simulating complex, multi-year scenarios that are difficult or impractical to study through field trials alone.

While APSIM offers robust capabilities for simulating complex cropping systems, the practical specification of continuous simulations—such as multi-year monocultures, crop rotations, and fallow periods—requires precise configuration of simulation components. This includes defining crop sequences, transition rules, and associated crop management strategies. Implementing such scenarios often involves coordinating multiple APSIM components, which can be technically challenging without guidance.
This tutorial introduces several approaches for representing continuous cropping in APSIM, including the use of the APSIM Rotation Manager, a graphical interface designed to simplify the specification of crop rotation sequences.



Acknowledgment of Country
-----------------------------------------------------
We acknowledges the First Nations of southern Queensland and their ongoing connection to Country, lands, and waterways. Further, we recognise Aboriginal and Torres Strait Islander peoples as the first educators and researchers of Australia. We pay our respect to Elders past, present, and emerging.

References
-----------------------------------------------------
[Holzworth et al. (2018)] Holzworth, D., Huth, N. I., Fainges, J., Brown, H., Zurcher, E., Cichota, R., Verrall, S., Herrmann, N. I., Zheng, B., & Snow, V. (2018). APSIM Next Generation: Overcoming challenges in modernising a farming systems model. Environmental Modelling & Software, 103, 43-51. https://doi.org/10.1016/j.envsoft.2018.02.002





Example: Basic Sphinx project for Read the Docs
===============================================

.. image:: https://readthedocs.org/projects/example-sphinx-basic/badge/?version=latest
    :target: https://example-sphinx-basic.readthedocs.io/en/latest/?badge=latest
    :alt: Documentation Status

.. This README.rst should work on Github and is also included in the Sphinx documentation project in docs/ - therefore, README.rst uses absolute links for most things so it renders properly on GitHub

This example shows a basic Sphinx project with Read the Docs. You're encouraged to view it to get inspiration and copy & paste from the files in the source code. If you are using Read the Docs for the first time, have a look at the official `Read the Docs Tutorial <https://docs.readthedocs.io/en/stable/tutorial/index.html>`__.

📚 `docs/ <https://github.com/readthedocs-examples/example-sphinx-basic/blob/main/docs/>`_
    A basic Sphinx project lives in ``docs/``. All the ``*.rst`` make up sections in the documentation.
⚙️ `.readthedocs.yaml <https://github.com/readthedocs-examples/example-sphinx-basic/blob/main/.readthedocs.yaml>`_
    Read the Docs Build configuration is stored in ``.readthedocs.yaml``.
⚙️ `docs/conf.py <https://github.com/readthedocs-examples/example-sphinx-basic/blob/main/docs/conf.py>`_
    Both the configuration and the folder layout follow Sphinx default conventions. You can change the `Sphinx configuration values <https://www.sphinx-doc.org/en/master/usage/configuration.html>`_ in this file
📍 `docs/requirements.txt <https://github.com/readthedocs-examples/example-sphinx-basic/blob/main/docs/requirements.txt>`_ and `docs/requirements.in <https://github.com/readthedocs-examples/example-sphinx-basic/blob/main/docs/requirements.in>`_
    Python dependencies are `pinned <https://docs.readthedocs.io/en/latest/guides/reproducible-builds.html>`_ (uses `pip-tools <https://pip-tools.readthedocs.io/en/latest/>`_). Make sure to add your Python dependencies to ``requirements.txt`` or if you choose `pip-tools <https://pip-tools.readthedocs.io/en/latest/>`_, edit ``docs/requirements.in`` and remember to run ``pip-compile docs/requirements.in``.
💡 `docs/api.rst <https://github.com/readthedocs-examples/example-sphinx-basic/blob/main/docs/api.rst>`_
    By adding our example Python module ``lumache`` in the reStructuredText directive ``:autosummary:``, Sphinx will automatically scan this module and generate API docs.
💡 `docs/usage.rst <https://github.com/readthedocs-examples/example-sphinx-basic/blob/main/docs/usage.rst>`_
    Sphinx can automatically extract API documentation directly from Python modules, using for instance the ``:autofunction:`` directive.
💡 `lumache.py <https://github.com/readthedocs-examples/example-sphinx-basic/blob/main/lumache.py>`_
    API docs are generated for this example Python module - they use *docstrings* directly in the documentation, notice how this shows up in the rendered documentation.
🔢 Git tags versioning
    We use a basic versioning mechanism by adding a git tag for every release of the example project. All releases and their version numbers are visible on `example-sphinx-basic.readthedocs.io <https://example-sphinx-basic.readthedocs.io/en/latest/>`__.
📜 `README.rst <https://github.com/readthedocs-examples/example-sphinx-basic/blob/main/README.rst>`_
    Contents of this ``README.rst`` are visible on Github and included on `the documentation index page <https://example-sphinx-basic.readthedocs.io/en/latest/>`_ (Don't Repeat Yourself).
⁉️ Questions / comments
    If you have questions related to this example, feel free to can ask them as a Github issue `here <https://github.com/readthedocs-examples/example-sphinx-basic/issues>`_.


Example Project usage
---------------------

This project has a standard Sphinx layout which is built by Read the Docs almost the same way that you would build it locally (on your own laptop!).

You can build and view this documentation project locally - we recommend that you activate `a local Python virtual environment first <https://packaging.python.org/en/latest/guides/installing-using-pip-and-virtual-environments/#creating-a-virtual-environment>`_:

.. code-block:: console

    # Install required Python dependencies (Sphinx etc.)
    pip install -r docs/requirements.txt

    # Enter the Sphinx project
    cd docs/
    
    # Run the raw sphinx-build command
    sphinx-build -M html . _build/


You can also build the documentation locally with ``make``:

.. code-block:: console

    # Enter the Sphinx project
    cd docs/
    
    # Build with make
    make html
    
    # Open with your preferred browser, pointing it to the documentation index page
    firefox _build/html/index.html


Using the example in your own project
-------------------------------------

If you are new to Read the Docs, you may want to refer to the `Read the Docs User documentation <https://docs.readthedocs.io/>`_.

If you are copying this code in order to get started with your documentation, you need to:

#. place your ``docs/`` folder alongside your Python project. If you are starting a new project, you can adapt the `pyproject.toml` example configuration.
#. use your existing project repository or create a new repository on Github, GitLab, Bitbucket or another host supported by Read the Docs
#. copy ``.readthedocs.yaml`` and the ``docs/`` folder into your project.
#. customize all the files, replacing example contents.
#. add your own Python project, replacing the ``pyproject.toml`` configuration and ``lumache.py`` module.
#. rebuild the documenation locally to see that it works.
#. *finally*, register your project on Read the Docs, see `Importing Your Documentation <https://docs.readthedocs.io/en/stable/intro/import-guide.html>`_.


Read the Docs tutorial
----------------------

To get started with Read the Docs, you may also refer to the `Read the Docs tutorial <https://docs.readthedocs.io/en/stable/tutorial/>`__.
It provides a full walk-through of building an example project similar to the one in this repository.
