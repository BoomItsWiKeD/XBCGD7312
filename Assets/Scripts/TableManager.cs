using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public string currentOrder;
    public float currentTime;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("any customer collided");
    }

    public void OnTriggerStay(Collider other)
    {
        DoTimer();
        
        if (other.CompareTag("BurgerCustomer"))
        {
            Debug.Log("burgerCustomer collided");
            this.currentOrder = "burgerCustomer";
        }

        if (other.CompareTag("PlainBurgerCustomer"))
        {
            Debug.Log("plain customer collided");
            this.currentOrder = "plainBurgerCustomer";
        }
    }

    public void OnTriggerExit(Collider other)
    {
        this.currentOrder = null;
    }

    public IEnumerator DoTimer()
    {
        yield return new WaitForSeconds(5);
    }

    // OnTriggerEnter
    // {
    //     if player and player is holding correct()
    //     {
    //         take food and deactivate food, and change player state
    //     }
    // }
}

    
    