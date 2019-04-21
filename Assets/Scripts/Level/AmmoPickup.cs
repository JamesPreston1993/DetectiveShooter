using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public bool isAmmoAvailable;
    public GameObject ammoBox;

    public void Awake()
    {
        ammoBox.SetActive(false);
    }

    public void Activate()
    {
        isAmmoAvailable = true;
        ammoBox.SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerShoot>().AddAmmo(12);
            isAmmoAvailable = false;
            ammoBox.SetActive(false);
        }
    }
}
