using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
  [SerializeField]
  public WeaponHandler[] weapons;
  public int currentWeaponIndex;
  void Start()
  {
    currentWeaponIndex = 0;
    weapons[currentWeaponIndex].gameObject.SetActive(true);
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
      switchWeapons(0);
    else if (Input.GetKeyDown(KeyCode.Alpha2))
      switchWeapons(1);
    else if (Input.GetKeyDown(KeyCode.Alpha3))
      switchWeapons(2);
    else if (Input.GetKeyDown(KeyCode.Alpha4))
      switchWeapons(3);
    else if (Input.GetKeyDown(KeyCode.Alpha5))
      switchWeapons(4);
    else if (Input.GetKeyDown(KeyCode.Alpha6))
      switchWeapons(5);
  }

  void switchWeapons(int weaponNumber)
  {
    if (currentWeaponIndex != weaponNumber)
    {
      weapons[currentWeaponIndex].gameObject.SetActive(false);
      currentWeaponIndex = weaponNumber;
      weapons[currentWeaponIndex].gameObject.SetActive(true);
    }
  }

  public WeaponHandler getCurrentWeapon()
  {
    return weapons[currentWeaponIndex];
  }
}
