using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprintAndCrouch : MonoBehaviour
{
  CharacterMovement characterMovement;
  Transform characterVisionTransform;
  float sprintSpeed = 8f;
  float walkSpeed = 4f;
  float crouchSpeed = 2f;
  float standingHeight = 2f;
  float crouchingHeight = 0.8f;
  bool isCharacterCrouching = false;

  void Start()
  {
    characterMovement = GetComponent<CharacterMovement>();
    characterVisionTransform = transform.GetChild(0);
  }

  void Update()
  {
    Sprint();
    Crouch();
  }

  void Sprint()
  {
    if (!isCharacterCrouching)
    {
      if (Input.GetKeyDown(KeyCode.LeftShift))
        characterMovement.characterSpeed = sprintSpeed;

      if (Input.GetKeyUp(KeyCode.LeftShift))
        characterMovement.characterSpeed = walkSpeed;
    }
  }

  void Crouch()
  {
    if (Input.GetKeyDown(KeyCode.Z))
    {
      if (isCharacterCrouching)
      {
        characterVisionTransform.localPosition = new Vector3(0f, standingHeight, 0f);
        characterMovement.characterSpeed = walkSpeed;
        isCharacterCrouching = false;
      }
      else
      {
        characterVisionTransform.localPosition = new Vector3(0f, crouchingHeight, 0f);
        characterMovement.characterSpeed = crouchSpeed;
        isCharacterCrouching = true;
      }
    }
  }
}
