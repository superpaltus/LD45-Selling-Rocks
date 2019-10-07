using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void ExitTutorial()
    {
        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }
}
