using UnityEngine;

public class GameplayState : IState
{
    private StateMachine stateMachine;
    private float timer = 10;

    public GameplayState(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if(timer <= 0 )
        {
            stateMachine.ChangeState(GameState.GameOver);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            stateMachine.ChangeState(GameState.Pause);
        }

    }
}
