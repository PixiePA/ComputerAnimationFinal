using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    private Light[] allLights;
    public Color lightColor;
    public float intensity;
    // Start is called before the first frame update
    private void Awake()
    {
        allLights = GetComponentsInChildren<Light>();    
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Light light in allLights)
        {
            light.color = lightColor;
            light.intensity = intensity;
        }
    }
}
