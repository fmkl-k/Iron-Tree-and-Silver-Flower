using UnityEngine;

public class rotatematerial : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 15f;
    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
