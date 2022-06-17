using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairTarget : MonoBehaviour
{
    [Tooltip("The Layer which is ignored by this")]
    public LayerMask layermask;
    Camera mainCamera;
    Ray ray;
    RaycastHit hit;


    

    void Start()
    {
        mainCamera = Camera.main;
    }

   
    void Update()
    {
        ray.origin = mainCamera.transform.position;
        ray.direction = mainCamera.transform.forward;

        if (Physics.Raycast(ray, out hit, layermask.value))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            transform.position = hit.point;
        }
        
    }
}
