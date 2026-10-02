using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject DeathMenu;
    public int playerHealth;
    void Start()
    {

      
    }
    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerObject.GetComponent<Player>().health;
        if (playerHealth <= 0)
        {
            if (GameManager.Instance.IsDead())
            {
                Resume();
            }
            else if (GameManager.Instance.IsPlaying())
            {
                Dead();
            }
        }
    }
    public void Dead()
    {
        DeathMenu.SetActive(true);
        GameManager.Instance.ChangeState(new DeathState());
    }
    public void Resume()
    {
        DeathMenu.SetActive(false);
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
