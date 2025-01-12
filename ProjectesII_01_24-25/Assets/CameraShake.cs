using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Referencia a la cámara virtual
    public float shakeDuration = 1f; // Duración de la vibración en segundos
    public float shakeAmplitude = 2f; // Intensidad de la vibración
    public float shakeFrequency = 2f; // Frecuencia de la vibración

    private float shakeTimer; // Temporizador interno
    private CinemachineBasicMultiChannelPerlin perlinNoise;

    void Start()
    {
        if (virtualCamera != null)
        {
            perlinNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }

    public void StartShake()
    {
        if (perlinNoise != null)
        {
            perlinNoise.m_AmplitudeGain = shakeAmplitude;
            perlinNoise.m_FrequencyGain = shakeFrequency;
            shakeTimer = shakeDuration;
        }
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0 && perlinNoise != null)
            {
                // Detener la vibración
                perlinNoise.m_AmplitudeGain = 0f;
                perlinNoise.m_FrequencyGain = 0f;
            }
        }

       
            StartShake();

    }
}
