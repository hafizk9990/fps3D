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
  EnemyAnimator myEnemyAnimator;
  NavMeshAgent myNavMeshAgent;
  public float walkSpeed = 0.5f;
  public float runSpeed = 4f;
  public float chaseDistance = 7f;
  float currentChaseDistance;
  float attackDistance = 1.8f;
  float chaseAfterAttackDistance = 2f;
  float patrolRadiusMin = 20f;
  float patrolRadiusMax = 60f;
  float patrolForThisTime = 15f;
  public float patrolTimer;
  public float waitBeforeAttack = 2f;
  float attackTimer;
  Transform target;

  void Awake()
  {
    myEnemyAnimator = GetComponent<EnemyAnimator>();
    myNavMeshAgent = GetComponent<NavMeshAgent>();
    target = GameObject.FindWithTag("Character").transform;
  }

  void Start()
  {
    myEnemyStateEnum = EnemyState.PATROL;
    patrolTimer = patrolForThisTime;
    attackTimer = waitBeforeAttack;
    currentChaseDistance = chaseDistance;
  }

  void Update()
  {
    if (myEnemyStateEnum == EnemyState.PATROL)
      patrol();
    else if (myEnemyStateEnum == EnemyState.CHASE)
      chase();
    else if (myEnemyStateEnum == EnemyState.ATTACK)
      attack();
  }

  void patrol()
  {
    myNavMeshAgent.isStopped = false;
    myNavMeshAgent.speed = walkSpeed;
    patrolTimer += Time.deltaTime;

    if (patrolTimer >= patrolForThisTime)
    {
      patrolTimer = 0f;
      setNewRandomDestination();
    }

    if (myNavMeshAgent.velocity.sqrMagnitude > 0)
    {
      // Guy moving
    }
  }

  void setNewRandomDestination()
  {
    float randomPatrolRadius = Random.Range(patrolRadiusMin, patrolRadiusMax);
    Vector3 randomDirection = Random.insideUnitSphere * randomPatrolRadius;
    randomDirection += transform.position;

    NavMeshHit myNavMeshHit;
    NavMesh.SamplePosition(randomDirection, out myNavMeshHit, randomPatrolRadius, -1);
    myNavMeshAgent.SetDestination(myNavMeshHit.position);
  }

  void chase()
  {

  }

  void attack()
  {

  }
}
