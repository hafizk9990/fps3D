using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprintAndCrouch : MonoBehaviour
{
  CharacterMovement characterMovement;
  Transform characterVisionTransform;
  CharacterFootsteps myCharacterFootsteps;

  // CHECKS

  bool isCharacterCrouching = false;
  bool isCharacterLying = false;
  bool isCharacterStanding = true;

  // SPEEDS

  float sprintSpeed = 6f;
  float walkSpeed = 3f;
  float crouchSpeed = 2f;
  float lyingSpeed = 0.5f;

  // HEIGHTS

  float standingHeight = 2f;
  float crouchingHeight = 1f;
  float lyingHeight = 0.1f;

  // VOLUMES 

  float walkVol = 0.2f;
  float sprintVolume = 0.3f;
  float crouchVolume = 0.1f;
  float lyingVolume = 0.0f;

  // STEP DISTANCES

  float sprintStepDistance = 0.4f;
  float walkStepDistance = 0.6f;
  float crouchStepDistance = 0.7f;
  float lyingStepDistance = 0.8f;

  void Awake()
  {
    characterMovement = GetComponent<CharacterMovement>();
    characterVisionTransform = transform.GetChild(0);
    myCharacterFootsteps = GetComponentInChildren<CharacterFootsteps>();
  }

  void Start()
  {
    myCharacterFootsteps.volume = walkVol;
    myCharacterFootsteps.stepDistance = walkStepDistance;
  }

  void Update()
  {
    if (isCharacterStanding)
      sprint();

    crouchAndLieDown();
  }

  void sprint()
  {
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      characterMovement.characterSpeed = sprintSpeed;
      setCharacterFootSound(sprintStepDistance, sprintVolume);
    }
    else if (Input.GetKeyUp(KeyCode.LeftShift))
    {
      characterMovement.characterSpeed = walkSpeed;
      setCharacterFootSound(walkStepDistance, walkVol);
    }
  }

  void crouchAndLieDown()
  {
    if (Input.GetKeyDown(KeyCode.Z))
    {
      if (isCharacterStanding) // crouch now
        setCharacterState(crouchingHeight, crouchSpeed, ref isCharacterStanding, ref isCharacterCrouching, crouchStepDistance, crouchVolume);

      else if (isCharacterCrouching) // lie down now
        setCharacterState(lyingHeight, lyingSpeed, ref isCharacterCrouching, ref isCharacterLying, lyingStepDistance, lyingVolume);

      else if (isCharacterLying) // stand up now
        setCharacterState(standingHeight, walkSpeed, ref isCharacterLying, ref isCharacterStanding, walkStepDistance, walkVol);
    }
  }

  void setCharacterState(float height, float speed, ref bool oldState, ref bool newState, float stepDistance, float vol)
  {
    characterVisionTransform.localPosition = new Vector3(0f, height, 0f);
    characterMovement.characterSpeed = speed;
    oldState = false;
    newState = true;

    setCharacterFootSound(stepDistance, vol);
  }

  void setCharacterFootSound(float stepDistance, float volume)
  {
    myCharacterFootsteps.stepDistance = stepDistance;
    myCharacterFootsteps.volume = volume;
  }
}
