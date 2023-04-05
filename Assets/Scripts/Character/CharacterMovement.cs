using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
  public float speed = 5f;
  public float jumpForce = 10f;
  public float gravity = 20f;
  private Vector3 moveDirection = Vector3.zero;
  private CharacterController myCharacter;

  void Awake()
  {
    myCharacter = GetComponent<CharacterController>();
  }

  void Update()
  {
    // transform = new Vector3(transform.x, transform.y, transform.z); // Why not this?
    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
  }
}
