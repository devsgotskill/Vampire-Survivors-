using UnityEngine;

public class DeathState : IGameState
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
