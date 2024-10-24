using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnvironmentManager : MonoBehaviour
{
    [Header("Light Objects")]
    [SerializeField] private Light2D mainLight;

    [Header("Light Settings")]
    [SerializeField] private float minimNightLight = 0.04f;

    [Header("Day Settings")]
    [SerializeField] private float dayTimeMinutes = 1f;
    private float dayTimeSeconds;

    [Header("Time Settings")]
    [SerializeField] private float secondsInSeconds = 1f;
    [SerializeField] private float addToSeconds = 1f;
    private float currentTimeSeconds = 0f;

    private void Start()
    {
        dayTimeSeconds = dayTimeMinutes * 60;
        mainLight.intensity = 1;
        StartCoroutine(CountTime());
    }

    private IEnumerator CountTime()
    {
        yield return new WaitForSeconds(secondsInSeconds);

        if (currentTimeSeconds >= dayTimeMinutes * 60)
        {
            currentTimeSeconds = 0;
        }

        currentTimeSeconds += addToSeconds;

        Debug.Log(currentTimeSeconds);
        StartCoroutine(CountTime());
    }

    void FixedUpdate()
    {
        ControlTime();
    }

    private void ControlTime()
    {
        if (currentTimeSeconds >= dayTimeSeconds * 0.4f && currentTimeSeconds <= dayTimeSeconds * 0.5f)
        {
            StartNight();
        }
        else if (currentTimeSeconds >= dayTimeSeconds * 0.9f && currentTimeSeconds <= dayTimeSeconds)
        {
            StartDay();
        }
    }

    private void StartNight()
    {
        float intendedIntensity = dayTimeSeconds * 0.1f;
        float currentIntensity = dayTimeSeconds * 0.5f - currentTimeSeconds;

        float intensity = currentIntensity / intendedIntensity;

        if (intensity < 0.05f)
        {
            intensity = minimNightLight;
        }

        mainLight.intensity = intensity;
    }

    private void StartDay()
    {
        float intendedIntensity = dayTimeSeconds * 0.1f;
        float currentIntensity = currentTimeSeconds - dayTimeSeconds * 0.9f;

        float intensity = currentIntensity / intendedIntensity;

        if (intensity < 0.05f)
        {
            intensity = minimNightLight;
        }
        else if( intensity > 0.95f)
        {
            intensity = 1;
        }

        mainLight.intensity = intensity;
    }
}
