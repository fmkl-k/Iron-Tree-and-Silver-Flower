using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class huapengchoosecontroller : MonoBehaviour
{
    private static huapengchoosecontroller instance;
    private List<int> visibleChildIndices = new List<int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 保留物体引用
        }
        else
        {
            Destroy(gameObject); // 如果物体已经存在，则销毁当前的物体
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
        if (scene.name == "firework scene")
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
            // 存储可见子对象的索引到PlayerPrefs
            int lastpeng = visibleChildIndices.Count - 1;
            string pengString = lastpeng >= 0 ? visibleChildIndices[lastpeng].ToString() : "";
            PlayerPrefs.SetString("visiblehuapengs", pengString);
            PlayerPrefs.Save();
        }
    }

}
