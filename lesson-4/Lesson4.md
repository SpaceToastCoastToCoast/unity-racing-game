#Weapons and powerups
What separates a kart racing game from a traditional racing game is weapons and powerups. Traditional racing games often aim for a more realistic feel which excludes outside distractions from the thrill of driving, but many include basic powerups like temporary speed boosts. Kart racers combine combat with racing, like with shell items in Mario Kart. Some, like Twisted Metal or Kirby Air Ride, include a health system which disqualifies racers once they take too much damage; others simply use weapons to slow opponents down. Which system you implement is up to you.

###Powerups
Creating a powerup is simple: decide on its behavior, and then create a GameObject representation of it in the scene which has its collider configured as a trigger. Apply the powerup's benefit to the collider that passes through it, and remove the powerup from the scene.

###Weapons
Weapons build upon the concept of a powerup. A weapon is picked up when touched, used a limited number of times before running out, and then removed from the racer's possession upon use. The specifics of the weapon's behavior are up to personal preference, but consider the two basic types of racing game weapons: projectiles and traps.

#####Projectiles
Weapons in racing games don't typically require the racer to manually aim them--that distracts from driving. Instead, the weapons automatically seek the nearest target and direct their attacks towards it. A projectile weapon must seek the nearest opponent (not yourself!) and cause some negative effect to it (reduce health, slow it down, knock it off course, etc.)

#####Traps
Traps, on the other hand, remain at a fixed location once set. When a racer comes in contact with a set trap, they take damage, lose speed, or temporarily lose control of their vehicle. (Think of banana peels in Mario Kart.) Traps can affect anyone, including the player who set them. Once the trap is triggered, it is removed from the scene. Traps may effect multiple players at once, if they are close enough to it (`Physics.OverlapSphere` may be useful for this!)

#####Wait--what's the difference between Trigger methods and Overlap<Shape>?
Triggers exist constantly in world space until they are explicitly destroyed. Overlap methods happen instantaneously, existing for one physics frame (1/60th of a second), and only when it is called from script. Triggers are more appropriate for when you want to wait for something to enter the trigger area (i.e., triggers are asynchronous). OverlapSphere is more appropriate for when you want to check if something is in range of an object at one specific known point in time (i.e., it is synchronous. For example, if you have a bomb that detonates on impact and you want to check what will take damage from the blast. You know it will explode during the Explode() function, but you don't care about anything being in its blast radius before or after the moment of detonation).

###Requirements
- One powerup.
- One weapon of either the projectile type or the trap type.
- A racer cannot hold onto more than one weapon at a time.
- Use Unity colliders and/or Physics class methods to check for what objects are colliding, what layer or tag these objects have, and what weapons should affect which racers.

###Stretch goals
- Implement more powerups, projectiles or traps.
- In most racing games, weapons are not used immediately, but held onto until the player decides to use them. Implement a script that listens for user input and uses a held weapon or powerup when a certain key is pressed.
- Complete any stretch goals from previous lessons.