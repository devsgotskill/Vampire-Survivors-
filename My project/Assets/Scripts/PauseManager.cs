using UnityEngine;
public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.IsPaused())
            {
                Resume();
            }
            else if (GameManager.Instance.IsPlaying())
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        GameManager.Instance.ChangeState(new PausedState());
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        GameManager.Instance.ChangeState(new PlayingState());
    }
}