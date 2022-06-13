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
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = mainCamera.transform.position;
        ray.direction = mainCamera.transform.forward;
        if (Physics.Raycast(ray, out hit, layermask.value))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            transform.position = hit.point;
        }
        else
        {
            
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
            //Debug.Log(hit.collider.name);
            transform.position = ray.origin + ray.direction * 100;
        }
    }
}
