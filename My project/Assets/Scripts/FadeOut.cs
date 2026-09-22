using UnityEngine;
public class FadeOut : MonoBehaviour
{
    public SpriteRenderer fadeImage;
    public float fadeSpeed = 2f;
    void Start()
    {
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;
    }

    void Update()
    {
        Color color = fadeImage.color;
        color.a -= fadeSpeed * Time.deltaTime;
        fadeImage.color = color;
        if (color.a <= 0f)
        {
            color.a = 0f;
            fadeImage.color = color;
        }
    }
}