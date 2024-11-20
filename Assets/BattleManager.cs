using UnityEngine;

public class BattleManager : MonoBehaviour
{
    bool isPlayer1Turn = true;
    public GameObject player1Buttons;
    public GameObject player2Buttons;

    private void Start()
    {
        player1Buttons.SetActive(true);
        player2Buttons.SetActive(false);
    }

    public void ChangePlayerTurn()
    {
        Debug.Log("Change turn");
        isPlayer1Turn = !isPlayer1Turn;
        player1Buttons.SetActive(isPlayer1Turn);
        player2Buttons.SetActive(!isPlayer1Turn);

        //if (isPlayer1Turn )
        //{
        //    player1Buttons.SetActive(true);
        //    player1Buttons.SetActive(false);
        //}
        //else
        //{
        //    player1Buttons.SetActive(false);
        //    player1Buttons.SetActive(true);
        //}
    }
}
