using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftInfoGroupProp : MonoBehaviour
{
    //public static LeftInfoGroupProp instance { get; private set; }

    //private void Awake()
    //{
    //    instance = this;
    //}

    [SerializeField]
    private Text txtPlanetName;
    [SerializeField]
    private Text txtTemperature;
    [SerializeField]
    private Text txtWater;
    [SerializeField]
    private Text txtOxygen;
    [SerializeField]
    private Text txtPressure;

    private void Start()
    {
        txtPlanetName.text = "T - " + Random.Range(1100, 5000).ToString("0");
    }

    private void Update()
    {
        txtTemperature.text = (GameManagerProp.instance.temperature - 100).ToString("0") + " (°C)";
        txtWater.text = GameManagerProp.instance.water + " (M)";
        txtOxygen.text = GameManagerProp.instance.oxygen + " (PPM)";
        txtPressure.text = GameManagerProp.instance.pressure + " (MMHG)";
    }
}
