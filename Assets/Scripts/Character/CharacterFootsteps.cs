using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFootsteps : MonoBehaviour
{
  AudioSource footstepSound;
  [SerializeField]
  AudioClip[] footstepClips;
  float minVolume;
  float maxVolume;
  CharacterController myCharacter;
  float stepDistance;
  float accumulatedDistance;

  void Awake()
  {
    footstepSound = GetComponent<AudioSource>();
    myCharacter = GetComponent<CharacterController>();
  }

  void Update()
  {
    checkToPlayFootstepSound();
  }

  void checkToPlayFootstepSound()
  {
    if (!myCharacter.isGrounded)
      return;

    if (isCharacterMoving())
    {
      // Now, apply sound effects ... 
    }
  }

  bool isCharacterMoving()
  {
    return myCharacter.velocity.magnitude > 0;
    // Note for Performance: sqrMagnitude is faster than magnitudes
  }
}
