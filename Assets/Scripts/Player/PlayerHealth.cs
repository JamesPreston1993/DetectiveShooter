using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI healthUi;

    public void Update()
    {
        healthUi.SetText("Health: {0}", health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
