/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class displaymaterial : MonoBehaviour
{
    public GameObject emptymaterial;
    private GameObject[] models;     // �洢��ģ�͵�����
    private int currentModelIndex;   // ��ǰչʾ����ģ�͵��±�

    // Start is called before the first frame update
    void Start()
    {
        models = new GameObject[emptymaterial.transform.childCount]; // ��ʼ�������СΪ��ģ������
        for (int i = 0; i < models.Length; i++) // ������ģ�ͣ�����洢�������в���������Ϊ���ɼ�
        {
            models[i] = emptymaterial.transform.GetChild(i).gameObject;
            models[i].SetActive(false);
        }
        currentModelIndex = 0; // ��ʼ����ǰչʾ����ģ���±�Ϊ0

        UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    // Update is called once per frame
    void DataReceived(string data, UduinoDevice board)
    {
        if (data == "1") // �����յ�1ʱ
        {
            models[currentModelIndex].SetActive(false); // ����ǰ��ģ������Ϊ���ɼ�
            currentModelIndex++; // ��ģ���±��1
            if (currentModelIndex >= models.Length) // ����±곬�����鷶Χ����������Ϊ0
            {
                currentModelIndex = 0;
            }
            models[currentModelIndex].SetActive(true); // ����һ����ģ������Ϊ�ɼ�
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
            // ������յ��ĵ�һ������Ϊ"1"
            if (dataArray[0] == "1")
            {
                // �����ǰ������display materials����
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
            // ������յ��ĵڶ�������Ϊ"1"
            if (dataArray[1] == "1")
            {
                // �л�����
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

