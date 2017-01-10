#Winning, losing, and scene management

#####Data types to understand
- Scenes: Scenes are individual "levels" or screens in the game. Unity maintains an array of scenes which can be arranged through the Build Settings in the File menu. Scenes and their methods must be accessed in code through the UnityEngine.SceneManagement namespace, which you must explicitly include in your scripts in order to use.
- UI: User interface elements include things like text, buttons, and whole-screen images. You can build menus and HUD elements using the UI system in Unity. UI objects must be accessed in code through the UnityEngine.UI namespace.

Finally, our race must have a condition for victory and a condition for loss. Consider several scenarios that this game could be won or lost: is the winner the first across the finish line after a certain number of laps, or is it the last player alive? Is losing based on placing in the race, total time, or health remaining?

In this lesson you will configure a way for the player to know whether they have won or lost, and what the conditions are to trigger these states.

Your game must also have at least two scenes. One is the level you have been building throughout the tutorial, and the other one may be either a start menu or a second level to advance to.

###Requirements

- Indicate to the player through the UI whether they have won or lost.
- Reload the current scene if the player loses.
- If the player wins, advance them to another scene.