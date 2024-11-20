using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public Slider healthSlider;
    public Image healthBar;
    public TMP_Text healthText;
    public float maxHealth = 10;
    private float currentHealth = 5;
    public float regenRate = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float missingHealth = maxHealth - currentHealth;
        float timeToRegen = missingHealth / regenRate;
        Debug.Log("It will take " + timeToRegen + " seconds to regenerate to full health");
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void ModifyHealth(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if(currentHealth < 0)
        {
            // Death
        }
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        //healthText.text = "Health " + currentHealth + " / " + maxHealth;
        float normalizedHealth = (float)currentHealth / maxHealth;
        //healthSlider.maxValue = maxHealth;
        //healthSlider.value = normalizedHealth;
        healthBar.fillAmount = normalizedHealth;
    }
}
