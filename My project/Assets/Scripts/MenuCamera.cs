using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuCamera : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public SpriteRenderer fadeImage;
    public float fadeSpeed = 2f;
    private Quaternion targetRotation;
    private bool fading = false;
    void Start()
    {
        targetRotation = transform.rotation;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1.85f);
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;
    }
    void Update()
    {
        Vector3 position = transform.position;
        position.z = -1.85f;
        transform.position = position;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
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
        targetRotation = Quaternion.Euler(0f, 90f, 0f);
    }
    public void GoToHowToPlay()
    {
        targetRotation = Quaternion.Euler(0f, -90f, 0f);
    }
    public void GoToLeaderboard()
    {
        targetRotation = Quaternion.Euler(-90f, 0f, 0f);
    }
    public void GoToMainMenu()
    {
        targetRotation = Quaternion.Euler(0f, 0f, 0f);
    }
    public void NextScene()
    {
        fading = true;
    }
}