using TMPro;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{
    public DamageAbility ability;
    public Health target;
    public Health user;
    public TMP_Text abilityNameText;

    //private void Start()
    //{
    //    abilityNameText.text = ability.Name;
    //}

    public void UseAbility()
    {
        ability.Use(target);
    }

    private void OnValidate()
    {
        if (abilityNameText != null)
        {
            abilityNameText.text = ability.Name;
        }
    }
}
