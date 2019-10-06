using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerProp : MonoBehaviour
{
    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip buttonClickAudio;
    public AudioClip probeShotAudio;
    public AudioClip endTimerAudio;

    [Header("Main")]

    public float energyCollectSpeed = 1f;

    public int biomass = 1;
    public float time = 5;
    public int energy = 0;
    public int temperature = 0;
    public int water = 0;
    public int oxygen = 0;
    public int pressure = 0;

    public int targetTemperature;
    public int targetWater;
    public int targetOxygen;
    public int targetPressure;

    [Header("Probe")]
    public Transform shotPoint;
    public GameObject probePrefab;

    [Header("End")]
    public GameObject endPanel;
    public Text endText;

    public static GameManagerProp instance { get; private set; }

    private bool isEnd = false;

    private void Awake()
    {
        instance = this;
        StartCoroutine(RandomFlukePressure());
        StartCoroutine(RandomFlukeTemperature());
        StartCoroutine(RandomFlukeOxygen());
        StartCoroutine(RandomFlukeHydrogen());
        targetTemperature = Random.Range(50, 151);
        targetWater = Random.Range(2500, 7501);
        targetOxygen = Random.Range(25, 76);
        targetPressure = Random.Range(500, 1501);
    }

    private void Update()
    {
        if (time <= 0f && !isEnd)
        {
            isEnd = true;
            audioSource.PlayOneShot(endTimerAudio);

            float temperatureScore = 1f - (float)Mathf.Abs(temperature - targetTemperature) / 200f;
            print("TEMP: " + temperatureScore);
            float waterScore = 1f - (float)Mathf.Abs(water - targetWater) / 10000f;
            print("Water: " + waterScore);
            float oxygenScore = 1f - (float)Mathf.Abs(oxygen - targetOxygen) / 100f;
            print("oxy: " + oxygenScore);
            float pressureScore = 1f - (float)Mathf.Abs(pressure - targetPressure) / 2000f;
            print("press: " + pressureScore);
            float score = 1000 * (temperatureScore + waterScore + pressureScore + oxygenScore);
            print("total : " + score);
            Time.timeScale = 0f;
            endPanel.SetActive(true);
            endText.text = "Score : " + score.ToString("0");
        }
        else
        {
            float temperatureScore = 1f - (float)Mathf.Abs(temperature - targetTemperature) / 200f;
            float waterScore = 1f - (float)Mathf.Abs(water - targetWater) / 10000f;
            float oxygenScore = 1f - (float)Mathf.Abs(oxygen - targetOxygen) / 100f;
            float pressureScore = 1f - (float)Mathf.Abs(pressure - targetPressure) / 2000f;
            float biomassFloat = 1000f * (temperatureScore + waterScore + pressureScore + oxygenScore);
            biomass = (int)biomassFloat;
        }
    }

    public bool EnoughEnergy(int neededValue)
    {
        if (energy >= neededValue) return true;
        else return false;
    }

    IEnumerator RandomFlukePressure()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.6f);
            pressure += Random.Range(-1, 2);
        }
    }
    IEnumerator RandomFlukeOxygen()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            oxygen += Random.Range(-1, 2);
        }
    }
    IEnumerator RandomFlukeTemperature()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            temperature += Random.Range(-1, 2);
        }
    }
    IEnumerator RandomFlukeHydrogen()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            water += Random.Range(-1, 2);
        }
    }

    public void CreateProbe()
    {
        audioSource.PlayOneShot(probeShotAudio);
        var newProbe = Instantiate(probePrefab, shotPoint.position, Quaternion.identity, null);
    }
}
