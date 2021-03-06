using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baponkar.ThirdPerson.Shooter
{
    public class HealthView : MonoBehaviour
    {
        [HideInInspector] public Slider slider;
        PlayerHealth health;

        void Start()
        {
            health = FindObjectOfType<PlayerHealth>();
            slider = GetComponentInChildren<Slider>();
        }

        
        void Update()
        {
            slider.value = Mathf.Clamp(health.currentHealth,0,1);
        }
    }
}
