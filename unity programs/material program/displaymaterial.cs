/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class displaymaterial : MonoBehaviour
{
    public GameObject emptymaterial;
    private GameObject[] models;     // 存储子模型的数组
    private int currentModelIndex;   // 当前展示的子模型的下标

    // Start is called before the first frame update
    void Start()
    {
        models = new GameObject[emptymaterial.transform.childCount]; // 初始化数组大小为子模型数量
        for (int i = 0; i < models.Length; i++) // 遍历子模型，将其存储到数组中并将其设置为不可见
        {
            models[i] = emptymaterial.transform.GetChild(i).gameObject;
            models[i].SetActive(false);
        }
        currentModelIndex = 0; // 初始化当前展示的子模型下标为0

        UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    // Update is called once per frame
    void DataReceived(string data, UduinoDevice board)
    {
        if (data == "1") // 当接收到1时
        {
            models[currentModelIndex].SetActive(false); // 将当前子模型设置为不可见
            currentModelIndex++; // 子模型下标加1
            if (currentModelIndex >= models.Length) // 如果下标超出数组范围，则将其重置为0
            {
                currentModelIndex = 0;
            }
            models[currentModelIndex].SetActive(true); // 将下一个子模型设置为可见
        }

        Debug.Log(data);
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Uduino;

public class displaymaterial : MonoBehaviour
{
    public GameObject emptymaterial;
    private GameObject[] models;
    public int currentModelIndex;
    private bool isScene1Active = true;

    // Start is called before the first frame update
    void Start()
    {
        models = new GameObject[emptymaterial.transform.childCount];
        for (int i = 0; i < models.Length; i++)
        {
            models[i] = emptymaterial.transform.GetChild(i).gameObject;
            models[i].SetActive(false);
        }
        currentModelIndex = 0;
        UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    // Update is called once per frame
    void DataReceived(string data, UduinoDevice board)
    {
        string[] dataArray = data.Split(',');
        if (dataArray.Length == 7)
        {
            // 如果接收到的第一个数据为"1"
            if (dataArray[0] == "1")
            {
                // 如果当前场景是display materials场景
                if (isScene1Active)
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
            // 如果接收到的第二个数据为"1"
            if (dataArray[1] == "1")
            {
                // 切换场景
                if (isScene1Active)
                {
                    SceneManager.LoadScene("flame scene");
                    isScene1Active = false;
                }
                else
                {
                    SceneManager.LoadScene("display materials");
                    isScene1Active = true;
                }
            }
        }
    }
}

