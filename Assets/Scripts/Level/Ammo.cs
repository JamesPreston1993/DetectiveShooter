using UnityEngine;

public class Ammo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerShoot>().AddAmmo(12);
        }
    }
}
