using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CustomerAI : MonoBehaviour
{
    public string sceneName;
    public GameObject endScreen;
    
    private NavMeshAgent customer;
    public Transform customerDestination;
    public GameObject LeaveDestination;
    public TableChecker[] tableCheckers; // Ensure this is correctly initialized
    public TableChecker currentSeatTarget;
    public GameObject[] seatColliders;

    public GameObject GlassesObj; // Random appearance
    public GameObject Mustache;
    public GameObject hat;
    public bool customerReachedTable = false;
    public bool orderCompleted = false;

    private PlateManager CreatedOrder;

    public GameObject plate;
    public GameObject plateUI;
    public GameObject topBun;
    public GameObject topBunUI;
    public GameObject bottomBun;
    public GameObject bottomBunUI;
    public GameObject tomato;
    public GameObject tomatoUI;
    public GameObject lettuce;
    public GameObject lettuceUI;
    public GameObject patty;
    public GameObject pattyUI;


    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        
        plate = GameObject.Find("Player/Plate");
        plateUI = GameObject.Find("Canvas/Inventory/PlateUI");
        topBun = GameObject.Find("Player/Burger/BunTop");
        topBunUI = GameObject.Find("Canvas/Inventory/TopBunUI");
        bottomBun = GameObject.Find("Player/Burger/BunBottom"); 
        bottomBunUI = GameObject.Find("Canvas/Inventory/BottomBunUI");
        tomato = GameObject.Find("Player/Burger/Tomato");
        tomatoUI = GameObject.Find("Canvas/Inventory/TomatoUI");
        lettuce = GameObject.Find("Player/Burger/Lettuce");
        lettuceUI = GameObject.Find("Canvas/Inventory/LettuceUI");
        patty = GameObject.Find("Player/Burger/Patty");
        pattyUI = GameObject.Find("Canvas/Inventory/PattyUI");
        
        LeaveDestination = GameObject.FindGameObjectWithTag("LeaveTarget");
        customer = GetComponent<NavMeshAgent>();
        seatColliders = GameObject.FindGameObjectsWithTag("SeatTable");
        CreatedOrder = GameObject.FindGameObjectWithTag("Player").GetComponent<PlateManager>();
        // Initialize the tableCheckers array to match the number of seatColliders
        tableCheckers = new TableChecker[seatColliders.Length];

        // Assign TableChecker components from each seatCollider
        int index = 0;
        foreach (GameObject seat in seatColliders)
        {
            tableCheckers[index] = seat.GetComponent<TableChecker>();
            index++;
        }

        // Randomly change appearance once the character is spawned
        int randomAppearance = Random.Range(0, 3);
        switch (randomAppearance)
        {
            case 0: GlassesObj.SetActive(true); break;
            case 1: Mustache.SetActive(true); break;
            case 2: hat.SetActive(true); break;
            default: GlassesObj.SetActive(true); break;
        }

        // Random customer order logic
        int randomCustomerOrder = Random.Range(0, 2);
        switch (randomCustomerOrder)
        {
            case 0:
                //transform.parent.tag = "BurgerCustomer";
               // this.gameObject.tag = "BurgerCustomer";
                break;

            case 1:
                //transform.parent.tag = "PlainBurgerCustomer";
                //this.gameObject.tag = "PlainBurgerCustomer";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!orderCompleted)
        {
            SelectANewOpenTable();
            seatColliders = GameObject.FindGameObjectsWithTag("SeatTable");
            tableCheckers = new TableChecker[seatColliders.Length];

            // Assign TableChecker components from each seatCollider
            int index = 0;
            foreach (GameObject seat in seatColliders)
            {
                tableCheckers[index] = seat.GetComponent<TableChecker>();
                index++;
            }
        }
        else if (orderCompleted)
        {
            CustomerLeave();
            
        }
    }

    private void SelectANewOpenTable() // If the target the AI was going to was recently taken
    {
        if (currentSeatTarget == null || (currentSeatTarget.tableReserved && !customerReachedTable))
        {
            int index = 0;
            foreach (GameObject seat in seatColliders)
            {
                tableCheckers[index] = seat.GetComponent<TableChecker>();
                index++;
            }

            foreach (TableChecker seat in tableCheckers)
            {
                if (!seat.tableReserved)
                {
                    customer.SetDestination(seat.gameObject.transform.position);
                    currentSeatTarget = seat;
                    break; // Stop once an open seat is found
                }
            }
        }
    }

    public void CustomerLeave()
    {
        customer.SetDestination(LeaveDestination.transform.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SeatTable"))
        {
            customerReachedTable = true;

        }
        if(orderCompleted && other.CompareTag("LeaveTarget"))
        {
            if (sceneName == "TutorialLevel")
            {
                endScreen.SetActive(true);
            }
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(CreatedOrder.hasMadeFilledBurger && this.tag == "BurgerCustomer")
            {
                orderCompleted = true;
                DeactivateBurger();
                
            }
            if(CreatedOrder.hasMadePlainBurger && this.tag == "PlainBurgerCustomer")
            {
                orderCompleted = true;
                DeactivateBurger();
            }
        }
    }
    public void DeactivateBurger()
    {
        plate.SetActive(false);
        bottomBun.SetActive(false);
        topBun.SetActive(false);
        tomato.SetActive(false);
        lettuce.SetActive(false);
        patty.SetActive(false);
        plateUI.SetActive(false);
        bottomBunUI.SetActive(false);
        topBunUI.SetActive(false);
        tomatoUI.SetActive(false);
        lettuceUI.SetActive(false);
        pattyUI.SetActive(false);
    }
}