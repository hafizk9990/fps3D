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

  void Update()
  {
    shoot();
  }

  void shoot()
  {
    if (
      Input.GetMouseButton(0) && // Not GetMouseButtonDown( ... )
      weaponManager.getCurrentWeapon().tag == "Rifle" &&
      Time.time >= nextTimeToFire
    )
    {
      nextTimeToFire = Time.time + (1f / fireRate);
      weaponManager.getCurrentWeapon().shootAnimation();
    }

    else if (Input.GetMouseButtonDown(0))
    {
      if (weaponManager.getCurrentWeapon().tag == "Axe")
        weaponManager.getCurrentWeapon().shootAnimation();

      else if (weaponManager.getCurrentWeapon().tag == "Revolver" || weaponManager.getCurrentWeapon().tag == "Shotgun")
        weaponManager.getCurrentWeapon().shootAnimation();
    }
  }
}
