using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static float speed = 5f;
    private Rigidbody rb;
    private float moveHoriz;
    private float moveVert;
    public GameObject player;

    private float rotTarget;
    private float rotReference;

    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        moveHoriz = Input.GetAxis("Horizontal");
        moveVert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHoriz, 0f, moveVert);
        movement.Normalize();
        
        rb.velocity = movement * speed;

        if (moveHoriz == 0 && moveVert > 0) //W input
        {
            ChangeAngle(0);
        }
        if (moveHoriz < 0 && moveVert == 0) //A input
        {
            ChangeAngle(-90);
        }
        if (moveHoriz == 0 && moveVert < 0) //S input
        {
            ChangeAngle(180);
        }
        if (moveHoriz > 0 && moveVert == 0) //D input
        {
            ChangeAngle(90);
        }

        if (moveHoriz > 0 && moveVert > 0) //W and D input
        {
            ChangeAngle(45);
        }
        if (moveHoriz > 0 && moveVert < 0) //D and S input
        {
            ChangeAngle(135);
        }
        if (moveHoriz < 0 && moveVert < 0) //A and S input
        {
            ChangeAngle(-135);
        }
        if (moveHoriz < 0 && moveVert > 0) //W and A input
        {
            ChangeAngle(-45);
        }
        
        //Handling Rotation:
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotTarget, ref rotReference, 0.1f);
        transform.rotation = Quaternion.Euler(0, angle,0);
    }

    public void ChangeAngle(float targetAngle)
    {
        rotTarget = targetAngle;
    }
}
