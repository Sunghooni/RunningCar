using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLamp : MonoBehaviour
{
    public Light light;
    public float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2.2f && timer < 2.25f)
        {
            light.intensity = 0;
        }
        else if (timer > 2.25f && timer < 2.4f)
        {
            light.intensity = 3;
        }
        else if (timer > 2.4f && timer < 2.5f)
        {
            light.intensity = 0;
        }
        else if (timer > 2.5f)
        {
            light.intensity = 3;
            timer = 0;
        }
    }
}
