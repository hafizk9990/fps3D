using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
  [SerializeField]
  WeaponHandler[] weapons;
  int currentWeaponIndex;
  void Start()
  {
    currentWeaponIndex = 0;
    weapons[currentWeaponIndex].gameObject.SetActive(true);
  }
}
