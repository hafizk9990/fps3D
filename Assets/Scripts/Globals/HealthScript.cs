using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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

    health -= damage;
    print(tag + " health: " + health);

    if (isPlayer)
    {
      // do stuff
    }

    if (isBoar || isCannibal)
    {
      if (myEnemyControllerScript.getEnemyState == EnemyState.PATROL)
      {
        myEnemyControllerScript.chaseDistance = 50f;
        // When we shoot, they come running towards us
      }
    }

    if (health <= 0f)
      characterDied();
  }

  void characterDied()
  {
    isDead = true;

    if (isCannibal)
    {
      GetComponent<Animator>().enabled = false;
      GetComponent<BoxCollider>().isTrigger = false;
      GetComponent<Rigidbody>().AddTorque(transform.forward * 50 * -1);
      myEnemyControllerScript.enabled = false;
      myEnemyAnimatorScript.enabled = false;
      myNavMeshAgent.enabled = false;
    }

    if (isBoar)
    {
      myNavMeshAgent.velocity = Vector3.zero;
      myNavMeshAgent.isStopped = true;
      myEnemyControllerScript.enabled = false;
      myEnemyAnimatorScript.dead();
    }

    if (isPlayer)
    {
      // Player dead. Stop everything.

      GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

      for (int i = 0; i < allEnemies.Length; i++)
      {
        allEnemies[i].GetComponent<EnemyController>().enabled = false; ;
      }

      GetComponent<CharacterMovement>().enabled = false;
      GetComponent<CharacterAttack>().enabled = false;
      GetComponent<WeaponManager>().getCurrentWeapon().gameObject.SetActive(false);
    }

    if (tag == "Character")
      Invoke("RestartGame", 3f);
    else if (tag == "Enemy")
      Invoke("TurnOffGameObject", 2f);
  }

  void RestartGame()
  {
    SceneManager.LoadScene("SampleScene");
  }

  void TurnOffGameObject()
  {
    gameObject.SetActive(false);
  }
}
