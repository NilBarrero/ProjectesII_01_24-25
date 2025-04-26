using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Reference to the virtual camera
    public float shakeDuration = 1f; // Duration of the shake in seconds
    public float shakeAmplitude = 2f; // Amplitude of the shake
    public float shakeFrequency = 2f; // Frequency of the shake

    private float shakeTimer; // Internal timer
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
                // Stop the shake
                perlinNoise.m_AmplitudeGain = 0f;
                perlinNoise.m_FrequencyGain = 0f;
            }
        }

        StartShake();
    }
}
