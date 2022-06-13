using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RecoilWeapon : MonoBehaviour
{
    [HideInInspector] public CinemachineFreeLook playerCamera;
    [HideInInspector] public CinemachineImpulseSource cameraShake;
    [HideInInspector] public Animator rigController;
    [HideInInspector] public string weaponName;
    public float verticalRecoil;
    public float horizontalRecoil;
    public float duration;


    float time;

    void Awake()
    {
        cameraShake = GetComponent<CinemachineImpulseSource>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(time > 0.0f)
        {
            //GenerateRecoil(weaponName);
            time -= Time.deltaTime;
        }
        
    }

    public void GenerateRecoil(string weaponName)
    {
        time = duration;
        playerCamera.m_YAxis.Value -= (verticalRecoil * Time.deltaTime)/(1000*duration);
        playerCamera.m_XAxis.Value -= (Random.Range(-horizontalRecoil,horizontalRecoil) * Time.deltaTime)/(10*duration);
        //cameraShake.GenerateImpulse(Camera.main.transform.forward);

        rigController.Play("weapon_recoil_" + weaponName, 1, 0.0f);

    }
}
