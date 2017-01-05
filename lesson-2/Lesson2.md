#Layers, physics, and interacting with the level environment

###Layers
Layers provide both organization and grouping of objects, and information for the physics engine regarding what interactions between objects to track and calculate. 32 layers are available in Unity's editor, 8 of which are reserved as defaults. Creating and managing layers can greatly speed up your game and improve the accuracy of the physics engine. In some cases, you can halve the number of checks and calculations the physics engine does per frame, which can almost double your efficiency.

#####Creating layers
With an object selected in the Inspector view, you will see a dropdown menu for Layer in the top right corner of the Inspector. Select "Add Layer" and define layers for the Player, the Environment, the Items, and the Enemy. Place the car on the Player layer and place all scenery and level geometry on the Scenery layer.

#####Using the Physics Manager
From the Edit menu, open your Project Settings and open the Physics Manager. You should see a collection of checkboxes called a Layer Collision Matrix. Each layer has a vertical column determining what other layers it will perform collision calculations with. By default, all of these are checked.

Leave the first row (the Default layer) checked, so that every other layer can collide with it. Uncheck every other box.

Now, set up your collision matrix so that:

- Scenery does not collide with other scenery.
- Players can collide with scenery and with enemies.
- Enemies can collide with players and with scenery.
- Items can collide with players and with enemies.

You can also modify variables relating to how the physics simulation is run. (If you are setting your racer on the moon or on another planet, you could change the gravity settings here.)

###Building the track
Build a track using Unity primitives and colliders. The player's car should not be able to leave the area of the quad. Additionally, you should use primitives and colliders to shape the walls of your racetrack. As long as the end result is a continuous path incorporating smooth turns, it can be as simple or as complex as you want.

###Finish line
Your track must include a finish line that is clearly visible. Create a material that visually indicates this line and use it in the scene. Create a script that logs a message to the console when the player crosses the finish line. Trigger interactions and Collider class methods may help you here.

###Stretch goals
- A Quad creates a perfectly flat surface to drive on. Unity provides a means for creating ground that varies in elevation with the Terrain class. Incorporate this component into your track.
- Create some props that cars can collide with or knock out of the way as they drive. Place them on an appropriate layer and allow the physics engine to simulate their behavior when they are hit.
- Any stretch goals from Lesson 1 that you have not yet added to your project.