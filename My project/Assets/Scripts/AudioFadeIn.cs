using UnityEngine;
public class AudioFadeIn : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeSpeed = 1f;
    private float targetVolume;
    void Start()
    {
        targetVolume = audioSource.volume;
        audioSource.volume = 0f;
        audioSource.Play();
    }
    void Update()
    {
        if (audioSource.volume < targetVolume)
        {
            audioSource.volume += fadeSpeed * Time.deltaTime;

            if (audioSource.volume >= targetVolume)
            {
                audioSource.volume = targetVolume;
            }
        }
    }
}