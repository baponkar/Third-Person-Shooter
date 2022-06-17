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

    bool cursorLockMode;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    void Update()
    {
        ray.origin = mainCamera.transform.position;
        ray.direction = mainCamera.transform.forward;

        if (Physics.Raycast(ray, out hit, layermask.value, (int) QueryTriggerInteraction.Ignore))
        {
            transform.position = hit.point;
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
