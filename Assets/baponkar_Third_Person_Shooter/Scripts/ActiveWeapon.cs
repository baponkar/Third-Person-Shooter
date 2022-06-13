//Writer : Bapon Kar
//Build Date : 28/05/2022
//Last Update : 11/06/2022
//Description : This script use to manage active weapon attach with player.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;

namespace Baponkar.ThirdPerson.Shooter
{
    public class ActiveWeapon : MonoBehaviour
    {
        public enum WeaponSlots
        {
            primary = 0,
            secondary = 1
        }

        WeaponSoundManager weaponSoundManager;

        public Cinemachine.CinemachineFreeLook playerCamera;
        public Transform [] weaponSlots;
        public Transform raycastTarget;
        public RaycastWeapon [] equipedWeapon = new RaycastWeapon[2];
        public int activeWeaponIndex;

        public Transform weaponRightGrip;
        public Transform weaponLeftGrip;
        public Animator rigController;

        public bool isHoistered = false;

        public RaycastWeapon GetWeapon(int index)
        {
            if(index < 0 || index >= equipedWeapon.Length)
            {
                return null;
            }

            return equipedWeapon[index];
        }

        void Start()
        {
            weaponSoundManager = FindObjectOfType<WeaponSoundManager>();
            RaycastWeapon existingWeapon = this.GetComponentInChildren<RaycastWeapon>();

            if(existingWeapon)
            {
                Equip(existingWeapon);
            }
        }


        void Update()
        {
            var weapon = GetWeapon(activeWeaponIndex);
            if(weapon && !isHoistered)
            {
                if(Input.GetButtonDown("Fire1"))
                {
                    weapon.StartFireing();
                    if(weaponSoundManager)
                    {
                        weaponSoundManager.FireSound();
                    } 
                }
                if(Input.GetButtonUp("Fire1"))
                {
                    weapon.StopFireing();
                }
                if(weapon.isFireing)
                {
                    weapon.UpdateFireing(Time.deltaTime);
                }
                weapon.UpdateBullets(Time.deltaTime);
            }

            if(Input.GetKeyDown(KeyCode.X))
            {
                ToggleActivateWeapon();
            }

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetActiveWeapon(WeaponSlots.primary);
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetActiveWeapon(WeaponSlots.secondary);
            }
        }

        public bool isFireing()
        {
            RaycastWeapon currentWeapon = GetActiveWeapon();
            if(!currentWeapon)
            {
                return false;
            }
            return currentWeapon.isFireing;
        }

        public void Equip(RaycastWeapon newWeapon)
        {
            int weaponSlotIndex = (int) newWeapon.weaponSlot;
            var weapon = GetWeapon(weaponSlotIndex);
            if(weapon)
            {
                Destroy(weapon.gameObject);
            }
            
            weapon = newWeapon;
            weapon.raycastDestination = raycastTarget;
            weapon.recoil.playerCamera = playerCamera;
            weapon.recoil.rigController = rigController;
            weapon.recoil.weaponName = weapon.name;
            weapon.transform.SetParent(weaponSlots[weaponSlotIndex], false);
            equipedWeapon[weaponSlotIndex] = weapon;

        SetActiveWeapon(newWeapon.weaponSlot); 
        }

        public void ToggleActivateWeapon()
        {
            bool ishoistered = rigController.GetBool("hoister_weapon");
            if(ishoistered)
            {
                StartCoroutine(ActivateWeapon(activeWeaponIndex));
            }
            else
            {
                StartCoroutine(HoisterWeapoon(activeWeaponIndex));
            }
        }

        void SetActiveWeapon(WeaponSlots weaponSlot)
        {
            
            int hoisterIndex = activeWeaponIndex;
            int activateIndex = (int) weaponSlot;
            if(hoisterIndex == activeWeaponIndex)
            {
                hoisterIndex -= 1;
            }
            StartCoroutine(SwitchWeapon(hoisterIndex, activateIndex));
        }

        private IEnumerator SwitchWeapon(int hoisterIndex, int activateIndex)
        {
            rigController.SetInteger("weaponIndex",activateIndex);
            yield return StartCoroutine(HoisterWeapoon(hoisterIndex));
            yield return StartCoroutine(ActivateWeapon(activateIndex));
            activeWeaponIndex = activateIndex;
        }

        private IEnumerator HoisterWeapoon(int index)
        {
            isHoistered = true;
            var weapon = GetWeapon(index);
            if(weapon)
            {
                rigController.SetBool("hoister_weapon", true);
                do
                {
                    yield return new WaitForEndOfFrame();
                } while (rigController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
            }
        }

        private IEnumerator ActivateWeapon(int index)
        {
            var weapon = GetWeapon(index);
            if(weapon)
            {
                rigController.SetBool("hoister_weapon", false);
                rigController.Play("equip_" + weapon.weaponName, 0, 0.0f);
                do
                {
                    yield return new WaitForEndOfFrame();
                } while (rigController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
            }
            isHoistered = false;
            
        }

        public RaycastWeapon GetActiveWeapon()
        {
            return GetWeapon(activeWeaponIndex);
        }

    }
}
