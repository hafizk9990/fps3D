# First Person Shooter Game - Unity 3D

- **Directional Light:** We have used directional light to create the shadows in the game. Direction light covers the whole scene. Its rotation along x-axis is very significant in determining the direction of the shadows. The sun rises at 0 degrees along x axis and sets at 180 degrees. At 90 degrees x-axis value, it is at the top.

- **Character Controller:** We added our game character as a `Character Controller` object in Unity. By default a collider is already attached with it. We attached with it an empty Game Object and assigned to it the `Main Camera` object, so that the main camera's vision would be positioned directly where the player was positioned.

- **First Person Camera:** We added another `Camera` object to the game. We see all our weapons through this.
