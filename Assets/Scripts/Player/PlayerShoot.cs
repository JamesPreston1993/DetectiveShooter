using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera playerCamera;
    public TextMeshProUGUI ammoUi;

    private float fireRate = 0.5f;
    private float nextFireTime;
    private float fireRange = 10.0f;
    private int weaponDamage = 1;

    private int clipSize = 6;
    private int clipAmmo = 6;
    private int totalAmmo = 40;
    private float reloadTime = 2.0f;

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

        ammoUi.SetText("{0} / {1} iii", clipAmmo, totalAmmo - clipAmmo);
    }

    private void FireWeapon()
    {
        totalAmmo--;
        clipAmmo--;
        if (clipAmmo == 0)
        {
            nextFireTime = Time.time + reloadTime;
            clipAmmo = clipSize;
        }

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
