using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerProp : MonoBehaviour
{
    public float energyCollectSpeed = 1f;

    public static GameManagerProp instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
}
