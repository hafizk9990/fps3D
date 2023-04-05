# FPS 3D Survival Game &mdash; Unity & C#

- **Directional Light:** We have used directional light to create the shadows in the game. Direction light covers the whole scene, unlike spot and other types of lights. Its rotation along the x-axis changes the light's angle is very significant in determining the direction of the shadows. The sun rises at 0 degrees along x axis and sets at 180 degrees. At 90 degrees y-axis value, it is at the top.

- **Character Controller:** We added our game character as a `Character Controller` object in Unity. By default a collider is already attached with it. We attached with it an empty Game Object and assigned to it the `Main Camera` object, so that the main camera's vision would be positioned directly where the player was positioned.

- **Main Camera & First Person (FP) Camera:** We added another `Camera` object to the game character object. We see all our weapons through this camera. It's `Cear Flags` value was set to `Depth Only` and the `Culling Mask` was set to the custom game layer, FirstPerson (doing this will make the FP camera see only the things that on this layer, not anything else). Also, the `Main Camera` object was configured to not even see the FirstPerson layer at which all the weapons are configured.

- **3D Models & Materials:** A 3D model requires `Material` in Unity. Game designers use Blender etc. to create these 3D things. I don't care.

- **Pre-Fabricated Objects ("Prefabs") & Object Reusability:** One of the main reaaons for creating prefabs is that we can reuse them without having to create the entire game object with all its components all over again. To make a prefab, we drag the game object into the `assets` section of the engine. The prefab in the `assets` is now the main source of truth, whereas the prefabs made via dragging and dropping this one in the `hierarcy` are merely the copies of the main prefab. If you make changes to the main, it will reflect in all copies. If you make changes to the copy, it will not reflect in the main by default, but you can make that happen by cliking on `overrides` in the copy prefab's inspector tab and selecting `Apply All`.
