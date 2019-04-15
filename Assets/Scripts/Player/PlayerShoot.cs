using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera playerCamera;

    private float fireRate = 0.5f;
    private float nextFireTime;
    private float fireRange = 10.0f;
    private int weaponDamage = 1;

    private AudioSource fireSound;
    private Animator animator;

    void Start()
    {
        fireSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update ()
    {
        // Check if player is shooting
        var isPlayerShooting = Input.GetButton("Fire1");

        // Check if player can shoot
        var canShoot = Time.time > nextFireTime;

        if (isPlayerShooting && canShoot)
        {
            nextFireTime = Time.time + fireRate;

            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        StartCoroutine(FireEffect());
        var ray = new Ray
        {
            origin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)),
            direction = playerCamera.transform.forward
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
    }

    private IEnumerator FireEffect()
    {
        fireSound.Play();
        animator.SetBool("IsShooting", true);

        yield return new WaitForSeconds(0);

        animator.SetBool("IsShooting", false);
    }
}
