using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    private string sliderPrefKey = "SliderValue";

    public void playSound(AudioSource asa)
    {
        asa.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(sliderPrefKey, 0.5f);
        AudioListener.volume = volumeSlider.value;
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat(sliderPrefKey, volumeSlider.value);
        PlayerPrefs.Save();
    }
}
