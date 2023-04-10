using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFootsteps : MonoBehaviour
{
  AudioSource footstepSound;
  [SerializeField]
  AudioClip[] footstepClips;
  public float volume;
  CharacterController myCharacter;
  public float stepDistance;

  float accumulatedDistance;

  void Awake()
  {
    footstepSound = GetComponent<AudioSource>();
    myCharacter = GetComponentInParent<CharacterController>();
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
  }

  bool isCharacterMoving()
  {
    return myCharacter.velocity.magnitude > 0;
    // Note for Performance: sqrMagnitude is faster than magnitudes
  }
}
