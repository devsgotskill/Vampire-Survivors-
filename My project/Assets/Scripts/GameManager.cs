using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
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
}