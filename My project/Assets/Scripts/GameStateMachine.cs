using UnityEngine;
public class GameStateMachine<T> where T : IGameState
{
    private T currentState;

    public T CurrentState
    {
        get 
        {
            return currentState;
        }
    }
    public void ChangeState(T newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }
    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}