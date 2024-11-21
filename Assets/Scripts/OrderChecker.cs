using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderChecker : MonoBehaviour
{
    private PlateManager playerCreatedOrder;
    [Header("Specific to each table")]
    public GameObject tableUI;
    [Header("Need Both for each type of customer")]
    public GameObject fullBurger;
    public GameObject plainBurger;
    [Header("The timeSlider in the UI prefab for each table")]
    public Slider timeSlider;
    [Header("Sets how much time an order lasts")]
    public float orderTime = 45f;
    private float orderTimer;//The actual order timer countdown

    private bool orderComplete = false;
    private bool orderFailed = false;
    public bool customerAtTable = false;

    [Header("The Current customer at the table")]
    public CustomerAI currentCustomer;


    void Start()
    {
        //Start is called again later once a customer is done to reset the script
        playerCreatedOrder = GameObject.FindGameObjectWithTag("Player").GetComponent<PlateManager>();
        orderComplete = false;
        orderFailed = false;
        customerAtTable = false;
        setFullBurgerUI(false);
        setPlainBurgerUI(false);
    }

    void Update()
    {
        orderTimer -= Time.deltaTime;
        timeSlider.value = orderTimer;
        if (orderTimer <= 0)
        {
            setFullBurgerUI(false);
            setPlainBurgerUI(false);
            if (currentCustomer != null)
            {
                currentCustomer.orderCompleted = true;
                ResetScript();

            }
        }
    }
    private void ResetScript()
    {
        Start();
    }

    private void setFullBurgerUI(bool active)
    {
        if (active) //Starts UI
        {
            tableUI.SetActive(true);
            orderTimer = orderTime;
            fullBurger.SetActive(true);
            plainBurger.SetActive(false);
            timeSlider.value = orderTime;

        }
        else
        {
            tableUI.SetActive(true);
            orderTimer = orderTime;
            fullBurger.SetActive(true);
            plainBurger.SetActive(false);
            timeSlider.value = orderTime;
        }
    }
    private void setPlainBurgerUI(bool active)
    {
        if (active)
        {
            tableUI.SetActive(true);
            orderTimer = orderTime;
            fullBurger.SetActive(false);
            plainBurger.SetActive(true);
            timeSlider.value = orderTimer;
        }
        else
        {
            tableUI.SetActive(false);
            orderTimer = orderTime;
            fullBurger.SetActive(false);
            plainBurger.SetActive(false);
            timeSlider.value = orderTime;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BurgerCustomer"))
        {
            setFullBurgerUI(true);
            customerAtTable = true;
            currentCustomer = other.gameObject.GetComponent<CustomerAI>();
        }
        if (other.CompareTag("PlainBurgerCustomer"))
        {
            setPlainBurgerUI(true);
            customerAtTable = true;
            currentCustomer = other.gameObject.GetComponent<CustomerAI>();
        }
        if (other.CompareTag("BurgerCustomer") && other.CompareTag("Player"))
        {
            if (playerCreatedOrder.hasMadeFilledBurger)
            {
                orderComplete = true;
                setFullBurgerUI(false);
                currentCustomer.orderCompleted = true;
            }
        }
        if (other.CompareTag("PlainBurgerCustomer") && other.CompareTag("Player"))
        {
            if (playerCreatedOrder.hasMadePlainBurger)
            {
                orderComplete = true;
                setPlainBurgerUI(false);
                currentCustomer.orderCompleted = true;
            }
        }
        else customerAtTable = false;
    }
}
