using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
  WeaponManager weaponManager;
  float fireRate = 15;
  float nextTimeToFire;
  float daamge = 20f;
  bool isZoomed;
  Camera mainCam;
  Animator zoomCamAnim;
  GameObject crossHair;
  bool isAiming;

  void Awake()
  {
    weaponManager = GetComponent<WeaponManager>();
    mainCam = Camera.main;
    // zoomCamAnim = transform.Find("Character Vision").transform.Find("FP Cam").GetComponent<Animator>();
    zoomCamAnim = GameObject.FindGameObjectWithTag("FP Cam").GetComponent<Animator>();
    crossHair = GameObject.FindWithTag("Crosshair");
  }

  void Update()
  {
    shoot();
    zoomInAndOut();
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

      else if (weaponManager.getCurrentWeapon().tag == "Spear" || weaponManager.getCurrentWeapon().tag == "Bow")
      {
        if (isAiming)
        {
          weaponManager.getCurrentWeapon().shootAnimation();
          if (weaponManager.getCurrentWeapon().projectileType == WeaponProjectileType.ARROW) { }
          else if (weaponManager.getCurrentWeapon().projectileType == WeaponProjectileType.SPEAR) { }
        }
      }
    }
  }

  void zoomInAndOut()
  {
    if (weaponManager.getCurrentWeapon().weaponAim == WeaponAim.AIM)
    {
      if (Input.GetMouseButtonDown(1))
      {
        zoomCamAnim.Play("ZoomIn");
        crossHair.SetActive(false);
      }
      if (Input.GetMouseButtonUp(1))
      {
        zoomCamAnim.Play("ZoomOut");
        crossHair.SetActive(true);
      }
    }

    if (weaponManager.getCurrentWeapon().weaponAim == WeaponAim.SELF_AIM)
    {
      if (Input.GetMouseButtonDown(1))
      {
        isAiming = true;
        weaponManager.getCurrentWeapon().Aim(isAiming);
      }
      if (Input.GetMouseButtonUp(1))
      {
        isAiming = false;
        weaponManager.getCurrentWeapon().Aim(isAiming);
      }
    }
  }
}
