using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    public float orderTimeRemaining;

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
    public GameObject tableUI;
    public Slider timerSlider;
    
    public GameObject bunBottom;
    public GameObject bunTop;
    public GameObject lettuce;
    public GameObject patty;
    public GameObject tomato;
    public GameObject plate;
    
    

    void Start()
    {
        orderCompleted = false;
    }
    
    void Update()
    {
        orderTimeRemaining -= Time.deltaTime;
        if (orderTimeRemaining > 0)
        {
            timerSlider.value = orderTimeRemaining / 45f;
        }
        else if (orderTimeRemaining < 0)
        {
            tableUI.SetActive(false);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        //StartCoroutine(CheckTimer());
        
        
        if (other.CompareTag("BurgerCustomer"))
        {
            orderTimeRemaining = 45f;
            Debug.Log("burgerCustomer collided");
            this.currentOrder = "burgerCustomer";
            

            Debug.Log("Finishedwaiting");
            if (AIManager.customersSentOut == 0)
            {
                StartCoroutine(WaitTimer1());
            }
            else if (AIManager.customersSentOut == 2)
            {
                StartCoroutine(WaitTimer3());
            }
            else if (AIManager.customersSentOut == 4)
            {
                StartCoroutine(WaitTimer5());
            }
        }

        if (other.CompareTag("PlainBurgerCustomer"))
        {
            orderTimeRemaining = 45f;
            Debug.Log("plain customer collided");
            this.currentOrder = "plainBurgerCustomer";

            if (AIManager.customersSentOut == 1)
            {
                StartCoroutine(WaitTimer2());
            }
            else if (AIManager.customersSentOut == 3)
            {
                StartCoroutine(WaitTimer4());
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (this.currentOrder == "burgerCustomer" && PlateManager.hasMadeFilledBurger)
            {
                orderCompleted = true;
                ordersCompleted++;
                tableUI.SetActive(false);
                DeactivateBurger();
                SendOutside();
                Debug.Log("Burger customer satisfied");
            }
            else if (this.currentOrder == "plainBurgerCustomer" && PlateManager.hasMadeFilledBurger)
            {
                orderCompleted = true;
                ordersCompleted++;
                tableUI.SetActive(false);
                DeactivateBurger();
                SendOutside();
                Debug.Log("Plain burger customer satisfied");
            }
            else
            {
                Debug.Log("customer not satisfied");
            }
        }
    }

    public void DeactivateBurger()
    {
        bunBottom.SetActive(false);
        bunTop.SetActive(false);
        lettuce.SetActive(false);
        patty.SetActive(false);
        tomato.SetActive(false);
        
        PlateManager.hasMadeTrash = true;
        PlateManager.hasMadePlainBurger = false;
        PlateManager.hasMadeFilledBurger = false;
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
        tableUI.SetActive(true);
        yield return new WaitForSeconds(45);
        tableUI.SetActive(false);
        
        orderCompleted = false;
        SendOutside();
    }
    public IEnumerator WaitTimer2()
    {
        tableUI.SetActive(true);
        yield return new WaitForSeconds(45);
        tableUI.SetActive(false);
        
        orderCompleted = false;
        SendOutside();
    }
    public IEnumerator WaitTimer3()
    {
        tableUI.SetActive(true);
        yield return new WaitForSeconds(45);
        tableUI.SetActive(false);
        
        orderCompleted = false;
        SendOutside();
    }
    public IEnumerator WaitTimer4()
    {
        tableUI.SetActive(true);
        yield return new WaitForSeconds(45);
        tableUI.SetActive(false);
        
        orderCompleted = false;
        SendOutside();
    }
    public IEnumerator WaitTimer5()
    {
        tableUI.SetActive(true);
        yield return new WaitForSeconds(45);
        tableUI.SetActive(false);
        
        orderCompleted = false;
        SendOutside();
    }
    

    // OnTriggerEnter
    // {
    //     if player and player is holding correct()
    //     {
    //         take food and deactivate food, and change player state
    //     }
    // }
}

    
    