using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaleManager : MonoBehaviour
{
    public UIScale temperature; 
    public UIScale water;
    public UIScale oxygen;
    public UIScale pressure;

    public static UIScaleManager instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        temperature.SetBlockValue(UIScaleCalculator.TemperatureScale(GameManagerProp.instance.temperature));
        water.SetBlockValue(UIScaleCalculator.WaterScale(GameManagerProp.instance.water));
        oxygen.SetBlockValue(UIScaleCalculator.OxygenScale(GameManagerProp.instance.oxygen));
        pressure.SetBlockValue(UIScaleCalculator.PressureScale(GameManagerProp.instance.pressure));
    }
}
