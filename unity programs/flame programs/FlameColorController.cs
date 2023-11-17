/*using UnityEngine;

public class FlameColorController : MonoBehaviour
{
    private ParticleSystem flame;
    private EmptyMaterialController emptyMaterialController;
    private int lastChildIndex = -1;

    public Color[] colors = new Color[] { new Color(0xEF, 0x61, 0x59), new Color(0x64, 0xF3, 0xB8), new Color(0xEF, 0x8D, 0xEC), new Color(0x87, 0xE7, 0x08), new Color(0xE7, 0xDC, 0x73) };

    private void Awake()
    {
        flame = GetComponent<ParticleSystem>();
        emptyMaterialController = FindObjectOfType<EmptyMaterialController>();
    }

    private void Update()
    {
        int currentChildIndex = emptyMaterialController.GetCurrentChildIndex();
        if (currentChildIndex != lastChildIndex)
        {
            lastChildIndex = currentChildIndex;
            if (currentChildIndex >= 0 && currentChildIndex < colors.Length)
            {
                var main = flame.main;
                main.startColor = colors[currentChildIndex];
            }
        }
    }
}*/

/*using UnityEngine;

public class FlameColorController : MonoBehaviour
{
    private ParticleSystem flame;
    private int lastChildIndex = -1;

    public Color[] colors = new Color[] { new Color(0xEF, 0x61, 0x59), new Color(0x64, 0xF3, 0xB8), new Color(0xEF, 0x8D, 0xEC), new Color(0x87, 0xE7, 0x08), new Color(0xE7, 0xDC, 0x73) };

    private void Awake()
    {
        flame = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        GameObject emptyMaterialObj = GameObject.Find("emptymaterialnew"); // 获取 emptymaterialnew 对象
        if (emptyMaterialObj != null)
        {
            Transform currentChild = null;
            foreach (Transform child in emptyMaterialObj.transform)
            {
                if (child.gameObject.activeInHierarchy) // 判断子物体是否处于激活状态
                {
                    currentChild = child;
                    break;
                }
            }

            if (currentChild != null)
            {
                int currentChildIndex = currentChild.GetSiblingIndex();
                if (currentChildIndex != lastChildIndex)
                {
                    lastChildIndex = currentChildIndex;
                    if (currentChildIndex >= 0 && currentChildIndex < colors.Length)
                    {
                        var main = flame.main;
                        main.startColor = colors[currentChildIndex];
                    }
                }
            }
        }
    }
}*/

/*using UnityEngine;

public class FlameColorController : MonoBehaviour
{
    private ParticleSystem flame;
    private int lastChildIndex = -1;

    public Color[] colors = new Color[] { new Color(0xEF, 0x61, 0x59), new Color(0x64, 0xF3, 0xB8), new Color(0xEF, 0x8D, 0xEC), new Color(0x87, 0xE7, 0x08), new Color(0xE7, 0xDC, 0x73) };

    private void Awake()
    {
        flameParticle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        GameObject emptyMaterialObj = GameObject.Find("emptymaterialnew"); // 获取 emptymaterialnew 对象
        if (emptyMaterialObj != null)
        {
            Transform currentChild = null;
            foreach (Transform child in emptyMaterialObj.transform)
            {
                if (child.gameObject.activeInHierarchy) // 判断子物体是否处于激活状态
                {
                    currentChild = child;
                    break;
                }
            }

            if (currentChild != null)
            {
                int currentChildIndex = currentChild.GetSiblingIndex();
                if (currentChildIndex != lastChildIndex)
                {
                    lastChildIndex = currentChildIndex;
                    if (currentChildIndex >= 0 && currentChildIndex < colors.Length)
                    {
                        var main = flameParticle.main;
                        main.startColor = colors[currentChildIndex];
                    }
                }
            }
        }
    }
}*/

/*using UnityEngine;

public class FlameColorController : MonoBehaviour
{
    private ParticleSystem flame;
    private int lastChildIndex = -1;
    private EmptyMaterialController emptyMaterialController; // 存储 EmptyMaterialController 脚本的引用

    public Color[] colors = new Color[] { new Color(0xEF, 0x61, 0x59), new Color(0x64, 0xF3, 0xB8), new Color(0xEF, 0x8D, 0xEC), new Color(0x87, 0xE7, 0x08), new Color(0xE7, 0xDC, 0x73) };

    
    private void Awake()
    {
        flameParticle = GetComponent<ParticleSystem>();
        emptyMaterialController = FindObjectOfType<EmptyMaterialController>(); // 获取 EmptyMaterialController 脚本的引用
    }
    public void SetCurrentChildIndex(int index)
    {
        currentChildIndex = index;
    }

    private void Update()
    {
        GameObject emptyMaterialObj = null;

        // 在场景中查找名为emptymaterialnew的对象
        foreach (var rootObj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            var obj = rootObj.transform.Find("emptymaterialnew");
            if (obj != null)
            {
                emptyMaterialObj = obj.gameObject;
                break;
            }
        }

        if (emptyMaterialObj != null)
        {
            Transform currentChild = null;

            // 查找处于激活状态的子对象
            foreach (Transform child in emptyMaterialObj.transform)
            {
                if (child.gameObject.activeInHierarchy)
                {
                    currentChild = child;
                    break;
                }
            }

            if (currentChild != null)
            {
                int currentChildIndex = currentChild.GetSiblingIndex();
                if (currentChildIndex != lastChildIndex)
                {
                    lastChildIndex = currentChildIndex;

                    if (emptyMaterialController != null)
                    {
                        emptyMaterialController.SetCurrentChildIndex(currentChildIndex);
                    }
                    if (currentChildIndex >= 0 && currentChildIndex < colors.Length)
                    {
                        var main = flameParticle.main;
                        main.startColor = colors[currentChildIndex];
                    }
                }
            }
        }
    }


}*/

