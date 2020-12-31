using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Move : MonoBehaviour
{
    public float speed = 10;
    CharacterController cc;
    Rigidbody rb;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        if(cc.isGrounded == false)
        {
            move.y -= 90f * Time.deltaTime;
        }

        cc.Move(move * speed * Time.deltaTime);
    }
}