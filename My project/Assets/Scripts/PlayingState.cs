using UnityEngine;

public class PlayingState : IGameState
{
    public void Enter()
    {
        GameManager.Instance.SetGameplayScripts(true);
    }

    public void Exit()
    {

    }

    public void Update()
    {
    }
}