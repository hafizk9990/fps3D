# FPS 3D Survival Game &mdash; Unity & C#

- **Directional Light:** We have used directional light to create the shadows in the game. Direction light covers the whole scene, unlike spot and other types of lights. Its rotation along the x-axis changes the light's angle is very significant in determining the direction of the shadows. The sun rises at 0 degrees along x axis and sets at 180 degrees. At 90 degrees y-axis value, it is at the top.

- **Character Controller:** We added our game character as a `Character Controller` object in Unity. By default a collider is already attached with it. We attached with it an empty Game Object and assigned to it the `Main Camera` object, so that the main camera's vision would be positioned directly where the player was positioned.

- **Main Camera & First Person (FP) Camera:** We added another `Camera` object to the game character object. We see all our weapons through this camera. It's `Cear Flags` value was set to `Depth Only` and the `Culling Mask` was set to the custom game layer, FirstPerson (doing this will make the FP camera see only the things that on this layer, not anything else). Also, the `Main Camera` object was configured to not even see the FirstPerson layer at which all the weapons are configured.

- **3D Models & Materials:** A 3D model requires `Material` in Unity. Game designers use Blender etc. to create these 3D things. I don't care.

- **Pre-Fabricated Objects ("Prefabs") & Object Reusability:** One of the main reaaons for creating prefabs is that we can reuse them without having to create the entire game object with all its components all over again. To make a prefab, we drag the game object into the `assets` section of the engine. The prefab in the `assets` is now the main source of truth, whereas the prefabs made via dragging and dropping this one in the `hierarcy` are merely the copies of the main prefab. If you make changes to the main, it will reflect in all copies. If you make changes to the copy, it will not reflect in the main by default, but you can make that happen by cliking on `overrides` in the copy prefab's inspector tab and selecting `Apply All`.

- **3D Axis System:** Pressing `A` key or `D` key moves our character along the x-axis (horizontal axis). Pressing the space bar to jump moves it along the y-axis. To move the character along z-axis (vertical axis), you need to press `W` or `S` keys. Overall, this is how we track the movement of our character: `Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // x, y and z axis`

-**Static Variable Access:** In C#, the const keyword is used to declare a constant value. When a variable is declared as const, it is implicitly static. This means that it belongs to the class rather than an instance of the class, and its value is fixed at compile-time and cannot be changed during runtime. That's why the compiler throws an error if you don't initialize the const members at compile time.

- **Local Space Vs. World Space:** Local coordinates are defined with respect to the object, whereas the global ones are with respect to the world our character is in.

-**Time.deltaTime:** This is the time between two frames. On a computer with more frames, this value is small and vice versa. If we don't multiply our position transformations with this value, the game will not become frame-rate independent. So, to make our chracter move at a constant speed across all devices, we use this variable.

-**Character Movement:** We obtained X and Y axis input from the keyboard. Then, we applied it to transform direction of our character's transform component. We also sped this process up and smoothed it out by making it frame-rate independent. Finally, we assigned the values to the `Move` method of our `Character Controller`. The whole process looks like this:

```
void moveCharacter()
{
    moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL_AXIS), 0f, Input.GetAxis(Axis.VERTICAL_AXIS));
    moveDirection = transform.TransformDirection(moveDirection);
    moveDirection = moveDirection * speed;
    moveDirection *= Time.deltaTime;
    applyGravity();
    myCharacter.Move(moveDirection);
  }
```

-**Applying Gravity:** For this, we saw if our character was on the ground or not. If no, we applied gravity to pull it down. Else, we checked for space bar input. If given, we changed the Y parameter of our character's transforom component's direction. The whole process looks like this.

```
void applyGravity()
{
if (myCharacter.isGrounded && Input.GetKeyDown(KeyCode.Space))
verticalVelocity = jumpForce;
else
verticalVelocity -= gravity \* Time.deltaTime;

      moveDirection.y = verticalVelocity * Time.deltaTime;

}
```

-**Hiding Mouse Cursor:** We used the following sytax to lock or unlock the cursor when the escape key was pressed by the user: `Cursor.lockState = CursorLockMode.Locked` to lock `Cursor.lockState = CursorLockMode.None` to unlock.

-**Inversion of X and Y in Mouse Axis System:** By convention, the Unity engine inverts values for mouse axis. Using the y-axis, we look sideways. Using x-axis, we look up and down.

-**Looking Around via Mouse:** Hello!
