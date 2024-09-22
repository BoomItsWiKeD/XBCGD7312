using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    public NavMeshAgent agent1;
    public NavMeshAgent agent2;
    public NavMeshAgent agent3;
    public NavMeshAgent agent4;
    public NavMeshAgent agent5;

    public Transform target1; // Table 1
    public Transform target2; // Table 2
    public Transform target3; // Table 3
    public Transform target4; // Table 4
    public Transform target5; // Table 5
    public Transform endTarget; // Exit after eating

    public int customersActivated;
    public static int customersSentOut;
    public float nextCustomerTimer = 30f;
    public float customerInterval = 5f; // Time between activating new customers

    private bool agent1Active = false;
    private bool agent2Active = false;
    private bool agent3Active = false;
    private bool agent4Active = false;
    private bool agent5Active = false;

    void Start()
    {
        ActivateNextCustomer();
    }
    
    void Update()
    {
        if (customersActivated < 5)
        {
            nextCustomerTimer -= Time.deltaTime;

            if (nextCustomerTimer <= 0)
            {
                ActivateNextCustomer();
                nextCustomerTimer = customerInterval; // Reset timer for next customer
            }
        }
    }

    public void ActivateNextCustomer()
    {
        customersActivated++;
        switch (customersActivated)
        {
            case 1:
                agent1.SetDestination(target1.position);
                agent1Active = true;
                break;
            case 2:
                agent2.SetDestination(target2.position);
                agent2Active = true;
                break;
            case 3:
                agent3.SetDestination(target3.position);
                agent3Active = true;
                break;
            case 4:
                agent4.SetDestination(target4.position);
                agent4Active = true;
                break;
            case 5:
                agent5.SetDestination(target5.position);
                agent5Active = true;
                break;
        }
    }
    
    public void SendCustomerOutside()
    {
        customersSentOut++;
        switch (customersSentOut)
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
}
