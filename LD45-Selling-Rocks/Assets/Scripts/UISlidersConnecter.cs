using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlidersConnecter : MonoBehaviour
{
    [SerializeField]
    private Slider sliderNitrogen;
    [SerializeField]
    private Slider sliderOxygen;
    [SerializeField]
    private Slider sliderTemperature;
    [SerializeField]
    private Slider sliderHydrogen;

    public static UISlidersConnecter instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        sliderNitrogen.value = 0f;
        sliderOxygen.value = 0f;
        sliderTemperature.value = 0f;
        sliderHydrogen.value = 0f;
    }

    #region SlidersChange
    public void ChangeNitrogen(float settingValue)
    {
        sliderNitrogen.value = Mathf.Clamp01(settingValue/100f);
    }

    public void ChangeOxygen(float settingValue)
    {
        sliderOxygen.value = Mathf.Clamp01(settingValue / 100f);
    }

    public void ChangeTemperature(float settingValue)
    {
        sliderTemperature.value = Mathf.Clamp01(settingValue / 100f);
    }

    public void ChangeHydrogen(float settingValue)
    {
        sliderHydrogen.value = Mathf.Clamp01(settingValue / 100f);
    }
    #endregion
}
