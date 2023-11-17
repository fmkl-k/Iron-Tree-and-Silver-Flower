using UnityEngine;

public class fireworkcolorcontroller : MonoBehaviour
{
    public ParticleSystem firework;


    private void Start()
    {
        string visibleChildIndex = PlayerPrefs.GetString("visibleChildIndices");
        Color particleColor = Color.white;

        if (visibleChildIndex == "0")
        {
            
            particleColor = new Color(239f / 255f, 97f / 255f, 89f / 255f);
        }
        else if (visibleChildIndex == "1")
        {
            
            particleColor = new Color(100f / 255f, 243f / 255f, 184f / 255f);
        }
        else if (visibleChildIndex == "2")
        {
            
            particleColor = new Color(239f / 255f, 141f / 255f, 236f / 255f);
        }
        else if (visibleChildIndex == "3")
        {
            
            particleColor = new Color(135f / 255f, 231f / 255f, 8f / 255f);
        }
        else if (visibleChildIndex == "4")
        {
            
            particleColor = new Color(231f / 255f, 220f / 255f, 115f / 255f);
        }
        else
        {
            Debug.LogError("Invalid visible child index");
        }

        var main = firework.main;
        main.startColor = particleColor;
    }
    



}
