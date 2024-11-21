using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject bunBottomImg;
    public GameObject bunTopImg;
    public GameObject lettuceImg;
    public GameObject tomatoImg;
    public GameObject pattyImg;

    public  bool hasMadePlainBurger;
    public  bool hasMadeFilledBurger;
    public  bool hasMadeTrash;

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
                bunBottomImg.SetActive(true);
            }
            else if (platePickedUp && bunBottom.activeSelf && patty.activeSelf)
            {
                bunTop.SetActive(true);
                bunTopImg.SetActive(true);
            }
        }

        if (other.CompareTag("LettuceDispenser"))
        {
            if (platePickedUp)
            {
                lettuce.SetActive(true);
                lettuceImg.SetActive(true);
            }
        }
        
        if (other.CompareTag("PattyDispenser"))
        {
            if (platePickedUp)
            {
                patty.SetActive(true);
                pattyImg.SetActive(true);
            }
        }
        
        if (other.CompareTag("TomatoDispenser"))
        {
            if (platePickedUp)
            {
                tomato.SetActive(true);
                tomatoImg.SetActive(true);
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

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.collider.CompareTag("Table"))
        // {
        //     if (collision.collider.GetComponent<TableManager>().currentOrder == "burgerCustomer" && hasMadeFilledBurger)
        //     {
        //         Debug.Log("Burger customer satisfied");
        //         collision.collider.GetComponent<TableManager>().orderCompleted = true;
        //         collision.collider.GetComponent<TableManager>().SendOutside();
        //         collision.collider.GetComponent<TableManager>().tableUI.SetActive(false);
        //         
        //         bunBottom.SetActive(false);
        //         bunTop.SetActive(false);
        //         lettuce.SetActive(false);
        //         tomato.SetActive(false);
        //         patty.SetActive(false);
        //     }
        //     else if (collision.collider.GetComponent<TableManager>().currentOrder == "plainBurgerCustomer" && hasMadePlainBurger)
        //     {
        //         Debug.Log("Plain burger customer satisfied");
        //         collision.collider.GetComponent<TableManager>().orderCompleted = true;
        //         collision.collider.GetComponent<TableManager>().SendOutside();
        //         collision.collider.GetComponent<TableManager>().tableUI.SetActive(false);
        //         
        //         bunBottom.SetActive(false);
        //         bunTop.SetActive(false);
        //         patty.SetActive(false);
        //     }
        //     else
        //     {
        //         Debug.Log("customer not satisfied");
        //         collision.collider.GetComponent<TableManager>().orderCompleted = false;
        //     }
        // }
    }

    public void CheckBurger()
    {
        // Check for required ingredients
        bool hasBunBottom = bunBottom.activeSelf;
        bool hasPatty = patty.activeSelf;
        bool hasBunTop = bunTop.activeSelf;
        bool hasLettuce = lettuce.activeSelf;
        bool hasTomato = tomato.activeSelf;

        if (hasBunBottom && hasPatty && hasBunTop && !hasLettuce && !hasTomato)
        {
            hasMadePlainBurger = true;
            hasMadeFilledBurger = false;
            hasMadeTrash = false;
        }
        else if (hasBunBottom && hasPatty && hasBunTop && hasLettuce && hasTomato)
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

