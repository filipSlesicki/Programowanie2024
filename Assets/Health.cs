using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public UnityEvent deathEvent;
    public Image healthBar;
    public float maxHealth = 10;
    private float currentHealth;
    private object fin;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void ModifyHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            deathEvent.Invoke();
            //if (gameObject.CompareTag("Asteroid"))
            //{
            //    FindAnyObjectByType<ScoreManager>().AddScore();
            //}
            //if (gameObject.CompareTag("Player"))
            //{
            //    Destroy(FindAnyObjectByType<AsteroidsGameController>());
            //}
            Destroy(gameObject);

        }

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            float normalizedHealth = (float)currentHealth / maxHealth;
            healthBar.fillAmount = normalizedHealth;
        }
    }
}
