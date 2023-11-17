/*using UnityEngine.SceneManagement;
using UnityEngine;

public class EmptyMaterialController : MonoBehaviour
{
    private static EmptyMaterialController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ������������
        }
        else
        {
            Destroy(gameObject); // ��������Ѿ����ڣ������ٵ�ǰ������
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "flame scene")
        {


            // �ڵڶ����������ҵ�emptymaterialnew�����壬��������transform���Ե�ֵ��ֵ��emptymaterial������
            GameObject emptyMaterialNewObj = GameObject.Find("emptymaterialnew");
            if (emptyMaterialNewObj != null)
            {
                Transform emptyMaterialTransform = GetComponent<Transform>();
                emptyMaterialTransform.position = emptyMaterialNewObj.transform.position;
                emptyMaterialTransform.rotation = emptyMaterialNewObj.transform.rotation;
                emptyMaterialTransform.localScale = emptyMaterialNewObj.transform.localScale;
            }
        }
    }
}*/

using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EmptyMaterialController : MonoBehaviour
{
    private static EmptyMaterialController instance;
    private List<int> visibleChildIndices = new List<int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ������������
        }
        else
        {
            Destroy(gameObject); // ��������Ѿ����ڣ������ٵ�ǰ������
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "flame scene")
        {
            visibleChildIndices.Clear();
            Transform emptyMaterialTransform = transform;
            int childCount = emptyMaterialTransform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform childTransform = emptyMaterialTransform.GetChild(i);
                if (childTransform.gameObject.activeInHierarchy)
                {
                    visibleChildIndices.Add(i);
                }
            }
            // �洢�ɼ��Ӷ����������PlayerPrefs
            int lastIndex = visibleChildIndices.Count - 1;
            string indexString = lastIndex >= 0 ? visibleChildIndices[lastIndex].ToString() : "";
            PlayerPrefs.SetString("visibleChildIndices", indexString);
            PlayerPrefs.Save();
        }
    }
}

