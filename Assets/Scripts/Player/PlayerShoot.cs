using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private float fireRate = 0.5f;
    private float nextFireTime;

    private int shotsFired;

	void Update ()
    {
        // Check if player is shooting
        var isPlayerShooting = Input.GetButton("Fire1");

        // Check if player can shoot
        var canShoot = Time.time > nextFireTime;

        if (isPlayerShooting && canShoot)
        {
            nextFireTime = Time.time + fireRate;
            Debug.Log("Bang! Shots fired: " + ++shotsFired);
        }
    }
}
