using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableChecker : MonoBehaviour
{
    public bool tableReserved = false; //If true then the table has an AI on it
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BurgerCustomer") || other.CompareTag("PlainBurgerCustomer"))
        {
            tableReserved = true;
        }
        else tableReserved = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BurgerCustomer") || other.CompareTag("PlainBurgerCustomer"))
        {
            tableReserved = false;
        }
        
    }
}
