using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SetAimTraget : MonoBehaviour
{
    Camera cam;

    public Transform crossHairTarget;

    
    
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        crossHairTarget.transform.position = cam.transform.GetChild(1).position;
        crossHairTarget.transform.rotation = cam.transform.GetChild(1).rotation;
    }
}
