//Writer : Bapon Kar
//Build Date : 28/05/2022
//Last Update : 11/06/2022
//Description : This script use for manage raycast weapon

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Baponkar.ThirdPerson.Shooter
{
    class Bullet 
    {
        public float time;
        public Vector3 initialPosition;
        public Vector3 initialVelocity;
        public TrailRenderer tracer;
    }
    public class RaycastWeapon : MonoBehaviour
    {
        [HideInInspector]
        public RecoilWeapon recoil;
        public ActiveWeapon.WeaponSlots weaponSlot;

        public ParticleSystem [] muzzleFlash;
        public ParticleSystem [] hitEffect;
        public TrailRenderer tracerEffect;

        public string weaponName;
        public bool isFireing;

        public Transform raycastOrigin;
        [HideInInspector]
        public Transform raycastDestination;
        Ray ray;

        float maxLifeTime = 30.0f;
        RaycastHit hitInfo;
        float acumalatedTime;
        public float fireRate;

        public float bulletSpeed = 1000.0f;
        public float bulletDrop = 0.0f;

        public Transform capsuleInstantiatePosition;
        
        void Awake()
        {
            recoil = GetComponent<RecoilWeapon>();
        }

        List<Bullet> bullets = new List<Bullet>();
        Vector3 GetPosition(Bullet bullet)
        {
            //s+u*t+a*t*t/2
            Vector3 gravity = Vector3.down * bulletDrop;
            return (bullet.initialPosition) + (bullet.initialVelocity * bullet.time + 0.5f * gravity * bullet.time * bullet.time);
        }

        Bullet CreateBullet(Vector3 initialPosition, Vector3 initialVelocity)
        {
            Bullet bullet = new Bullet();
            bullet.initialPosition = initialPosition;
            bullet.initialVelocity = initialVelocity;
            bullet.time = 0.0f;
            bullet.tracer = Instantiate(tracerEffect, initialPosition, Quaternion.identity);
            bullet.tracer.AddPosition(initialPosition);
            return bullet;
        }

        public void UpdateBullets( float deltaTime)
        {
            SimulateBullet(deltaTime);
            DestroyBullet();
        }

        void DestroyBullet()
        {
            bullets.RemoveAll(bullet => bullet.time > maxLifeTime);
        }

        void SimulateBullet(float deltaTime)
        {
            bullets.ForEach(bullet =>
            {
                Vector3 p0 = GetPosition(bullet);
                bullet.time += deltaTime;
                Vector3 p1  = GetPosition(bullet);
                RaycastSegment(p0, p1, bullet);
            });
        }

        void RaycastSegment(Vector3 start, Vector3 end, Bullet bullet)
        {
            float distance = Vector3.Distance(start, end);
            Vector3 direction = (end - start).normalized;
            ray.origin = start;
            ray.direction = direction;


            if (Physics.Raycast(ray, out hitInfo, distance))
            {
                //Debug.Log(hitInfo.transform.name);
                if(hitInfo.transform.tag != "Player")
                {
                    foreach (ParticleSystem hit in hitEffect)
                    {
                        hit.transform.position = hitInfo.point;
                        hit.transform.forward = hitInfo.normal;
                        hit.Emit(1);
                        
                        bullet.tracer.transform.position = hitInfo.point;
                        bullet.time = maxLifeTime;
                    }
                }
            }
            else
            {
                bullet.tracer.transform.position = end;
            }
        }

        public void StartFireing()
        {
            acumalatedTime = 0.0f;
            isFireing = true;
            FireBullet();
        }

        public void UpdateFireing(float deltaTime)
        {
            acumalatedTime += deltaTime;
            float fireInterval  = 1.0f / fireRate;
            while (acumalatedTime > 0.1f)
            {
                FireBullet();
                acumalatedTime -= fireInterval;
            }
        }

        private void FireBullet()
        {
            foreach (var muzzle in muzzleFlash)
            {
                muzzle.Emit(1);
            }
            Vector3 velocity = (raycastDestination.position - raycastOrigin.position).normalized * bulletSpeed;
            var bullet = CreateBullet(raycastOrigin.position, velocity);
            bullets.Add(bullet);
            recoil.GenerateRecoil(weaponName);
            // ray.origin = raycastOrigin.position;
            // ray.direction = raycastDestination.position - raycastOrigin.position;

            // var tracer = Instantiate(tracerEffect, raycastOrigin.position, Quaternion.identity);
            // tracer.AddPosition(raycastDestination.position);

            // if (Physics.Raycast(ray, out hitInfo))
            // {
            //     Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            //     foreach (ParticleSystem hit in hitEffect)
            //     {
            //         hit.transform.position = hitInfo.point;
            //         hit.transform.forward = hitInfo.normal;
            //         hit.Emit(1);
            //     }    tracer.transform.position = hitInfo.point;
            //     }

            // }
            
        }

        public void StopFireing()
        {
            isFireing = false;
        }

    
    }

}