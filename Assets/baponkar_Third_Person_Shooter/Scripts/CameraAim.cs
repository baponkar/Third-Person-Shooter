//Writer : Bapon Kar
//Build Date : 28/05/2022
//Last Update : 11/06/2022
//Description : This script use for rotate player along camera direction

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.ThirdPerson.Shooter
{
    public class CameraAim : MonoBehaviour
    {
        [HideInInspector]
        public Camera mainCamera;
        public float rotationSpeed = 15f;

        void Start()
        {
            mainCamera = Camera.main;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void FixedUpdate()
        {
            float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,yawCamera,0), Time.deltaTime * rotationSpeed);

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(Cursor.lockState == CursorLockMode.Locked)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }
}
