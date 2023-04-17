using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAndBow : MonoBehaviour
{
  Rigidbody myRigidBody;
  public float speed = 30f;
  public float deactivateTimer = 3f;
  public float damage = 15f;

  void Awake()
  {
    myRigidBody = GetComponent<Rigidbody>();
  }

  void Start()
  {
    Invoke("deactivateGameObject", deactivateTimer);
  }

  void Update()
  {

  }

  void deactivateGameObject()
  {
    if (gameObject.activeInHierarchy)
      gameObject.SetActive(false);
  }

  public void Launch(Camera mainCam)
  {
    myRigidBody.velocity = mainCam.transform.forward * speed;
    transform.LookAt(transform.position + myRigidBody.velocity);
  }

  void OnTriggerEnter(Collider other)
  {
    // 
  }
}
