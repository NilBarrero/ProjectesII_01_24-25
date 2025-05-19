using UnityEngine;
using UnityEngine.UI; 

public class SfxVolumeSlider : MonoBehaviour
{
    public Slider sfxSlider; 

    private void Start()
    {
        sfxSlider.value = AudioManager.instance.GetSFXVolume();
 
        sfxSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        AudioManager.instance.SetSFXVolume(value);
    }
}

