using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LCPrinter;

public class printsomescreenshot : MonoBehaviour
{
    public GameObject m_collider;

    public float parTimer;
    public float parTime = 5f;

    string fileName = Application.streamingAssetsPath + "/photo.jpg";

    string fileNameer;

    private int count = 0;
    private int countsome = 0;



    private bool isScan = false;

    public string printerName = "HP DJ 2130 series";
    public int copies = 1;

    void Start()
    {
        
    }

    public void CaptureScreenByRT(Camera camera)
    {
        fileNameer = DateTime.Now.ToString("yyyyMMddHHmmssffff");
        fileName = Application.streamingAssetsPath + "/" + fileNameer + "photo.jpg";
        Rect rect = new Rect(0, 0, 1600, 1024);
        // ����һ��RenderTexture����  
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);
        // ��ʱ������������targetTextureΪrt, ���ֶ���Ⱦ������  
        camera.targetTexture = rt;
        camera.Render();
        // �������rt, �������ж�ȡ���ء�  
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGBA32, false);

        // ע�����ʱ�����Ǵ�RenderTexture.active�ж�ȡ���� 
        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();
        // ������ز�������ʹ��camera��������Ļ����ʾ  
        camera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(rt);
        // �����Щ�������ݣ���һ��pngͼƬ�ļ�  
        byte[] bytes = screenShot.EncodeToPNG();


        Print.PrintTexture(screenShot.EncodeToPNG(), copies, printerName);

        Debug.LogError(Application.streamingAssetsPath);
        System.IO.File.WriteAllBytes(fileName, bytes);
    }

    private void Update()
    {
        if (isScan)
        {
            parTimer += Time.deltaTime;
            if (parTimer >= parTime)
            {
                m_collider.gameObject.SetActive(true);
                parTimer = 0;
                isScan = false;
            }
        }
    }

    private IEnumerator DelayedCapture()
    {
        yield return new WaitForSeconds(0.15f);
        CaptureScreenByRT(Camera.main);
    }

    void OnParticleCollision(GameObject go)
    {

        Debug.Log("�����ӷ����Ӵ�");

        if (!isScan & count<2)
        { 
            count++;
            StartCoroutine(DelayedCapture());
            //CaptureScreenByRT(Camera.main);
            m_collider.gameObject.SetActive(false);
            isScan = true;
        }
        if (!isScan & count >= 2)
        {
            count++;
            //StartCoroutine(DelayedCapture());
            //CaptureScreenByRT(Camera.main);
            m_collider.gameObject.SetActive(false);
            isScan = true;
        }

        //count++;
        if (count >= 10)
        {


#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }
        else
        {
            //CaptureScreenByRT(Camera.main);
        }



    }

}
