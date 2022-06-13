using Cinemachine;
using UnityEngine;



[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookCameraInputs : MonoBehaviour {


    private CinemachineFreeLook freeLookCam;

    public float sensitivity = 1.0f;

    // Use this for initialization
    void Start () {
        freeLookCam = GetComponent<CinemachineFreeLook>();
    }

    
    void Update () {
        freeLookCam.m_XAxis.Value += Input.GetAxis("Horizontal") * sensitivity/10f;
        freeLookCam.m_YAxis.Value += Input.GetAxis("Vertical") * sensitivity / 1000f;

    }
}