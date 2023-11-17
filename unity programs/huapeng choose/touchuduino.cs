using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class touchuduino : MonoBehaviour
{
    //public Text QWQ;
    public GameObject empty;
    private GameObject[] models;     // 存储子模型的数组
    private int currentModelIndex;   // 当前展示的子模型的下标
    private bool isScene2Active = true;


    // Start is called before the first frame update
    void Start()
    {
        models = new GameObject[empty.transform.childCount]; // 初始化数组大小为子模型数量
        for (int i = 0; i < models.Length; i++) // 遍历子模型，将其存储到数组中并将其设置为不可见
        {
            models[i] = empty.transform.GetChild(i).gameObject;
            models[i].SetActive(false);
        }
        currentModelIndex = 0; // 初始化当前展示的子模型下标为0

        UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    void DataReceived(string data, UduinoDevice board)
    {
        string[] dataArray = data.Split(',');

        if (dataArray.Length == 7)
        {
            // 如果接收到的第一个数据为"1"
            if (dataArray[0] == "1")
            {
                // 如果当前场景是display materials场景
                if (isScene2Active)
                {
                    models[currentModelIndex].SetActive(false);
                    currentModelIndex++;
                    if (currentModelIndex >= models.Length)
                    {
                        currentModelIndex = 0;
                    }
                    models[currentModelIndex].SetActive(true);
                }
            }
            if (dataArray[1] == "1")
            {
                // 切换场景
                if (isScene2Active)
                {
                    SceneManager.LoadScene("display materials");
                    isScene2Active = false;
                }
                else
                {
                    SceneManager.LoadScene("display materials");
                    isScene2Active = true;
                }
            }

            Debug.Log(data);
        }
    }

}
