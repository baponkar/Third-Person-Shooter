using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.ThirdPerson.Shooter
{
    public class WeaponPickup : MonoBehaviour
    {
        public GameObject weaponPrefab;
        public void OnTriggerEnter(Collider other)
        {
            ActiveWeapon activeWeapon = other.gameObject.GetComponent<ActiveWeapon>();
            if(activeWeapon != null)
            {
                RaycastWeapon newWeapon = Instantiate(weaponPrefab).GetComponent<RaycastWeapon>();
                activeWeapon.Equip(newWeapon);
            }
        }
    }
}
