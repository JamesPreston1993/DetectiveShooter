using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthUi;
    public Image damageIndicator;

    private float nextIndicatorTime;

    public void Awake()
    {
        damageIndicator.enabled = false;
    }

    public void Update()
    {
        healthUi.SetText("Health: {0}", health);

        if (damageIndicator.enabled && Time.time > nextIndicatorTime)
        {
            damageIndicator.enabled = false;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        DamageEffect();

        if (health <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }

    private void DamageEffect()
    {
        if (!damageIndicator.enabled)
        {
            damageIndicator.enabled = true;
            nextIndicatorTime = Time.time + 0.3f;
        }
    }
}
