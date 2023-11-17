using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Readhcsr05 : MonoBehaviour
{
    public Text qaq;

    public ParticleSystem flame;
    private ParticleSystem.LightsModule lightsModule;

    private bool isScene0Active = true;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.OnDataReceived += DataReceived; 
    }

    void DataReceived(string data,UduinoDevice board)
    {
        Debug.Log(data);

        string[] dataArray = data.Split(',');

        lightsModule = flame.lights;

        float distance = float.Parse(dataArray[2]);

        if (distance >= 0 && distance <= 55)
        {
            if (isScene0Active)
            {
            // Map the distance to the range of 800-1600
            float mappedDistance = Mathf.Lerp(800, 1600, distance / 55f);

            float mappedIntensity = Mathf.Lerp(1, 5, distance / 55f);

            // Update the Text component with the mapped distance and the unit "¡æ"
            qaq.text = mappedDistance.ToString("F0") + "¡æ";

            lightsModule.intensityMultiplier = mappedIntensity;
            }
        }

        if (distance > 55)
        {
            // Update the Text component with the received distance and the unit "cm"
            //qaq.text = distance.ToString("F0") + "cm";

            //lightsModule.intensityMultiplier = 0;
            if (isScene0Active)
            {
                SceneManager.LoadScene("firework scene");
                isScene0Active = false;
            }
            else
            {
                SceneManager.LoadScene("flame scene");
                isScene0Active = true;
            }

        }
    }


}
