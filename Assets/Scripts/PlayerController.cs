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
        
        //rb.MoveRotation(Quaternion.LookRotation(movement));
        
        
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag(""))
    //     {
    //         
    //     }
    // }
    //
    // private void OnCollisionEnter(Collision collision)
    // {
    //     
    // }
}
