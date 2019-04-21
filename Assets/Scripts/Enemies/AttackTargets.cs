using UnityEngine;
using System.Collections;

public class AttackTargets : MonoBehaviour
{
    private float speed = 6.0f;

    public Transform playerTransform;

    private float fireRate = 0.5f;
    private float nextFireTime;
    private float fireRange = 10.0f;
    private int weaponDamage = 3;

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
            var turnDirection = Vector3.RotateTowards(transform.forward,
                playerTransform.position - transform.position,
                speed * Time.deltaTime, 0.0f);
            var rotation = Quaternion.LookRotation(turnDirection);
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
        FireEffect();

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
                return;
            }

            var playerHealth = hitInfo.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(weaponDamage);
            }
        }
    }

    private void FireEffect()
    {
        fireSound.Play();
    }
}
