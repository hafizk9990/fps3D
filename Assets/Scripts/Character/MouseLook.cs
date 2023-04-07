using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
  [SerializeField]
  private Transform character;
  [SerializeField]
  private Transform characterVision;
  [SerializeField]
  private bool canUnlock = true;
  [SerializeField]
  private bool invert;
  [SerializeField]
  private float sensitivity = 5f;
  [SerializeField]
  private float rollSpeed = 3f;
  [SerializeField]
  private int smoothSteps = 10;
  [SerializeField]
  private float rollAngle = 10f;
  [SerializeField]
  private float smoothWeight = 0.4f;
  private Vector2 lookAngles;
  private Vector2 currentMouseLook;
  private Vector2 smoothMove;
  private Vector2 defaultLookLimits = new Vector2(-70f, 80f);
  private float currentRollAngle;
  private int lastLookFrame;
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
    currentMouseLook = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));
    lookAngles.x = currentMouseLook.x * sensitivity;
    lookAngles.y = currentMouseLook.y * sensitivity;
    Mathf.Clamp(lookAngles.x, defaultLookLimits.x, defaultLookLimits.y);

    currentRollAngle = Mathf.Lerp(currentRollAngle, Input.GetAxisRaw(MouseAxis.MOUSE_X) * rollAngle, rollSpeed * Time.deltaTime);
  }
}
