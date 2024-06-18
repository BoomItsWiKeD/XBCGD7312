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
    public bool orderCompleted;
    public int ordersCompleted;

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
    public GameObject table1UI;
    public GameObject table2UI;
    public GameObject table3UI;
    public GameObject table4UI;
    public GameObject table5UI;
    

    void Start()
    {
        orderCompleted = false;
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
            

            Debug.Log("Finishedwaiting");
            if (AIManager.customersSentOut == 0)
            {
                StartCoroutine(WaitTimer1());
                if (orderCompleted)
                {
                    ordersCompleted++;
                }
                orderCompleted = false;
                SendOutside();
            }
            else if (AIManager.customersSentOut == 2)
            {
                StartCoroutine(WaitTimer3());
                if (orderCompleted)
                {
                    ordersCompleted++;
                }
                orderCompleted = false;
                SendOutside();
            }
            else if (AIManager.customersSentOut == 4)
            {
                StartCoroutine(WaitTimer5());
                if (orderCompleted)
                {
                    ordersCompleted++;
                }
                orderCompleted = false;
                SendOutside();
            }
        }

        if (other.CompareTag("PlainBurgerCustomer"))
        {
            Debug.Log("plain customer collided");
            this.currentOrder = "plainBurgerCustomer";

            if (AIManager.customersSentOut == 1)
            {
                StartCoroutine(WaitTimer2());
                if (orderCompleted)
                {
                    ordersCompleted++;
                }
                orderCompleted = false;
                SendOutside();
            }
            else if (AIManager.customersSentOut == 3)
            {
                StartCoroutine(WaitTimer4());
                if (orderCompleted)
                {
                    ordersCompleted++;
                }

                orderCompleted = false;
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

    public IEnumerator WaitTimer1()
    {
        table1UI.SetActive(true);
        yield return new WaitForSeconds(45);
        table1UI.SetActive(false);
        
    }
    public IEnumerator WaitTimer2()
    {
        table2UI.SetActive(true);
        yield return new WaitForSeconds(45);
        table2UI.SetActive(false);
    }
    public IEnumerator WaitTimer3()
    {
        table3UI.SetActive(true);
        yield return new WaitForSeconds(45);
        table3UI.SetActive(false);
    }
    public IEnumerator WaitTimer4()
    {
        table4UI.SetActive(true);
        yield return new WaitForSeconds(45);
        table4UI.SetActive(false);
    }
    public IEnumerator WaitTimer5()
    {
        table5UI.SetActive(true);
        yield return new WaitForSeconds(45);
        table5UI.SetActive(false);
    }
    

    // OnTriggerEnter
    // {
    //     if player and player is holding correct()
    //     {
    //         take food and deactivate food, and change player state
    //     }
    // }
}

    
    