using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
  PATROL,
  CHASE,
  ATTACK
}

public class EnemyController : MonoBehaviour
{
  EnemyState myEnemyStateEnum;
  Animator myEnemyAnimator;
  NavMeshAgent myNavMeshAgent;
  public float walkSpeed = 0.5f;

  void Start()
  {

  }

  void Update()
  {

  }
}
