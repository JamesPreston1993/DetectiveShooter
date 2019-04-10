using UnityEngine;
using System.Collections;

public class AttackTargets : MonoBehaviour
{
    public Transform playerTransform;

    private float fireRate = 0.5f;
    private float nextFireTime;
    private float fireRange = 5.0f;
    private int weaponDamage = 1;

    private AudioSource fireSound;

    void Start()
    {
        fireSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Rotate towards player
        if (playerTransform != null)
        {
            var rotation = Quaternion.LookRotation(playerTransform.position - transform.position);
            transform.rotation = rotation;
        }

        // Check if enemy can shoot
        var canShoot = Time.time > nextFireTime;

        if (canShoot)
        {
            nextFireTime = Time.time + fireRate;

            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        var ray = new Ray
        {
            origin = transform.position,
            direction = transform.forward
        };

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, fireRange))
        {
            var damageable = hitInfo.collider.GetComponent<TakeDamage>();
            if (damageable != null)
            {
                damageable.Damage(weaponDamage);
            }
        }

       FireEffect();
    }

    private void FireEffect()
    {
        fireSound.Play();
    }
}
