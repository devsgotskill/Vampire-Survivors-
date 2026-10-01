using UnityEngine;
public class PausedState : IGameState
{
    public void Enter()
    {
        GameManager.Instance.SetGameplayScripts(false);
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }
}