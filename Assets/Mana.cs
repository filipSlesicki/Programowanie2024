using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Image manaBar;
    public float maxMana = 10;
    public float currentMana;

    void Start()
    {
        currentMana = maxMana;
        UpdateUI();
    }

    public void ModifyMana(float amount)
    {
        currentMana += amount;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        float normalizedHealth = (float)currentMana / maxMana;
        manaBar.fillAmount = normalizedHealth;
    }
}
