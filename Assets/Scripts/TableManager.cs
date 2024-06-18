using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TableManager : MonoBehaviour
{
    public string currentOrder;
    public float currentTime;
    public GameObject customer1;
    public GameObject customer2;
    public GameObject customer3;
    public GameObject customer4;
    public GameObject customer5;

    public NavMeshAgent agent1;
    public NavMeshAgent agent2;
    public NavMeshAgent agent3;
    public NavMeshAgent agent4;
    public NavMeshAgent agent5;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
    public Transform endTarget;

    void Start()
    {
    }
    
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        //StartCoroutine(CheckTimer());
        
        if (other.CompareTag("BurgerCustomer"))
        {
            Debug.Log("burgerCustomer collided");
            this.currentOrder = "burgerCustomer";
            StartCoroutine(WaitTimer());

            Debug.Log("Finishedwaiting");
            if (AIManager.customersSentOut == 0)
            {
                SendOutside();
            }
            else if (AIManager.customersSentOut == 2)
            {
                SendOutside();
            }
            else if (AIManager.customersSentOut == 4)
            {
                SendOutside();
            }
        }

        if (other.CompareTag("PlainBurgerCustomer"))
        {
            Debug.Log("plain customer collided");
            this.currentOrder = "plainBurgerCustomer";
            StartCoroutine(WaitTimer());

            if (AIManager.customersSentOut == 1)
            {
                SendOutside();
            }
            else if (AIManager.customersSentOut == 3)
            {
                SendOutside();
            }
        }
    }

    public void CheckCustomer()
    {
        
    }
    
    public void SendOutside()
    {
        AIManager.customersSentOut = AIManager.customersSentOut + 1;
        Debug.Log("sendoutside");

        if (AIManager.customersSentOut == 1)
        {
            agent1.SetDestination(endTarget.transform.position);
        }

        if (AIManager.customersSentOut == 2)
        {
            agent2.SetDestination(endTarget.transform.position);
        }

        if (AIManager.customersSentOut == 3)
        {
            agent3.SetDestination(endTarget.transform.position);
        }

        if (AIManager.customersSentOut == 4)
        {
            agent4.SetDestination(endTarget.transform.position);
        }

        if (AIManager.customersSentOut == 5)
        {
            agent5.SetDestination(endTarget.transform.position);
        }
    }
    
    // public void OnTriggerExit(Collider other)
    // {
    //     this.currentOrder = null;
    // }

    // public IEnumerator CheckTimer()
    // {
    //     yield return new WaitForSeconds(5);
    // }

    public IEnumerator WaitTimer()
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

    
    