using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is present on the attack point game object
// Attack point is present at the endge of our Axe's blade

public class AttackScript : MonoBehaviour
{
  public float damage = 2f;
  public float radius = 1f;
  public LayerMask myLayerMask;

  void Update()
  {
    Collider[] hits = Physics.OverlapSphere(transform.position, radius, myLayerMask);

    if (hits.Length > 0 && hits[0].gameObject != null && hits[0].gameObject.activeSelf)
    {
      Debug.Log("We hit this thing: " + hits[0].gameObject.tag + " " + Time.time);
      gameObject.SetActive(false);
    }
  }
}
