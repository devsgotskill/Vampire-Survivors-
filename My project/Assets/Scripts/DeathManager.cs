using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathManager : MonoBehaviour
{
    public GameObject DeathMenu;
    public TextMeshProUGUI scoreText;
    public int playerHealth;
    public TMP_InputField nameInput;
    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerObject.GetComponent<Player>().health;

        if (playerHealth <= 0)
        {
            if (GameManager.Instance.IsPlaying())
            {
                Dead();
            }
        }
    }
    public void Dead()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerXp playerXp = playerObject.GetComponent<PlayerXp>();

        scoreText.text = "Score: " + playerXp.totalXP;

        DeathMenu.SetActive(true);
        GameManager.Instance.ChangeState(new DeathState());
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void SubmitScore()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerXp playerXp = playerObject.GetComponent<PlayerXp>();
        string playerName = nameInput.text;

        if (playerName == "")
        {
            return;
        }
        LeaderboardManager.Instance.AddScore(playerName, playerXp.totalXP);
        SceneManager.LoadScene("Menu");
    }
}