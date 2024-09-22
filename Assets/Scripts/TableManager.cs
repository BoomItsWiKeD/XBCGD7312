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
    
    public GameObject bunBottomImg;
    public GameObject bunTopImg;
    public GameObject lettuceImg;
    public GameObject tomatoImg;
    public GameObject pattyImg;

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
        else if (orderTimeRemaining <= 0)
        {
            tableUI.SetActive(false);
            Invoke("SendCustomerOutside", 1f);
        }

    }

    private void CancelOrder()
    {
        tableUI.SetActive(false);
        SendCustomerOutside();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BurgerCustomer"))
        {
            orderTimeRemaining = 45f;
            currentOrder = "burgerCustomer";
            ShowOrderUI();  // Show the order icon and timer for this customer.
            Debug.Log("Burger customer collided with table.");
        }

        if (other.CompareTag("PlainBurgerCustomer"))
        {
            orderTimeRemaining = 45f;
            currentOrder = "plainBurgerCustomer";
            ShowOrderUI();  // Show the order icon and timer for this customer.
            Debug.Log("Plain burger customer collided with table.");
        }
    }
    
    public void ShowOrderUI()
    {
        // Activate the UI (order icon and timer)
        tableUI.SetActive(true);
        // Optionally set the correct order icon based on the currentOrder
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (this.currentOrder == "burgerCustomer" && PlateManager.hasMadeFilledBurger)
            {
                PlateManager.hasMadeFilledBurger = false;
                orderCompleted = true;
                ordersCompleted++;
                tableUI.SetActive(false);
                DeactivateBurger();
                SendCustomerOutside();
                Debug.Log("Burger customer satisfied");
            }
            else if (this.currentOrder == "plainBurgerCustomer" && PlateManager.hasMadePlainBurger)
            {
                PlateManager.hasMadePlainBurger = false;
                orderCompleted = true;
                ordersCompleted++;
                tableUI.SetActive(false);
                DeactivateBurger();
                SendCustomerOutside();
                Debug.Log("Plain burger customer satisfied");
            }
            else
            {
                PlateManager.hasMadeTrash = true;
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
        
        bunBottomImg.SetActive(false);
        bunTopImg.SetActive(false);
        lettuceImg.SetActive(false);
        tomatoImg.SetActive(false);
        pattyImg.SetActive(false);
        
        PlateManager.hasMadeTrash = true;
        PlateManager.hasMadePlainBurger = false;
        PlateManager.hasMadeFilledBurger = false;
    }
    public void CheckCustomer()
    {
        
    }
    
    public void SendCustomerOutside()
    {
        AIManager.customersSentOut++;
        Debug.Log("Sending customer outside");
        
        switch (AIManager.customersSentOut)  
        {  
            case 1:  
                agent1.SetDestination(endTarget.position);  
                break;  
            case 2:  
                agent2.SetDestination(endTarget.position);  
                break;  
            case 3:  
                agent3.SetDestination(endTarget.position);  
                break;  
            case 4:  
                agent4.SetDestination(endTarget.position);  
                break;  
            case 5:  
                agent5.SetDestination(endTarget.position);  
                break;  
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

    // OnTriggerEnter
    // {
    //     if player and player is holding correct()
    //     {
    //         take food and deactivate food, and change player state
    //     }
    // }
}

    
    