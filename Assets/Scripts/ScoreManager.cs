using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float score;
    public TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + Mathf.Round(score);
    }
}
