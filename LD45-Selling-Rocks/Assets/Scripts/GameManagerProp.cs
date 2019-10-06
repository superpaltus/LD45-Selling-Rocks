using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerProp : MonoBehaviour
{
    public float energyCollectSpeed = 1f;

    public int energy = 0;
    public int temperature = 0;
    public int water = 0;
    public int oxygen = 0;
    public int pressure = 0;

    public static GameManagerProp instance { get; private set; }

    private void Awake()
    {
        instance = this;
        StartCoroutine(RandomFlukePressure());
        StartCoroutine(RandomFlukeTemperature());
        StartCoroutine(RandomFlukeOxygen());
        StartCoroutine(RandomFlukeHydrogen());

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

}
