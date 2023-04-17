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
  Animator fpCameraAnimator;
  GameObject crossHair;
  bool isAiming;
  [SerializeField]
  GameObject arrowPrefab, bowPrefab;
  [SerializeField]
  Transform arrowAndBowStartPosition;

  void Awake()
  {
    weaponManager = GetComponent<WeaponManager>();
    mainCam = Camera.main;
    fpCameraAnimator = GameObject.FindGameObjectWithTag("FP Cam").GetComponent<Animator>();
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

      else if (weaponManager.getCurrentWeapon().tag == "Bow" || weaponManager.getCurrentWeapon().tag == "Spear")
      {
        if (isAiming)
        {
          weaponManager.getCurrentWeapon().shootAnimation();
          if (weaponManager.getCurrentWeapon().tag == "Bow") { }
          else if (weaponManager.getCurrentWeapon().tag == "Spear") { }
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
        fpCameraAnimator.Play("ZoomIn");
        crossHair.SetActive(false);
      }
      if (Input.GetMouseButtonUp(1))
      {
        fpCameraAnimator.Play("ZoomOut");
        crossHair.SetActive(true);
      }
    }

    // For bow and spear
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

  void throwArrowOrSpear(bool throwArrow)
  {
    // do stuff here
  }
}
