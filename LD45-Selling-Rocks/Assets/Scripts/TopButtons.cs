using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopButtons : MonoBehaviour
{
    public static TopButtons instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    private Button waterButton;
    [SerializeField]
    private Button oxygenButton;
    [SerializeField]
    private Button temperatureButton;
    [SerializeField]
    private Button pressureButton;
    [SerializeField]
    private float m_buttonsChangeTime = 1f;

    private void Start()
    {
        StartCoroutine(AutoResetButtons());
    }

    public void ResetButtons()
    {
        int random = Random.Range(0, 6);
        switch (random)
        {
            case 0:
                waterButton.interactable = true;
                oxygenButton.interactable = true;
                temperatureButton.interactable = false;
                pressureButton.interactable = false;
                break;
            case 1:
                waterButton.interactable = true;
                oxygenButton.interactable = false;
                temperatureButton.interactable = true;
                pressureButton.interactable = false;
                break;
            case 2:
                waterButton.interactable = true;
                oxygenButton.interactable = false;
                temperatureButton.interactable = false;
                pressureButton.interactable = true;
                break;
            case 3:
                waterButton.interactable = false;
                oxygenButton.interactable = true;
                temperatureButton.interactable = true;
                pressureButton.interactable = false;
                break;
            case 4:
                waterButton.interactable = false;
                oxygenButton.interactable = true;
                temperatureButton.interactable = false;
                pressureButton.interactable = true;
                break;
            case 5:
                waterButton.interactable = false;
                oxygenButton.interactable = false;
                temperatureButton.interactable = true;
                pressureButton.interactable = true;
                break;
            default:
                waterButton.interactable = false;
                oxygenButton.interactable = true;
                temperatureButton.interactable = false;
                pressureButton.interactable = true;
                break;
        }
    }

    IEnumerator AutoResetButtons()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_buttonsChangeTime);
            ResetButtons();
        }
    }
}
