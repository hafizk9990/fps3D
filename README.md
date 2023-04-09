# FPS 3D Survival Game &mdash; Unity & C#

- **Directional Light:** We have used directional light to create the shadows in the game. Direction light covers the whole scene, unlike spot and other types of lights. Its rotation along the x-axis changes the light's angle is very significant in determining the direction of the shadows. The sun rises at 0 degrees along x axis and sets at 180 degrees. At 90 degrees y-axis value, it is at the top.
  <br> <br>

- **Character Controller:** We added our game character as a `Character Controller` object in Unity. By default a collider is already attached with it. We attached with it an empty Game Object and assigned to it the `Main Camera` object, so that the main camera's vision would be positioned directly where the player was positioned.
  <br> <br>

- **Main Camera & First Person (FP) Camera:** We added another `Camera` object to the game character object. We see all our weapons through this camera. It's `Cear Flags` value was set to `Depth Only` and the `Culling Mask` was set to the custom game layer, FirstPerson (doing this will make the FP camera see only the things that on this layer, not anything else). Also, the `Main Camera` object was configured to not even see the FirstPerson layer at which all the weapons are configured.
  <br> <br>

- **3D Models & Materials:** A 3D model requires `Material` in Unity. Game designers use Blender etc. to create these 3D things. I don't care.
  <br> <br>

- **Pre-Fabricated Objects ("Prefabs") & Object Reusability:** One of the main reaaons for creating prefabs is that we can reuse them without having to create the entire game object with all its components all over again. To make a prefab, we drag the game object into the `assets` section of the engine. The prefab in the `assets` is now the main source of truth, whereas the prefabs made via dragging and dropping this one in the `hierarcy` are merely the copies of the main prefab. If you make changes to the main, it will reflect in all copies. If you make changes to the copy, it will not reflect in the main by default, but you can make that happen by cliking on `overrides` in the copy prefab's inspector tab and selecting `Apply All`.
  <br> <br>

- **3D Axis System:** Pressing `A` key or `D` key moves our character along the x-axis (horizontal axis). Pressing the space bar to jump moves it along the y-axis. To move the character along z-axis (vertical axis), you need to press `W` or `S` keys. Overall, this is how we track the movement of our character: `Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // x, y and z axis`
  <br> <br>

- **Static Variable Access:** In C#, the const keyword is used to declare a constant value. When a variable is declared as const, it is implicitly static. This means that it belongs to the class rather than an instance of the class, and its value is fixed at compile-time and cannot be changed during runtime. That's why the compiler throws an error if you don't initialize the const members at compile time.
  <br> <br>

- **Local Space Vs. World Space:** Local coordinates are defined with respect to the object, whereas the global ones are with respect to the world our character is in.
  <br> <br>

- **Time.deltaTime:** This is the time between two frames. On a computer with more frames, this value is small and vice versa. If we don't multiply our position transformations with this value, the game will not become frame-rate independent. So, to make our chracter move at a constant speed across all devices, we use this variable.
  <br> <br>

- **Character Movement:** We obtained X and Y axis input from the keyboard. Then, we applied it to transform direction of our character's transform component. We also sped this process up and smoothed it out by making it frame-rate independent. Finally, we assigned the values to the `Move` method of our `Character Controller`. The whole process looks like this:

```
// C#

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

<br>

- **Applying Gravity:** For this, we saw if our character was on the ground or not. If no, we applied gravity to pull it down. Else, we checked for space bar input. If given, we changed the Y parameter of our character's transforom component's direction. The whole process looks like this.

```
// C#

void applyGravity()
  {
    if (myCharacter.isGrounded && Input.GetKeyDown(KeyCode.Space))
      verticalVelocity = jumpForce;
    else
      verticalVelocity -= gravity \* Time.deltaTime;

    moveDirection.y = verticalVelocity * Time.deltaTime;
}
```

<br>

- **Hiding Mouse Cursor:** We used the following sytax to lock or unlock the cursor when the escape key was pressed by the user: `Cursor.lockState = CursorLockMode.Locked` to lock `Cursor.lockState = CursorLockMode.None` to unlock.
  <br> <br>

- **Inversion of X and Y in Mouse Axis System:** By convention, the Unity engine inverts values for mouse axis. Using the y-axis, we look sideways. Using x-axis, we look up and down.
  <br> <br>

- **Looking Around via Mouse:** We get input from the mouse for where the cursor is. This is done with inversion of axis (X for vertical, Y for horizontal). Then, we go ahead and transform X and Y of current looking angles to future looking angles (wher the mouse cursor is). We also clamp the up and down value to stop it from looking beyond that. The whole process looks like this:

```
// C#

  void lookAround()
  {
    // STEP-01: Checking where the mouse cursor is in the game every frame
    Vector2 inputMouseCoordinates = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

    // STEP-02: Up and down looking (x) and left and right looking (y)
    float sensitivity = 7f;
    Vector2 defaultLookLimits = new Vector2(-70f, 80f);
    Vector2 lookAngles = Vector2.zero;
    lookAngles.x += inputMouseCoordinates.x * sensitivity * -1; // Vertical
    lookAngles.y += inputMouseCoordinates.y * sensitivity; // Horizontal
    Mathf.Clamp(lookAngles.x, defaultLookLimits.x, defaultLookLimits.y);

    // STEP-03: Actually make the player look around
    character.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);
    // Move your entire body to look horizontally, so that you run in the direction of looking. So, we set character's own rotation.

    characterVision.localRotation = Quaternion.Euler(lookAngles.x, 0f, 0f);
    // Move only your neck to move up and down. That's why characterVision's rotation is being set.
  }
```

<br>

- **Movement Vs. Rotation:** Movement refers to changing the position / placement of an object in 3D space, whereas rotation is completely different, as the object stays exactly in the same place but moves / rotates around its axis. In terms of the X axis, for example, the movement would be horizontal, but rotating around the X axis would result in a change in the object's vertical orientation.
  <br> <br>

- **Running Vs. Looking Around:** We use movement for running, but we use rotation for looking around. Movement happens by transforming the direction of our character along x, y and z axis. Whereas to look, we have to change the rotation of our character along x, y and z axis. To move our object, we have to change its placement along some axis, using `transform.TransformDierection( ... )` 3D vector in C#. Whereas to rotate something along some axis, we have to set its `Quaternion.Euler( ... )` 3D vector in C#.
  <br><br>

- **Quaternion.Euler( .... ):** In computer graphics and 3D game development, a quaternion is a mathematical representation of a 3D rotation. Euler angles are a way to represent a rotation in three-dimensional space using three angles: pitch, yaw, and roll. Pitch is the rotation around the x-axis, which tilts the object up and down. Yaw is the rotation around the y-axis, which rotates the object left and right. Roll is the rotation around the z-axis, which twists the object. Together, these three angles define the orientation of an object in three-dimensional space. Euler angles can be used to represent rotations in many different contexts, including 3D graphics, robotics, and aerospace engineering. Notice that the focus here is on the "rotation", not the "movement" of the object in 3D. The Quaternion.Euler() method in Unity is used to create a quaternion from euler angles. It takes three float values representing the rotations around the x, y, and z axes respectively, and returns a Quaternion object. So, technically speaking, the input to Quaternion.Euler() is 3D (representing the three angles of rotation around three perpendicular axes), and the output is a 4D quaternion (representing the orientation of an object in 3D space, along with an additional scalar component).
  <br><br>

- **Bullet:** Text!
