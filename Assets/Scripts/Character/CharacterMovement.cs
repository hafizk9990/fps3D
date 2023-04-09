using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
  public float characterSpeed = 4f;
  float jumpForce = 10f;
  float gravity = 20f;
  CharacterController myCharacter;
  float verticalVelocity = 4f;
  Vector3 moveDirection = Vector3.zero;

  void Awake()
  {
    myCharacter = GetComponent<CharacterController>();
  }

  void Update()
  {
    moveCharacter();
  }

  void moveCharacter()
  {
    moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL_AXIS), 0f, Input.GetAxis(Axis.VERTICAL_AXIS));
    moveDirection = transform.TransformDirection(moveDirection);
    moveDirection = moveDirection * characterSpeed;
    moveDirection *= Time.deltaTime;
    applyGravity();
    myCharacter.Move(moveDirection);
  }

  void applyGravity()
  {
    if (myCharacter.isGrounded && Input.GetKeyDown(KeyCode.Space))
      verticalVelocity = jumpForce;
    else
      verticalVelocity -= gravity * Time.deltaTime;

    moveDirection.y = verticalVelocity * Time.deltaTime;
  }
}
