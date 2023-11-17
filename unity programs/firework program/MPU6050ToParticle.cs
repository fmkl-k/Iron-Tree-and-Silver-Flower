/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class MPU6050ToParticle : MonoBehaviour
{
    public string imuName = "imu";
    public float speedFactor = 1f;
    public Vector3 rotationOffset = Vector3.zero;

    public ParticleSystem firework;

    Quaternion rotOffset = Quaternion.identity;

    void Start()
    {
        UduinoManager.Instance.OnDataReceived += ReadIMU;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setOrigin = true;
        }
    }

    public bool setOrigin = false;

    void ReadIMU(string data, UduinoDevice device)
    {
        string[] values = data.Split('/');
        if (values.Length == 5 && values[0] == imuName)
        {
            float w = float.Parse(values[1]);
            float x = float.Parse(values[2]);
            float y = float.Parse(values[3]);
            float z = float.Parse(values[4]);
            Quaternion rotation = new Quaternion(w, x, y, z) * Quaternion.Inverse(rotOffset);
            this.transform.rotation = rotation;

            if (firework != null)
            {
                ParticleSystem.MainModule main = firework.main;
                main.startRotationX = -rotation.eulerAngles.x;
                main.startRotationY = -rotation.eulerAngles.y;
                main.startRotationZ = -rotation.eulerAngles.z;
            }
        }
        else if (values.Length != 5)
        {
            Debug.LogWarning(data);
        }

        if (setOrigin)
        {
            rotOffset = this.transform.rotation;
            setOrigin = false;
        }
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class MPU6050ToParticle : MonoBehaviour
{
    public string imuName = "imu";
    public float speedFactor = 1f;
    public Vector3 rotationOffset = Vector3.zero;

    public ParticleSystem firework;

    Quaternion rotOffset = Quaternion.identity;

    void Start()
    {
        //UduinoManager.Instance.Connect();
        UduinoManager.Instance.OnDataReceived += ReadIMU;
    }

    public bool setOrigin = false;

    void ReadIMU(string data, UduinoDevice board)
    {
        Debug.Log(data);

        string[] values = data.Split(',');
        if (values.Length == 3)
        {
            float x = float.Parse(values[0]);
            float y = float.Parse(values[1]);
            float z = float.Parse(values[2]);

            if (firework != null)
            {
                ParticleSystem.MainModule main = firework.main;

                // Check if rotation values need to be converted from degrees to radians
                if (main.startRotation.mode == ParticleSystemCurveMode.Constant)
                {
                    main.startRotationX = x * Mathf.Deg2Rad;
                    main.startRotationY = y * Mathf.Deg2Rad;
                    main.startRotationZ = z * Mathf.Deg2Rad;
                }
                else
                {
                    main.startRotationX = x;
                    main.startRotationY = y;
                    main.startRotationZ = z;
                }
            }
        }
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class MPU6050ToParticle : MonoBehaviour
{
    public string imuName = "imu";
    public float speedFactor = 1f;
    public Vector3 rotationOffset = Vector3.zero;

    public ParticleSystem firework;

    Quaternion rotOffset = Quaternion.identity;

    void Start()
    {
        //UduinoManager.Instance.Connect();
        UduinoManager.Instance.OnDataReceived += ReadIMU;
    }

    public bool setOrigin = false;

    void ReadIMU(string data, UduinoDevice board)
    {
        Debug.Log(data);

        string[] values = data.Split(',');
        if (values.Length == 3)
        {
            float x = float.Parse(values[0]);
            float z = float.Parse(values[1]);
            float y = float.Parse(values[2]);

            if (firework != null)
            {
                // Convert rotation angles to quaternion
                Quaternion rotation = Quaternion.Euler(x, z, y) * rotOffset;

                // Apply rotation to particle system transform
                firework.transform.rotation = rotation;
            }
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class MPU6050ToParticle : MonoBehaviour
{
    public string imuName = "imu";
    public Vector3 rotationOffset = Vector3.zero;

    public ParticleSystem firework;
    public float speedFactor = 1f;

    Quaternion rotOffset = Quaternion.identity;

    void Start()
    {
        UduinoManager.Instance.OnDataReceived += ReadIMU;
    }

    void ReadIMU(string data, UduinoDevice board)
    {
        Debug.Log(data);

        string[] values = data.Split(',');
        if (values.Length == 7)
        {
            float x = float.Parse(values[3]);
            float z = float.Parse(values[4]);
            float y = float.Parse(values[5]);
            float speed = float.Parse(values[6]);

            if (firework != null)
            {
                // Check if speed is greater than 1.6
                if (speed > 1.3f)
                {
                    // Enable particle system
                    if (!firework.isPlaying) firework.Play();

                    // Calculate speed proportional to received value
                    float particleSpeed = speedFactor * speed + 28f;

                    // Convert rotation angles to quaternion
                    Quaternion rotation = Quaternion.Euler(x, z, y) * rotOffset;

                    // Apply rotation and speed to particle system
                    var main = firework.main;
                    main.startSpeed = particleSpeed;
                    firework.transform.rotation = rotation;
                }
                else
                {
                    // Disable particle system
                    if (firework.isPlaying) firework.Stop();
                }
            }
        }
    }
}



