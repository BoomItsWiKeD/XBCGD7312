using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    public GameObject plainCustomerPrefab;
    public GameObject fullCustomerPrefab;
    public Transform customerSpawnPoint; // Will be set in the inspector
    private GameObject[] plainCustomers; // Plain burger / Full burger customers
    private GameObject[] fullCustomers;

    public int customersActivated;
    public static int customersSentOut;
    public float nextCustomerTimer = 30f;
    public float customerInterval = 5f; // Time between activating new customers
    private float timeSinceLastSpawn;

    void Start()
    {
        // Spawn the first customer when the scene starts
        Instantiate(plainCustomerPrefab, customerSpawnPoint.position, plainCustomerPrefab.transform.rotation);
        timeSinceLastSpawn = 0f; // Initialize the timer
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime; // Increment the timer each frame

        // Check if it's time to spawn a new customer and if there are less than 5 customers in the scene
        if (CustomersInScene() <= 5 && timeSinceLastSpawn >= customerInterval)
        {
            StartCoroutine(SpawnNewCustomer());
            timeSinceLastSpawn = 0f; // Reset the spawn timer after spawning
        }
    }

    IEnumerator SpawnNewCustomer()
    {
        // Instantiate a new customer
        int randomCustomer = Random.Range(0, 2);
        switch (randomCustomer)
        {
            case 0: Instantiate(plainCustomerPrefab, customerSpawnPoint.position, plainCustomerPrefab.transform.rotation); break;
            case 1: Instantiate(fullCustomerPrefab, customerSpawnPoint.position, fullCustomerPrefab.transform.rotation); break;
        }
        yield return null; 
    }

    public int CustomersInScene()
    {
        fullCustomers = GameObject.FindGameObjectsWithTag("BurgerCustomer");
        plainCustomers = GameObject.FindGameObjectsWithTag("PlainBurgerCustomer");
        int totalCustomersInScene = fullCustomers.Length + plainCustomers.Length;
        Debug.Log(totalCustomersInScene + " | TOTAL CUSTOMERS");
        return totalCustomersInScene;
    }
}
