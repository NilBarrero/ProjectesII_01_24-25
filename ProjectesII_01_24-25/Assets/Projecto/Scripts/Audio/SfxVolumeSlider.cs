using UnityEngine;
using UnityEngine.UI; // Aseg�rate de tener la referencia al UI

public class SfxVolumeSlider : MonoBehaviour
{
    public Slider sfxSlider; // El slider para ajustar el volumen de SFX

    private void Start()
    {
        // Configura el slider al valor actual del volumen
        sfxSlider.value = AudioManager.instance.GetSFXVolume();

        // Conecta el evento On Value Changed con la funci�n SetSFXVolume
        sfxSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    // Este m�todo se llama cuando el valor del slider cambia
    private void OnSliderValueChanged(float value)
    {
        // Cambiar el volumen de los efectos de sonido
        AudioManager.instance.SetSFXVolume(value);
    }
}
