# First-Person Shooter Survival Game &mdash; 3D Unity & C#

Down below, we discuss the game mechanics in Unity engine as well as the programming concepts in C# language that went into the development of this game.
<br><br><br>

## Part-01: Game Mechanics (Unity Engine)

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

- **Animations:** You can go to the `Window => Animation` tab of Unity to create a new `Animation`. This animation will be stored in the assets of our project. To create the animation now, we can set the frame value to indicate at what frame a specific animation will be completed, starting from the 0th frame. This determines in how much time, basically, the animation (the act of drawing axe or zooming in with the weapon etc.) will run completely.
  <br> <br>

- **Animator Controller:** Animations can be added to Animator Controller component. Animator Controllers are basically componens which are added to our objects. In this controller, we need to add a new "state" and attach with it our animation. We set the "entry point" in our animator controller to be the weapon drawing animation. Afterwards, we add a transition to it and add a new state, "idle". In this new state, some new animation has to be attached. Hence, inside a controller, we can create an entire "flow chart" that represents transition from one state to another, thereby actually transitioning from one animation to the other.
  <br> <br>

- **Animation Parameters (Triggers & Bools):** We also created some triggers in the `Parameters` sub-window. Afterwards, we attached this trigger as a conditional statement with our animation's "arrow" in the animator window. We can also set bool values, which when made true or false (via C# script) will execute the animation.
  <br><br>

- **Animation Exit Time & Transition Durations:** We also switched off the animation exit time (if we wanted to, for example, abrupt idle animation and aim starightaway). Finally, the animation transition times were set for around 0.1 seconds (100 ms) or 0.3 seconds (300 ms), depending upon how quickly we wanted to play those animations. For example, if you have an idle state and a run state, the transition duration would determine how long it takes for the character to move from the idle to the run animation.
  <br><br><br>

  ## Part-02: Game Programming (C# Language)

- **Keyboard Input:** We can use the following syntex to take keycoard input. `new Vector3(Input.GetAxis("HORIZONTAL"), 0f, input.GetAxis()"VERTICAL"));` This helps us get input from A, S, D and W keys as well as the arrow keys (alternatively).
  <br> <br>

- **3D Axis System (On Keyboard):** Pressing `A` key or `D` key moves our character along the x-axis (horizontal axis). Pressing the space bar to jump moves it along the y-axis. To move the character along z-axis (vertical axis), you need to press `W` or `S` keys. Overall, this is how we track the movement of our character: `Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal", 0, Input.GetAxis("Vertical")); // x, y and z axis`
  <br> <br>

- **Mouse Input:** We can get the mouse input like this: `new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));`
  <br><br>

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
      verticalVelocity -= gravity * Time.deltaTime;

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

- **AudioSource Component:** We dynamically set the `AudioClip` and `volume` values of the AudioSource component attached to our object from our C# script to play the sound when our character runs. We set. This is the complete code for it:

```
  if (isCharacterMoving())
  {
    accumulatedDistance += Time.deltaTime;

    if (accumulatedDistance >= stepDistance)
    {
      footstepSound.volume = volume;
      footstepSound.clip = footstepClips[Random.Range(0, footstepClips.Length)];
      footstepSound.Play();
      accumulatedDistance = 0f;
    }
  }
  else
    accumulatedDistance = 0f;
```

<br>

- **Raycast & RaycastHit:** A `Raycast` is an invisible line or a "ray" extended in space from the point of departure towards any arbitrary object with a collider on attached it. `RaycastHit`, on the other hand, contains the information about Raycast's collision. The RaycastHit object contains information such as the point of impact, the distance between the ray's origin and the point of impact, the normal vector of the surface that was hit, and the GameObject that was hit.

  ```
  if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
  {
    // Executes when the inifite raycast hits an object with a collider on it
  }
  ```

  In the code above, we are making a raycast extend forward from our currrent position.
  <br><br>

- **Nav Mesh & Walkable Objects:** We went to the navigation panel (Window => AI) and clicked on "bake" to generate the `NavMesh`. Before doing this, we went to the "Terrain" object in the mesh and marked it as "walkable." Others (trees, stones, rocks, etc.) were not marked as "Walkable" in the Engine. Now, Unity generates a `NavMesh` for us.
  <br><br>

- **Nav Mesh Agent:** Any object having Nav Mesh Agent attached to it as a component (our enemy has it) will be able to walk on the walkable area on our Nav Mesh. Nav Mesh agents have a rigid body attached with them. They also have a collider attached with them.

- **Game AI:** We include it via `UnityEngine.AI` namespace. It includes the definition of NavMeshAgent in it. We need to get the agent (enemy) and store it in this field.
  <br><br>

- **Moving Nav Mesh Agent (Enemy) on NavMesh (Terrain):** We set a random destination for our enemy (agent) using the folloing code

  ```
  void setNewRandomDestination()
  {
    float randomPatrolRadius = Random.Range(patrolRadiusMin, patrolRadiusMax);
    Vector3 randomDirection = Random.insideUnitSphere * randomPatrolRadius;
    randomDirection += transform.position;

    NavMeshHit myNavMeshHit;
    NavMesh.SamplePosition(randomDirection, out myNavMeshHit, randomPatrolRadius, -1);
    myNavMeshAgent.SetDestination(myNavMeshHit.position);
  }
  ```

  <br>
