using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
  WeaponManager weaponManager;
  float fireRate = 15;
  float nextTimeToFire;
  float daamge = 20f;

  void Awake()
  {
    weaponManager = GetComponent<WeaponManager>();
  }

  // Update is called once per frame
  void Update()
  {
    shoot();
  }

  void shoot()
  {
    if (weaponManager.getCurrentWeapon().fireType == WeaponFireType.MULTIPLE_FIRE)
    {
      if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
      {
        nextTimeToFire = Time.time + (1f / fireRate);
        weaponManager.getCurrentWeapon().shootAnimation();
      }
      else
      {

      }
    }
  }
}
