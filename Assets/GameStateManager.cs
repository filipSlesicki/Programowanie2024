using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private StateMachine stateMachine;
    [SerializeField] private GameObject pauseWindow;

    void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.AddState(GameState.Gameplay, new GameplayState(stateMachine));
        stateMachine.AddState(GameState.Pause, new PauseState(stateMachine, pauseWindow));
        stateMachine.AddState(GameState.GameOver, new GameOverState());
        // Set first state
        stateMachine.ChangeState(GameState.Gameplay);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

}
