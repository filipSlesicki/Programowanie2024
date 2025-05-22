using UnityEngine;

public class PauseState : IState
{
    private readonly StateMachine stateMachine;
    private readonly GameObject pauseWindow;

    public PauseState(StateMachine stateMachine, GameObject window)
    {
        //this to jest ta klasa
        this.stateMachine = stateMachine;
        pauseWindow = window;
    }

    public void Enter()
    {
        Time.timeScale = 0;
        pauseWindow.SetActive(true);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stateMachine.ChangeState(GameState.Gameplay);
        }
    }

    public void Exit()
    {
        Time.timeScale = 1;
        pauseWindow.SetActive(false);
    }
}
