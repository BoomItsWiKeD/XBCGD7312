using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateManager : MonoBehaviour
{
    private bool platePickedUp;
    
    public GameObject plate;
    public Rigidbody playerRB;

    private void Start()
    {
        platePickedUp = false;
    }

    private void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlateDispenser"))
        {
            Debug.Log("Player picked up plate");
            platePickedUp = true;
            plate.SetActive(true);
        }
    }
}
