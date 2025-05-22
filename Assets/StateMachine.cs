using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    private IState currentState;
    private Dictionary<GameState, IState> gameStates = new Dictionary<GameState, IState>();

    public void Update()
    {
        currentState?.Update();
    }

    public void AddState(GameState stateType, IState state)
    {
        gameStates.Add(stateType, state);
    }

    public void ChangeState(GameState state)
    {
        //if(currentState != null)
        //{
        //    currentState.Exit();
        //}
        currentState?.Exit();        // To samo co wykomentowane powy¿ej

        if (gameStates.TryGetValue(state, out IState nextState))
        {
            currentState = nextState;
            currentState.Enter();
        }
        else
        {
            Debug.LogWarning("No state " + state);
        }
    }
}
