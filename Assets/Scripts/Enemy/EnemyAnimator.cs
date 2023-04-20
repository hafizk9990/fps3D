using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
  Animator enemyAnimatorController;

  void Awake()
  {
    enemyAnimatorController = GetComponent<Animator>();
  }

  void Update()
  {
    // Call them here conditionally .... 
  }

  void walk()
  {
    enemyAnimatorController.SetBool("Walk", true);
  }
  void run()
  {
    enemyAnimatorController.SetBool("Run", true);
  }
  void attack()
  {
    enemyAnimatorController.SetTrigger("Attack");
  }
  void dead()
  {
    enemyAnimatorController.SetTrigger("Dead");
  }
}
