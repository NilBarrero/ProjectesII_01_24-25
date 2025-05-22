using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float shakeDuration = 1f;
    public float shakeAmplitude = 2f;
    public float shakeFrequency = 2f;

    private float shakeTimer;
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
                // Stopping the shake
                perlinNoise.m_AmplitudeGain = 0f;
                perlinNoise.m_FrequencyGain = 0f;
            }
        }

        StartShake();
    }
}
