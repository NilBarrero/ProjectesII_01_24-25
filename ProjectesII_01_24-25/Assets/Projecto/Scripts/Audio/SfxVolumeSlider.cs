using UnityEngine;
using UnityEngine.UI; // Make sure you have a reference to the UI

public class SfxVolumeSlider : MonoBehaviour
{
    public Slider sfxSlider; // The slider to adjust the SFX volume

    private void Start()
    {
        // Set the slider to the current volume value
        sfxSlider.value = AudioManager.instance.GetSFXVolume();

        // Connect the On Value Changed event to the SetSFXVolume function
        sfxSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    // This method is called when the slider value changes
    private void OnSliderValueChanged(float value)
    {
        // Change the sound effects volume
        AudioManager.instance.SetSFXVolume(value);
    }
}

