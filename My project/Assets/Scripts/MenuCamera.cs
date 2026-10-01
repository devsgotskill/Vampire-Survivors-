using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
public class MenuCamera : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mainMenuPosition = 0f;
    public float optionsPosition = 10f;
    public float howToPlayPosition = -10f;
    public float leaderboardPosition = 20f;
    public SpriteRenderer fadeImage;
    public float fadeSpeed = 2f;
    private float targetX;
    private float targetY;
    private bool fading = false;
    void Start()
    {
        targetX = transform.position.x;
        targetY = transform.position.y;
        Vector3 position = transform.position;
        position.z = -1.85f;
        transform.position = position;
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;
    }
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Lerp(position.x, targetX, moveSpeed * Time.deltaTime);
        position.y = Mathf.Lerp(position.y, targetY, moveSpeed * Time.deltaTime);
        position.z = -1.85f;
        transform.position = position;
        if (fading)
        {
            Color color = fadeImage.color;
            color.a += fadeSpeed * Time.deltaTime;
            fadeImage.color = color;
            if (color.a >= 1f)
            {
                color.a = 1f;
                fadeImage.color = color;
                SceneManager.LoadScene("Game");
            }
        }
    }
    public void GoToOptions()
    {
        targetX = optionsPosition;
    }
    public void GoToHowToPlay()
    {
        targetX = howToPlayPosition;
    }
    public void GoToLeaderboard()
    {
        targetY = leaderboardPosition;
    }
    public void GoToMainMenu()
    {
        targetX = mainMenuPosition;
    }
    public void NextScene()
    {
        fading = true;
    }
}