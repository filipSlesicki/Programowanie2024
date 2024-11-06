using TMPro;
using UnityEngine;

public class TugOfWar : MonoBehaviour
{
    public TMP_Text winnerText;
    public float speed = 0.1f;
    public float distanceToWin = 2;
    private bool gameFinished;
    // AI Settings
    public float timeBetweenMoves = 0.1f;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (!gameFinished)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                transform.Translate(-speed, 0, 0);
                timer = timeBetweenMoves;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.Translate(speed, 0, 0);
                DebugTest();
            }
            if (transform.position.x >= distanceToWin)
            {
                winnerText.text = "You win";
                gameFinished = true;
                DebugTest();
            }
            if (transform.position.x <= -distanceToWin)
            {
                winnerText.text = "You lose";
                gameFinished = true;
            }
        }
    }

    public void DebugTest()
    {
        Debug.Log("Test");
        Debug.Log("Test2");
        Debug.Log("Test2");

        Debug.Log("Test3");







    }

}
