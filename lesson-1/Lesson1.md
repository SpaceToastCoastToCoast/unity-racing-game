#Creating and controlling the player car

#####Data types to research and understand:
- Vector3: for data with an x, y and z component, such as movement, position, and scale.
- Quaternion: A non-human-readable datatype for storing rotation data. The Quaternion class has class methods for formatting this in a way you can understand.
- Rigidbody: The Rigidbody class methods allow you to control objects' physics properties and behavior.
- World Coordinates and Local Coordinates: World coordinates represent an object's absolute position in the game world. Local coordinates represent an object's position relative to another object.

###Environment setup
Create a quad, an empty GameObject, and a capsule. Name and tag the Gameobject so you and the game know it is a Player. Using the Transform components of these objects, make the quad lay flat and give it a large surface area, and shape the capsule roughly like the body of a car. Attach the capsule as a child of the Player object. Create four cylinders and attach these also to the Player object, and make them look like wheels attached to the car body.

###Controlling the car
Attach a script to the parent Player object that controls the car like a car behaves in real life. Requirements:

- Consider the gas and brake pedals of a car. One pedal moves the car forward relative to its front wheels, while the other brings the speed of the car towards zero. In other words, the gas pedal changes an object's velocity.
- Consider moving in reverse, and how a car moves at a different speed in reverse than it does in drive.
- Consider how the steering wheel does not *cause* horizontal movement, but rather rotates the car's forward direction relative to the position of the wheel.

Remember to move the whole car using Unity's physics engine and not by its Transform. Moving only the transform conflicts with the physics engine and causes unexpected behavior. Rigidbody class methods and documentation will help you shape the car's behavior. You can still access properties of the transform if you need to, but you should treat them as read-only.

###Camera setup
Using a script, make the camera follow the car and remain centered on its back bumper. Since the Camera does not interact with the world's physics, it is OK to move it using its Transform. Think about how you might position it so it is relative to the car.

###Stretch goals
- Observe how the gas and brake pedals work in reality: acceleration and deceleration are gradual processes, and the car does not stop moving when pressure is removed from the gas pedal. Reflect this behavior in the car's controller script.
- Replace the Capsule Colliders on your wheels with WheelColliders once your physics-based movement is working as intended. WheelColliders are extra sugar designed specifically for vehicles and include extra features for advanced physics simulation.
- Group the front and back wheels onto "axle" objects and show the front wheels turning when the car is steered.
- Add more primitives (cubes, cylinders, capsules, etc.) to refine the shape of your car and increase readability.
- Add sound effects and play them when input events are triggered in the script (engine roars, brake screeches, etc.)
- Add materials to the different parts of the car to change its color.