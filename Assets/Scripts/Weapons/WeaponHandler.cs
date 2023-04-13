using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim
{
  NO_AIM,
  SELF_AIM,
  AIM,
}

public enum WeaponFireType
{
  SINGLE_FIRE,
  MULTIPLE_FIRE,
}

public enum WeaponProjectileType
{
  BULLET,
  ARROW,
  SPEAR,
  NONE,
}

public class WeaponHandler : MonoBehaviour
{
  public Animator anim;
  [SerializeField]
  public GameObject muzzleFlash;
  public AudioSource shootSound, reloadSound;
  public WeaponProjectileType projectileType;
  public WeaponFireType fireType;
  public WeaponAim weaponAim;
  public GameObject attackPoint;

  void Awake()
  {
    anim = GetComponent<Animator>();
  }

  public void shootAnimation()
  {
    anim.SetTrigger("Shoot");
  }

  public void Aim(bool canAim)
  {
    anim.SetBool(AnimationTags.AIM_PARAM, canAim);
  }

  public void showMuzzleFlash()
  {
    muzzleFlash.SetActive(true);
  }
  public void hideMuzzleFlash()
  {
    muzzleFlash.SetActive(false);
  }

  public void playShootSound()
  {
    shootSound.Play();
  }

  public void playReloadSound()
  {
    reloadSound.Play();
  }

  public void showAttackPoint()
  {
    attackPoint.SetActive(true);
  }

  public void hideAttackPoint()
  {
    if (attackPoint.activeInHierarchy)
      attackPoint.SetActive(false);
  }
}
