//Writer : Bapon Kar
//Build Date : 28/05/2022
//Last Update : 11/06/2022
//Description : This script use for manage Gun Fire

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Cinemachine;

namespace Baponkar.ThirdPerson.Shooter
{
    public class WeaponAim : MonoBehaviour
    {
    
        // public Rig bodyLayer;
        // public Rig weaponAimLayer;
        //public bool aim;

        //public float aimDuration = 0.1f;
        RaycastWeapon weapon;
        bool  fireInput;
        
    
        void Start()
        {
            weapon = GetComponentInChildren<RaycastWeapon>();
        }

        void Update()
        {   
            // aim = Input.GetButton("Fire1");
            // if(aim)
            // {    
            //     weaponAimLayer.weight += Time.deltaTime / aimDuration;
            //     bodyLayer.weight += Time.deltaTime / aimDuration;
            // }
            // else
            // {
            //     weaponAimLayer.weight -= Time.deltaTime / aimDuration;
            //     bodyLayer.weight -= Time.deltaTime / aimDuration;
            // }
            // weaponAimLayer.weight = 1.0f;
            // bodyLayer.weight = 1.0f;

            fireInput = Input.GetButtonDown("Fire1");
            FireControl(fireInput);
            
        }

        void FireControl(bool input)
        {
            if(weapon)
            {
                if(input)
                {
                    weapon.StartFireing();
                }
                if(input)
                {
                    weapon.StopFireing();
                }
                if(weapon.isFireing)
                {
                    weapon.UpdateFireing(Time.deltaTime);
                }
                weapon.UpdateBullets(Time.deltaTime);
            }
        }
    }
}
