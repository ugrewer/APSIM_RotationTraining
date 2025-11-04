
================
It doesn't work!"
================

While the rotation manager component is simple in concept, the details of its operation are voluminous and complex. Particularly when it doesn't work. This section steps through the operation of the component, showing check points and highlighting common mistakes. 


The normal sequence of events
-----------

By itself, the rotation manager's operation is very simple: it determines a) whether it can do something; b) if so - does it, and c) tries a) again. If there is nothing to do, then todays management is over. It has no concept of what's happening to the system when it does something, only that the set of rules that describe what it can do will change after the transition is made. 

These rules have an ephemeral nature - they change value depending on other states of the system, which makes debugging hard: by the end of the day (when the report is happening), the value of these rules may have changed from the management phase of the days processing.

<< one or two diagrams here  >>

What's in the summary file?
-----------

As usual, the summary file - the simulation's diary of "interesting things", is the first point of call when trying to understand the simulations progress. Did it commence? Did it sow a crop? Did it harvest a crop? Did it harvest the right crop?

If the summary file is empty (apart from initialisation messages), did you set the initial state correctly? If it starts in a state that doesn't exist, it will have nowhere to go and do nothing.

Transition reporting
-----------

Having several "views" of the simulation's progress helps to understand its behavior. We use (end-of) daily reports to understand processes like water movement and plant growth, reports at harvest for crop summaries, and annual reports for (eg.) economics. The transition report - made when the rotation manager changes state - shows the progression of the simulation through the state network and can highlight problems with the network.

<picture here>

Check the duration of phases for inordinately long periods that point to a rule being too strict.

Verbose mode
-----------

There is a "verbose mode" in the rotation manager that will write a lot of information to the summary file. 
<photo here>

Diagnosing '000s of rule evaluations in a text format is hard - yet it's a simple matter to search text quickly.

Rugplots 
-----------

 A rugplot model can be added to the rotation manager (right click, "add model" / Management / RotationRugplot ) that captures all of the rule evaluations and actions taken during the simulation, and presents them as a vertical strip with time on the Y axis. Clicking on the strip shows the rule evaluations of that day in the lower right corner. 

 < image here>

Note that the rule evaluations for more than one target may be present in any day: the list represents the targets, tests and actions that the component evaluated each day.



Compound rules in manager work against us: Show the process of busting up compound logic in a manager component into several manager “getters”


