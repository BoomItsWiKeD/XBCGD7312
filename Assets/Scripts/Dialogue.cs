using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public TMP_Text dialogueText; 
    //public Button continueButton;
    public GameObject dialoguePanel;

    private string[] dialogueSentences;
    private int sentenceIndex = 0;

    void Start()
    {
        Time.timeScale = 0f;
        dialogueSentences = new string[]
        {
            "Hello, and welcome to the tutorial!",
            "You are now in a simple kitchen and are tasked with making various burgers for customers.",
            "As you can see, there are various cooking stations near the window.",
            "These cooking stations provide ingredients such as buns, tomatoes, lettuce and cooked patties.",
            "Once a customer waits at a table, the type of burger they order will be displayed.",
            "Walk up to the cooking stations after collecting a plate to build the burger the customer asked for.",
            "If you have created a burger which the customer did not ask for, you can walk up to the bin to clear your plate.",
            "If you do not give the customer their specified burger in time, they will leave the restaurant.",
            "Now see if you can complete an order!"
        };

        //Display the first sentence
        dialogueText.text = dialogueSentences[sentenceIndex];

        //Add the listener
        //continueButton.onClick.AddListener(OnContinueClicked);
    }
    
    public void OnContinueClicked()
    {
        sentenceIndex++;

        if (sentenceIndex < dialogueSentences.Length)
        {
            dialogueText.text = dialogueSentences[sentenceIndex];
        }
        else
        {
            //Hide the UI and resume time
            Time.timeScale = 1f;
            dialoguePanel.SetActive(false);
        }
    }
}
