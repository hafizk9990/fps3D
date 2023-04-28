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

  public void walk(bool value)
  {
    enemyAnimatorController.SetBool("Walk", value);
  }

  public void run(bool value)
  {
    enemyAnimatorController.SetBool("Run", value);
  }

  public void attack()
  {
    enemyAnimatorController.SetTrigger("Attack");
  }

  public void dead()
  {
    enemyAnimatorController.SetTrigger("Dead");
  }
}
