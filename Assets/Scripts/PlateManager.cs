using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlateManager : MonoBehaviour
{
    private bool platePickedUp;
    
    public GameObject plate;
    public Rigidbody playerRB;
    public GameObject table;

    public GameObject bunBottom;
    public GameObject bunTop;
    public GameObject lettuce;
    public GameObject patty;
    public GameObject tomato;

    public static bool hasMadePlainBurger;
    public static bool hasMadeFilledBurger;
    public static bool hasMadeTrash;

    private void Start()
    {
        platePickedUp = false;
    }

    private void Update()
    {
        CheckBurger();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlateDispenser"))
        {
            Debug.Log("Player picked up plate");
            platePickedUp = true;
            plate.SetActive(true);
        }

        if (other.CompareTag("BunDispenser"))
        {
            if (platePickedUp && !bunBottom.activeSelf)
            {
                bunBottom.SetActive(true);
            }
            else if (platePickedUp && bunBottom.activeSelf && patty.activeSelf)
            {
                bunTop.SetActive(true);
            }
        }

        if (other.CompareTag("LettuceDispenser"))
        {
            if (platePickedUp)
            {
                lettuce.SetActive(true);
            }
        }
        
        if (other.CompareTag("PattyDispenser"))
        {
            if (platePickedUp)
            {
                patty.SetActive(true);
            }
        }
        
        if (other.CompareTag("TomatoDispenser"))
        {
            if (platePickedUp)
            {
                tomato.SetActive(true);
            }
        }

        if (other.CompareTag("Bin"))
        {
            if (platePickedUp)
            {
                if (bunBottom.activeSelf || bunTop.activeSelf || lettuce.activeSelf || patty.activeSelf || tomato.activeSelf)
                {
                    bunBottom.SetActive(false);
                    bunTop.SetActive(false);
                    lettuce.SetActive(false);
                    patty.SetActive(false);
                    tomato.SetActive(false);
                    plate.SetActive(false);
                }
            }
        }

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Table"))
        {
            if (collision.collider.GetComponent<TableManager>().currentOrder == "burgerCustomer" && hasMadeFilledBurger)
            {
                Debug.Log("Burger customer satisfied");
            }
            else if (collision.collider.GetComponent<TableManager>().currentOrder == "plainBurgerCustomer" && hasMadePlainBurger)
            {
                Debug.Log("Plain burger customer satisfied");
            }
            else
            {
                Debug.Log("customer not satisfied");
            }
        }
    }*/

    public void CheckBurger()
    {
        if (bunBottom.activeSelf && patty.activeSelf && bunTop.activeSelf && !lettuce.activeSelf && !tomato.activeSelf) //Plain burger
        {
            hasMadePlainBurger = true;
            hasMadeFilledBurger = false;
            hasMadeTrash = false;
        }
        else if (bunBottom.activeSelf && patty.activeSelf && bunTop.activeSelf && lettuce.activeSelf && tomato.activeSelf) //Filled burger
        {
            hasMadeFilledBurger = true;
            hasMadePlainBurger = false;
            hasMadeTrash = false;
        }
        else
        {
            hasMadeTrash = true;
            hasMadePlainBurger = false;
            hasMadeFilledBurger = false;
        }
    }
}

