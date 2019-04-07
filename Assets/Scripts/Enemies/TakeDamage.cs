using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private int maxHealth = 3;

    public void Damage(int damage)
    {
        Debug.Log(name + " was damaged!");
        maxHealth -= damage;
        if (maxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
