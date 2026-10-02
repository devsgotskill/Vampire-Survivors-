using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MonoBehaviour[] ScriptsToPause;
    private GameStateMachine<IGameState> stateMachine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        stateMachine = new GameStateMachine<IGameState>();
        stateMachine.ChangeState(new PlayingState());
    }

    private void Update()
    {
        stateMachine.Update();
    }
    public void ChangeState(IGameState newState)
    {
        stateMachine.ChangeState(newState);
    }
    public bool IsPlaying()
    {
        return stateMachine.CurrentState is PlayingState;
    }
    public bool IsPaused()
    {
        return stateMachine.CurrentState is PausedState;
    }
    public bool IsUpgrade()
    {
        return stateMachine.CurrentState is UpgradeState;
    }
    public bool IsDead()
    {
        return stateMachine.CurrentState is DeathState;
    }
    public void SetGameplayScripts(bool enabled)
    {
        foreach (MonoBehaviour script in ScriptsToPause)
        {
            if (script != null)
            {
                script.enabled = enabled;
            }
        }
    }
}
