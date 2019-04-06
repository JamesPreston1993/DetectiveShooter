using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private int maxHealth = 3;

    public void Damage(int damage)
    {
        maxHealth -= damage;
        if (maxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
