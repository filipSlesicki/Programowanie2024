using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 10;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void ModifyHealth(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if(currentHealth <= 0)
        {
            // Death
        }

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        float normalizedHealth = (float)currentHealth / maxHealth;
        healthBar.fillAmount = normalizedHealth;
    }
}
