using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light pointLight;
    public float intensityChangeAmount = 1.0f;
    bool isOn = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;

            if(isOn){
                pointLight.intensity = 20;
            } else {
                pointLight.intensity = 0;
            }
        }
    }

    // Função para aumentar a intensidade da luz
    private void IncreaseIntensity()
    {
        pointLight.intensity += intensityChangeAmount;
    }

    // Função para diminuir a intensidade da luz
    private void DecreaseIntensity()
    {
        pointLight.intensity -= intensityChangeAmount;
        if (pointLight.intensity < 0)
        {
            pointLight.intensity = 0;
        }
    }
}
