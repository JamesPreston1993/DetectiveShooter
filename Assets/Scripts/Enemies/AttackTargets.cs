using UnityEngine;
using System.Collections;

public class AttackTargets : MonoBehaviour
{
    public Transform playerTransform;

    private float fireRate = 0.5f;
    private float nextFireTime;
    private float fireRange = 5.0f;
    private int weaponDamage = 1;

    private LineRenderer lineRenderer;
    private WaitForSeconds fireDuration;
    private AudioSource fireSound;

    void Start()
    {
        fireSound = GetComponent<AudioSource>();
        fireDuration = new WaitForSeconds(0.75f);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
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
        Vector3 endpoint = transform.position + (transform.forward * fireRange);
        if (Physics.Raycast(ray, out hitInfo, fireRange))
        {
            endpoint = hitInfo.point;
            var damageable = hitInfo.collider.GetComponent<TakeDamage>();
            if (damageable != null)
            {
                damageable.Damage(weaponDamage);
            }
        }

        StartCoroutine(FireEffect(endpoint));
    }

    private IEnumerator FireEffect(Vector3 endpoint)
    {
        fireSound.Play();

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endpoint);

        lineRenderer.enabled = true;

        yield return fireDuration;

        lineRenderer.enabled = false;
    }
}
