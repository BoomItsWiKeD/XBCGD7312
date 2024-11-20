using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TutorialAI : MonoBehaviour
{
    public Transform table; // Assign the target table in the inspector
    public NavMeshAgent agent;
    public GameObject patienceTimerUI; // Assign the UI for the patience timer
    public float patienceDuration = 10f; // Time in seconds before the customer leaves
    private bool isAtTable = false;

    private float timer;

    void Start()
    {
        // Move the customer to the assigned table
        agent.SetDestination(table.position);
        patienceTimerUI.SetActive(false); // Hide the patience timer initially
        timer = patienceDuration;
    }

    void Update()
    {
        if (isAtTable)
        {
            // Decrease the patience timer
            timer -= Time.deltaTime;

            // Update UI (e.g., a text or slider)
            UpdatePatienceTimerUI();

            // If the timer runs out, make the customer leave
            if (timer <= 0)
            {
                LeaveRestaurant();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the customer reached the table
        if (other.transform == table)
        {
            isAtTable = true;
            agent.isStopped = true; // Stop the NavMeshAgent
            patienceTimerUI.SetActive(true); // Show the patience timer UI
        }
    }

    private void UpdatePatienceTimerUI()
    {
        // Example: If using a slider
        Slider slider = patienceTimerUI.GetComponentInChildren<Slider>();
        if (slider != null)
        {
            slider.value = timer / patienceDuration; // Update slider value
        }
    }

    private void LeaveRestaurant()
    {
        // Logic for customer leaving the restaurant
        Debug.Log($"{gameObject.name} is leaving the restaurant!");
        Destroy(gameObject); // Remove the customer
    }
}
