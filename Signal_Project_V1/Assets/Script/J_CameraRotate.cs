using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_CameraRotate : MonoBehaviour
{
    float rx;
    float ry;
    public float rotateSpeed = 300;
    void Start()
    {
        rx = transform.eulerAngles.x;
        ry = transform.eulerAngles.y;
    }

    void Update()
    {
        float my = Input.GetAxis("Mouse Y");
        float mx = Input.GetAxis("Mouse X");

        rx += mx * rotateSpeed * Time.deltaTime;
        ry += my * rotateSpeed * Time.deltaTime;


        transform.eulerAngles = new Vector3(-ry, rx, 0);
    }
}
