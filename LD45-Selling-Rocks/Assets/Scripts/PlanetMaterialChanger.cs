using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMaterialChanger : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    private void Start()
    {
        if (materials.Length > 0)
        {
            int index = Random.Range(0, materials.Length);
            GetComponent<Renderer>().material = materials[index];
        }
    }
}
