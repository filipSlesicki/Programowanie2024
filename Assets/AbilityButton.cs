using TMPro;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{
    public DamageAbility ability;
    public Health target;
    public Mana userMana;
    public TMP_Text abilityNameText;
    private BattleManager battleManager;

    private void Start()
    {
        battleManager = FindAnyObjectByType<BattleManager>();
    }

    public void UseAbility()
    {
        if(ability.Use(target, userMana))
        {
            battleManager.ChangePlayerTurn();
        }
    }

    private void OnValidate()
    {
        if (abilityNameText != null)
        {
            abilityNameText.text = ability.Name;
        }
    }
}