/*using UnityEngine;

public class FlameColorController : MonoBehaviour
{
    private ParticleSystem flame;
    private int lastChildIndex = -1;
    private EmptyMaterialController emptyMaterialController; // 存储 EmptyMaterialController 脚本的引用
    private int currentChildIndex = -1; // 存储当前子物体的索引

    //public Color[] colors = new Color[] { new Color(0xEF, 0x61, 0x59), new Color(0x64, 0xF3, 0xB8), new Color(0xEF, 0x8D, 0xEC), new Color(0x87, 0xE7, 0x08), new Color(0xE7, 0xDC, 0x73) };


    private void Awake()
    {
        flameParticle = GetComponent<ParticleSystem>();
        emptyMaterialController = FindObjectOfType<EmptyMaterialController>(); // 获取 EmptyMaterialController 脚本的引用
    }

    public void SetCurrentChildIndex(int index)
    {
        currentChildIndex = index;
    }

    private void Update()
    {
        GameObject emptyMaterialObj = null;

        // 在场景中查找名为emptymaterialnew的对象
        foreach (var rootObj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            var obj = rootObj.transform.Find("emptymaterialnew");
            if (obj != null)
            {
                Debug.Log("none");
                emptyMaterialObj = obj.gameObject;
                break;
            }
        }

        if (emptyMaterialObj != null)
        {

            Transform currentChild = null;

            // 查找处于激活状态的子对象
            foreach (Transform child in emptyMaterialObj.transform)
            {
                if (child.gameObject.activeInHierarchy)
                {
                    currentChild = child;
                    break;
                }
            }

            if (currentChild != null)
            {
                //Debug.Log(currentChild);
                int currentChildIndex = currentChild.GetSiblingIndex();
                if (currentChildIndex != lastChildIndex)
                {
                    lastChildIndex = currentChildIndex;

                    if (emptyMaterialController != null)
                    {
                        emptyMaterialController.SetCurrentChildIndex(currentChildIndex);
                    }
                    if (currentChildIndex == 0)
                    {
                        Color redcolour = new Color32(0xEF, 0x61, 0x59, 0xFF);
                        ParticleSystem.MainModule main = flameParticle.main;
                        main.startColor = redcolour;
                    }
                    if (currentChildIndex == 1)
                    {
                        Color blueyellowcolour = new Color32(0x64, 0xF3, 0xB8, 0xFF);
                        ParticleSystem.MainModule main = flameParticle.main;
                        main.startColor = blueyellowcolour;
                    }
                    if (currentChildIndex == 2)
                    {
                        Color lightpurplecolour = new Color32(0xEF, 0x8D, 0xEC, 0xFF);
                        ParticleSystem.MainModule main = flameParticle.main;
                        main.startColor = lightpurplecolour;
                    }
                    if (currentChildIndex == 3)
                    {
                        Color yellowgreencolour = new Color32(0x87, 0xE7, 0x08, 0xFF);
                        ParticleSystem.MainModule main = flameParticle.main;
                        main.startColor = yellowgreencolour;
                    }
                    if (currentChildIndex == 4)
                    {
                        Color yellowcolour = new Color32(0xE7, 0xDC, 0x73, 0xFF);
                        ParticleSystem.MainModule main = flameParticle.main;
                        main.startColor = yellowcolour;
                    }
                }
            }
        }
    }
}*/

using UnityEngine;

public class FlameColorController : MonoBehaviour
{
    public ParticleSystem flame;

    /*private void Awake()
    {
        flame = GetComponent<ParticleSystem>();
    }*/

    private void Start()
    {
        string visibleChildIndex = PlayerPrefs.GetString("visibleChildIndices");
        Color particleColor = Color.white;

        if (visibleChildIndex == "0")
        {
            Debug.LogError("qwq");
            particleColor = new Color(239f / 255f, 97f / 255f, 89f / 255f);
        }
        else if (visibleChildIndex == "1")
        {
            Debug.LogError("qwq");
            particleColor = new Color(100f / 255f, 243f / 255f, 184f / 255f);
        }
        else if (visibleChildIndex == "2")
        {
            Debug.LogError("qwq");
            particleColor = new Color(239f / 255f, 141f / 255f, 236f / 255f);
        }
        else if (visibleChildIndex == "3")
        {
            Debug.LogError("qwq");
            particleColor = new Color(135f / 255f, 231f / 255f, 8f / 255f);
        }
        else if (visibleChildIndex == "4")
        {
            Debug.LogError("qwq");
            particleColor = new Color(231f / 255f, 220f / 255f, 115f / 255f);
        }
        else
        {
            Debug.LogError("Invalid visible child index");
        }

        var main = flame.main;
        main.startColor = particleColor;
    }
}







