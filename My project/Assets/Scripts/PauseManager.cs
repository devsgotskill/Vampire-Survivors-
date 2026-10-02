using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    public GameObject PauseMenu;
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
        PauseMenu.SetActive(true);
        GameManager.Instance.ChangeState(new PausedState());
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        GameManager.Instance.ChangeState(new PlayingState());
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}