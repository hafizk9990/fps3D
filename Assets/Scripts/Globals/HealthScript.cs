using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour
{
  EnemyAnimator myEnemyAnimatorScript;
  NavMeshAgent myNavMeshAgent;
  EnemyController myEnemyControllerScript;
  [SerializeField] float health = 100f;
  [SerializeField] bool isPlayer, isBoar, isCannibal;
  bool isDead = false;

  void Awake()
  {
    if (isBoar || isCannibal)
    {
      myEnemyAnimatorScript = GetComponent<EnemyAnimator>();
      myEnemyControllerScript = GetComponent<EnemyController>();
      myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    if (isPlayer)
    {
      // get player stats
    }
  }

  public void applyDamage(float damage)
  {
    if (isDead)
      return;
  }
}
