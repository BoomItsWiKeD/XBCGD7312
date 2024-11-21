using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIManager : MonoBehaviour
{
    public GameObject endScreen;
    public string sceneName;
    
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

    private float totalNumberOfCustomers = 1;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        // Spawn the first customer when the scene starts
        Instantiate(plainCustomerPrefab, customerSpawnPoint.position, plainCustomerPrefab.transform.rotation);
        timeSinceLastSpawn = 0f; // Initialize the timer
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime; // Increment the timer each frame
        Debug.Log(totalNumberOfCustomers + "| Total number of customers Spawned");
        // Check if it's time to spawn a new customer and if there are less than 5 customers in the scene
        if (CustomersInScene() < 4 && timeSinceLastSpawn >= customerInterval)
        {
            if (totalNumberOfCustomers < 10)
            {
                StartCoroutine(SpawnNewCustomer());
            }
            timeSinceLastSpawn = 0f; // Reset the spawn timer after spawning
        }

        if (CustomersInScene() == 0 && totalNumberOfCustomers == 10)
        {
            endScreen.SetActive(true);
        }
        if (CustomersInScene() == 0 && sceneName == "TutorialLevel")
        {
            endScreen.SetActive(true);
        }
    }

    IEnumerator SpawnNewCustomer()
    {
        // Instantiate a new customer
        totalNumberOfCustomers++;
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
        int totalCustomersInScene = 0;
        fullCustomers = GameObject.FindGameObjectsWithTag("BurgerCustomer");
        plainCustomers = GameObject.FindGameObjectsWithTag("PlainBurgerCustomer");
        totalCustomersInScene = fullCustomers.Length + plainCustomers.Length;
        Debug.Log(totalCustomersInScene + " | TOTAL CUSTOMERS");
        return totalCustomersInScene;
    }
}
