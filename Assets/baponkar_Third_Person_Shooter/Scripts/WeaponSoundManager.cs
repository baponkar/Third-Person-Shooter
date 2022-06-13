using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.ThirdPerson.Shooter
{
    public class WeaponSoundManager : MonoBehaviour
    {
        AudioSource audioSource;
        public AudioClip fireSound;

        public void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void Start()
        {

        }

        public void FireSound()
        {
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(fireSound);
            }
        }
    }


}
