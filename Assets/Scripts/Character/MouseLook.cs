using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
  [SerializeField] private Transform character;
  [SerializeField] private Transform characterVision;
  private CursorLockMode cursorIsLocked = CursorLockMode.Locked;
  private CursorLockMode cursorIsUnlocked = CursorLockMode.None;

  void Start()
  {
    Cursor.lockState = cursorIsLocked;
    Cursor.visible = false;
  }

  void Update()
  {
    toggleCursorLock();

    if (Cursor.lockState == cursorIsLocked)
      lookAround();
  }

  void toggleCursorLock()
  {
    if (Input.GetKeyDown(KeyCode.Tab))
    {
      if (Cursor.lockState == cursorIsLocked)
      {
        Cursor.lockState = cursorIsUnlocked;
        Cursor.visible = true;
      }
      else
      {
        Cursor.lockState = cursorIsLocked;
        Cursor.visible = false;
      }
    }
  }

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
    character.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f); // Move your entire body to look left and right, so that you run in that direction too
    characterVision.localRotation = Quaternion.Euler(lookAngles.x, 0f, 0f); // Move only your neck to move up and down
  }
}
