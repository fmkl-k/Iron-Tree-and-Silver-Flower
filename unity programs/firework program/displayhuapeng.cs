using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayhuapeng : MonoBehaviour
{
    public GameObject empty;

    private void Start()
    {
        string visiblehuapengmen = PlayerPrefs.GetString("visiblehuapengs");
        int index = int.Parse(visiblehuapengmen);

        for (int i = 0; i < empty.transform.childCount; i++)
        {
            GameObject child = empty.transform.GetChild(i).gameObject;
            if (i == index)
            {
                child.SetActive(true);
            }
            else
            {
                child.SetActive(false);
            }
        }
    }

}
