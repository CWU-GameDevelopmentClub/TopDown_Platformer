using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private float XSpeed;
    private float YSpeed;
    private float ZSpeed;
    public float KeySpeed;
    public float JumpSpeed;
    private bool LeftPress, RightPress, UpPress, DownPress, JumpPress;
    public int Deceleration;
    private Rigidbody rb;

    private int Keys;

    // Use this for initialization
    void Start()
    {
        XSpeed = 0;
        YSpeed = 0;
        ZSpeed = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LeftPress = false;
        RightPress = false;
        UpPress = false;
        DownPress = false;

        if (Input.GetKey(KeyCode.A))
        {
            LeftPress = true;
            XSpeed = -KeySpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RightPress = true;
            XSpeed = KeySpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            DownPress = true;
            ZSpeed = -KeySpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            UpPress = true;
            ZSpeed = KeySpeed;
        }

        if (!LeftPress && !RightPress)
        {
            if (XSpeed > 0)
            {
                if (XSpeed - (float)Deceleration / 8f < 0)
                    XSpeed = 0;
                else
                    XSpeed -= (float)Deceleration / 8f;
            }
            else if (XSpeed < 0)
            {
                if (XSpeed + (float)Deceleration / 8f < 0)
                    XSpeed = 0;
                else
                    XSpeed += (float)Deceleration / 8f;
            }
        }
        if (!UpPress && !DownPress)
        {
            if (ZSpeed > 0)
            {
                if (ZSpeed - (float)Deceleration / 8f < 0)
                    ZSpeed = 0;
                else
                    ZSpeed -= (float)Deceleration / 8f;
            }
            else if (ZSpeed < 0)
            {
                if (ZSpeed + (float)Deceleration / 8f < 0)
                    ZSpeed = 0;
                else
                    ZSpeed += (float)Deceleration / 8f;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!JumpPress)
            {
                YSpeed += JumpSpeed;
                JumpPress = true;
            }
            else
                YSpeed = 0;
        }
        else
        {
            YSpeed = 0;
            JumpPress = false;
        }

        rb.velocity = new Vector3(XSpeed, YSpeed + rb.velocity.y, ZSpeed);
    }
}
