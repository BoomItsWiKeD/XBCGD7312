using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{

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

    // Start is called before the first frame update
    void Start()
    {
        LeaveDestination = GameObject.FindGameObjectWithTag("LeaveTarget");
        customer = GetComponent<NavMeshAgent>();
        seatColliders = GameObject.FindGameObjectsWithTag("SeatTable");

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
                transform.parent.tag = "BurgerCustomer";
                this.gameObject.tag = "BurgerCustomer";
                break;

            case 1:
                transform.parent.tag = "PlainBurgerCustomer";
                this.gameObject.tag = "PlainBurgerCustomer"; break;
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
            if (customer.transform.position == LeaveDestination.transform.position)
            {
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
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
    }
}