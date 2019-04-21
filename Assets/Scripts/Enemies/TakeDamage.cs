using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private int maxHealth = 10;

    public GameObject bloodEffect;
    public GameObject money;
    public AudioClip deathSound;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Damage(int damage)
    {
        DamageEffect();

        maxHealth -= damage;
        if (maxHealth <= 0)
        {
            DeathEffect();
            Destroy(gameObject, 0.4f);
        }
    }

    private void DamageEffect()
    {
        Instantiate(bloodEffect, transform);
        transform.position -= transform.forward * 0.8f;
    }

    private void DeathEffect()
    {
        audioSource.Stop();
        audioSource.clip = deathSound;
        audioSource.Play();
        Instantiate(bloodEffect, transform);
        Instantiate(money, new Vector3
        {
            x = transform.position.x,
            z = transform.position.z
        }, transform.rotation);
    }
}
