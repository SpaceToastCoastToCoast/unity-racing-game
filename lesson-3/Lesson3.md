#Creating an AI-controlled opponent
We need to make our game cross the threshold between "driving simulator" and "racing game" by adding an opponent. Create another car in the same manner you created the player car. Make sure you give it a distinguishing feature such as a different color or body style so that players can tell it's an opponent.

###Computer-controlled players ("AI")
AI includes a broad range of topics, from simple pathfinding to complex, multifaceted behaviors. Through scripting, you can create complex behaviors, and Unity includes a prebuilt AI module with some simple navigation capabilities.

###Unity native AI
Through the UnityEngine.AI namespace, you can access Unity's native AI methods. The most basic and common of these is the NavMesh and NavMeshAgent.

#####NavMesh
Unity's navigation AI consists of two parts: the NavMesh, which is part of the scene, defines the area that AI characters can move within, and the NavMeshAgent, which is a component attached to the AI character that moves it within the NavMesh.

To generate a NavMesh, select all of your static scenery objects in the Hierarchy, and open the Navigation window (Window > Navigation). Make sure the checkbox is checked and click the Bake button, and Unity does some magic to calculate the navigable area. You can change variables like step height (the threshold below which a step or curb is considered to be climbable) and slope height (the angle above which sloped surfaces are considered too steep to climb) to change how the NavMesh is calculated. Once the NavMesh is baked, you should see a blue area covering all parts of your racetrack which the AI car is able to drive over. You should see holes in the NavMesh where impassable objects poke up through it and block navigation.

#####NavMeshAgent
The NavMesh does nothing without a NavMeshAgent to traverse it. Objects that should move around on the NavMesh need the NavMeshAgent component attached to move them around the level. Even so, the NavMeshAgent still needs to be told by a script where it is going within those bounds. The NavMeshAgent has an instance method called SetDestination(), which you pass a target position to and it will automatically seek the shortest way towards that point. NavMeshAgent also allows the use of a variable type NavMeshPath, which is a series of points it will navigate towards in sequence.

###User-defined AI
The native NavMesh's biggest shortcoming is that it cannot be used in combination with the physics engine. If you try to use both systems on the same object, they will compete for control of the object's motion and cause unexpected behavior. If you want to control AI characters with realistic physics, you must write your own scripts to determine their pathfinding behavior.

#####State machines
If you are considering writing your own AI, you might look at it in terms of a state machine. A state machine is a program that can be in any finite number of stable and discrete states based on both predefined conditions and on its previous state. In the context of AI, it consists of a list of predefined behaviors and the logic that controls switching between these behaviors, based on what behavior it was doing immediately before. An object can be in only one state at any given point in time. State machines form the basis of Unity's native animation controller.

A simple AI state machine might consist of only two states:

- Default state (usually idle or wandering aimlessly)
- Becoming aggressive when an opponent is in range (attacking, driving faster, etc)

You may already have written a state machine in the player's movement controls. A real car's gear shift is itself a type of state machine. For example, can a car be in both drive and reverse at the same time? It cannot--because these are finite and discrete states. Similarly, shifting the car from drive to neutral causes the engine to behave differently than shifting from drive to second or third gear.

If writing AI from scratch seems daunting, many Unity AI scripts are available here on GitHub as examples to study free of charge.

###Requirements
Write a script and/or use Unity components to make the opponent car follow the track and seek the finish line in the most efficient way it can do so. Make sure it achieves this without breaking the rules of the race (i.e. driving the wrong way and crossing the finish line in reverse, driving out of bounds, etc.)

###Stretch goals
- If you used the NavMesh to move your AI car, try switching it to the physics engine and writing your own AI for it.
- Place multiple opponents in a scene and consider how you can streamline the interactions amongst themselves.
- Complete any stretch goals from previous lessons.