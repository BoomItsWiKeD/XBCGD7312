using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public string currentOrder;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("any customer collided");
        
        if (other.gameObject.tag == "BurgerCustomer")
        {
            Debug.Log("burgerCustomer collided");
            this.currentOrder = "burgerCustomer";
        }

        if (other.gameObject.tag == "PlainBurgerCustomer")
        {
            Debug.Log("plain customer collided");
            this.currentOrder = "plainBurgerCustomer";
        }
    }
}

    
    