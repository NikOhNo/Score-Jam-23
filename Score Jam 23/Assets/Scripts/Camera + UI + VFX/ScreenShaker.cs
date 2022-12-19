using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    public static ScreenShaker instance;

    CinemachineVirtualCamera cam;
    CinemachineBasicMultiChannelPerlin shaker;
    float remainingShakeTime = 0f;

    private void Start()
    {
        instance = this;
        cam = GetComponent<CinemachineVirtualCamera>();
        shaker = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (remainingShakeTime > 0)
        {
            remainingShakeTime -= Time.deltaTime;

            if (remainingShakeTime <= 0)
            {
                StopShaking();
            }
        }

    }

    private void StopShaking()
    {
        shaker.m_AmplitudeGain = 0f;
        shaker.m_FrequencyGain = 0f;
        remainingShakeTime = 0f;
    }

    public void ShakeCamera(float frequency, float amplitude, float time)
    {
        shaker.m_FrequencyGain = frequency;
        shaker.m_AmplitudeGain = amplitude;
        remainingShakeTime = time;
    }
}
