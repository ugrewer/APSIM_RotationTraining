What to do when it doesn't work
===============================

While the rotation manager component is simple in concept, the details of its operation are voluminous and complex. Particularly when it doesn't work. This section steps through the operation of the component, showing how to examine the state of the system at check points and highlighting common mistakes. 


The normal sequence of events
-----------------------------

By itself, the rotation manager's operation is very simple: it determines

a) whether it can do something,
b) if so - does it, and 
c) tries a) again. 

If there is nothing to do, then todays management is over. It has no concept of what's happening to the system when it does something, only that the set of rules that describe what it can do will likely change after the transition is made. 

.. figure:: _static/diagnostics - Daily Operation.png
   :alt: Daily operation of the rotation manager
   :width: 100%

   The daily operation of the rotation manager

These rules have an ephemeral nature - they change value depending on other states of the system, which makes debugging hard: by the end of the day (when the report is happening), the value of these rules may have changed from what they were in the management phase of the days processing. Indeed, by the end of the day, the system may have changed state, only to remain in the beginning state at the end of the day. The potential for confusion is high!

.. figure:: _static/diagnostics - Simple bubble chart.png
   :alt: A state transition network with an invisible state
   :width: 100%

   A state transition network with an ephemeral state - Irrigation. 

So, diagnosis of the rotation manager's behavior will likely require examination of the simulation's activity as it happens, not end-of-day reporting. 

What's in the summary file?
---------------------------

As usual, the summary file - the simulation's diary of "interesting things", is the first point of call when trying to understand the simulations progress. Did it commence? Did it sow a crop? Did it harvest a crop? Did it harvest the right crop?

.. figure:: _static/diagnostics - simple summary.png
   :alt: A portion of a summary file 
   :width: 100%

   A summary file showing a linear sequence of activity


If the summary file is empty (apart from initialisation messages), did you set the initial state correctly? If it starts in a state that doesn't exist, it will have nowhere to go and do nothing.

Transition reporting
--------------------

Having several "views" of the simulation's progress helps to understand its behavior. We use (end-of) daily reports to understand processes like water movement and plant growth, reports at harvest for crop summaries, and annual reports for (eg.) economics. The transition report - made when the rotation manager changes state - shows the progression of the simulation through the state network and can highlight problems with the network.

.. figure:: _static/diagnostics - transition report.png
   :alt: A transition report
   :width: 100%

   A transition report showing the state of the system immediately before each action is undertaken.
   

Check the duration of phases for inordinately long periods that point to a rule being too strict.

Verbose mode
------------

There is a "verbose mode" in the rotation manager that will write a lot of information to the summary file. 

.. figure:: _static/diagnostics - verbose mode.png
   :alt: The verbose button
   :width: 100%

   The "verbose mode" radiobutton in the rotation manager.

Every day, the rotation manager will write the value result of every rule.

.. figure:: _static/diagnostics - verbose summary.png
   :alt: A verbose summary file
   :width: 100%

   Extra information on rule evaluations echoed to the summary file.
   
Diagnosing '000s of rule evaluations in a text format is cumbersome - though it's a simple matter to search for text (<ctrl>F) if you know a keyword.

Rugplots 
--------

A rugplot component is a powerful way to examine the rotation manager's activity - it can be added to the rotation manager (right click, "Add Model" / Management / RotationRugplot ), and  captures all of the rule evaluations and actions taken during the simulation, presenting them as a vertical strip with time on the Y axis, and blocks of colour representing the systems state. Clicking on the strip shows the rule evaluations of that day in the lower right corner. 

.. figure:: _static/diagnostics - rugplot.png
   :alt: A rugplot
   :width: 100%

   A rugplot showing the rule evaluations for 1 April. Navigate by clicking on the rug, or the (up/down) buttons next to the selected date.

Note that the rule evaluations for more than one target may be present: the list represents the evaluations (1st column), targets (states, or nodes of the network) and tests (rules) that the component evaluated each day. In this instance, the state at the beginning of the day is "prepForPasture", the first rule evaluation (1st row) indicates it can sow the pasture: the 1st column is the rule value (1/green) for each target ("Pasture"). After it makes the transition (the 2nd row), it evaluates the rules leading from the current state (now from "Pasture" to "prepForCrop"), finds it has a 0/red result, and can do no more.

The data for these rugplots is stored in the DataStore of the simulation - it can get quite large so turn it off if you're not using it. 

Finer detail
------------

Compound rules in manager logic work against detailed diagnosis: they make life simpler (and faster) by hiding a lot of unnecessary detail. But... It only takes one subrule to misbehave and we're unable to find which of the subrules that is. These rules are usually implemented as `getter variables <https://en.wikipedia.org/wiki/Property_(programming)>`_ which are exposed (ie. public variables) to all components in the simulation.

.. figure:: _static/diagnostics - cansow.png
   :alt: Some manager code
   :width: 100%

   A "getter" that implements some logic to test whether the crop can be sown. The highlighted code is a compound test.

The 4 tests in this compound rule can be split apart and the rotation manager modified to use these individual rules for the purpose of display in a rugplot:

.. figure:: _static/diagnostics - subrule implementation.png
   :alt: subrule implementaition
   :width: 100%

   Individual rules created for each term of the compound rule

.. figure:: _static/diagnostics - subrule use.png
   :alt: subrule use
   :width: 100%

   Using the individual rules in the rotation manager

.. figure:: _static/diagnostics - getter results.png
   :alt: rule evaluations when sowing an oats crop
   :width: 100%

   Rule evaluations from the 4 individual rules

There is a tradeoff made here - switching context between components is a time-expensive operation for the simulation and it is noticeably slower (with larger storage as well). Yet there is nothing to stop the user switching back to the original method once problems have been resolved.

