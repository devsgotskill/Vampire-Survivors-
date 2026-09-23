using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0.8f);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}
