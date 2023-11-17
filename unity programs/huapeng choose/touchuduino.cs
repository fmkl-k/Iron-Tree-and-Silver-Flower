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
    private GameObject[] models;     // �洢��ģ�͵�����
    private int currentModelIndex;   // ��ǰչʾ����ģ�͵��±�
    private bool isScene2Active = true;


    // Start is called before the first frame update
    void Start()
    {
        models = new GameObject[empty.transform.childCount]; // ��ʼ�������СΪ��ģ������
        for (int i = 0; i < models.Length; i++) // ������ģ�ͣ�����洢�������в���������Ϊ���ɼ�
        {
            models[i] = empty.transform.GetChild(i).gameObject;
            models[i].SetActive(false);
        }
        currentModelIndex = 0; // ��ʼ����ǰչʾ����ģ���±�Ϊ0

        UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    void DataReceived(string data, UduinoDevice board)
    {
        string[] dataArray = data.Split(',');

        if (dataArray.Length == 7)
        {
            // ������յ��ĵ�һ������Ϊ"1"
            if (dataArray[0] == "1")
            {
                // �����ǰ������display materials����
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
                // �л�����
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
