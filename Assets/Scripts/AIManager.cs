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
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
    public Transform endTarget;
    public int customersActivated;
    
    public static int customersSentOut;

    public float nextCustomerTimer;

    void Start()
    {
        agent1.SetDestination(target1.transform.position);
        nextCustomerTimer = 30;
    }
    
    void Update()
    {
        nextCustomerTimer -= Time.deltaTime;
        if (nextCustomerTimer <= 0)
        {
            StartNextCustomer();
            nextCustomerTimer = 30;
        }
    }

    public void StartNextCustomer()
    {
        customersActivated = customersActivated + 1;
        if (customersActivated == 1)
        {
            agent2.SetDestination(target2.transform.position);
        }
        if (customersActivated == 2)
        {
            agent3.SetDestination(target3.transform.position);
        }
        if (customersActivated == 3)
        {
            agent4.SetDestination(target4.transform.position);
        }
        if (customersActivated == 4)
        {
            agent5.SetDestination(target5.transform.position);
        }
    }
}
