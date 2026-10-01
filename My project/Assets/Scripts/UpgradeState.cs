using UnityEngine;
public class UpgradeState : IGameState
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