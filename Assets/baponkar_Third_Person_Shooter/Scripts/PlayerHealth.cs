using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.ThirdPerson.Shooter
{
    public class PlayerHealth : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float currentHealth;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
        }

        public float GetHealth()
        {
            return currentHealth;
        }

        public void Die()
        {
            Debug.Log("Player Died");
        }
    }
}
