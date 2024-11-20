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
            UpdateAIMovement();
            UpdatePlayerMovement();
            UpdateGameFinished();
        }

        float sumAB = Add(10, 5);
        Debug.Log(Add(1, 3.5f));
        int roundedDownValue = Mathf.FloorToInt(1.5f);
        Mathf.Max(10, 15);
        if(!TryMove(1))
        {
            Debug.Log("Cant move. Game is finished");
        }
    }

    private bool TryMove(int direction)
    {
        if(gameFinished)
        {
            return false;
        }

        Move(direction);
        return true;
    }

    private float Max(float a, float b)
    {
        if(a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }

    /// <summary>
    /// Move object
    /// </summary>
    /// <param name="direction">1 is right or -1 is left</param>
    public void Move(int direction)
    {
        if (!gameFinished)
        {
            transform.Translate(speed * direction, 0, 0);
        }
    }

    private void UpdatePlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1);
        }
    }

    private void UpdateAIMovement()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Move(-1);
            timer = timeBetweenMoves;
        }
    }

    private void UpdateGameFinished()
    {
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

    public float Add(float a, float b)
    {
        return a + b;
    }

    public void DebugTest()
    {
        Debug.Log("Test");
        Debug.Log("Test2");
        Debug.Log("Test2");
    }

}
