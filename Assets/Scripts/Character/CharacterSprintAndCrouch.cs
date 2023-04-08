using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprintAndCrouch : MonoBehaviour
{
  CharacterMovement characterMovement;
  Transform characterVisionTransform;
  float sprintSpeed = 10f;
  float walkSpeed = 5f;
  float crouchSpeed = 2f;
  float standingHeight = 2f;
  float crouchingHeight = 1f;
  bool isCharacterCrouching = false;

  void Start()
  {
    characterMovement = GetComponent<CharacterMovement>();
    characterVisionTransform = transform.GetChild(0);
  }

  void Update()
  {
    Sprint();
  }

  void Sprint()
  {
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      characterMovement.speed = sprintSpeed;
    }
  }
}
