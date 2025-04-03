using TMPro;
using UnityEngine;

public class TurnUI : MonoBehaviour
{
    [SerializeField] private TMP_Text turnText;

    public void OnNewTurn(int turn)
    {
        turnText.text = $"Player {turn} Turn";
    }
}
