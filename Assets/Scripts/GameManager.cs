using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image portraitFrame;
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] TextMeshProUGUI leftButtonText;
    [SerializeField] TextMeshProUGUI rightButtonText;
    [SerializeField] Sprite[] tier1Portraits;
    [SerializeField] Sprite[] tier2Portraits;
    [SerializeField] Sprite[] tier3Portraits;
    string[] tier1Classifications = { };
    string[] tier2Classifications = { 
        "bisexual", "failure", "poor", "sexually active", "melancholic", "wimpy", "schizophrenic", 
        "unsuccessful", "pansexual", "liberal", "conservative", "convict", "second-rater", "loser", 
        "basic", "unskilled", "uncool", "weakling", "sensitive", "introverted", "orphan", "impudent", 
        "crazy", "sad"
        };
    string[] tier3Classifications = { 
        "cocksucker", "homosexual closet queen", "motherfucker", "pervert", "drug junkie", "whore", 
        "bitch", "slut", "pedophile", "child molester", "rape suspect", "school shooter", "suicide bomber",
        "cunt", "transvestite", "street rat", "dickhead", "slave", "envious beta male", "incel"
        };
    // Start is called before the first frame update
    void Start()
    {
        portraitFrame.sprite = tier2Portraits[0];
        GenerateButtonTexts(leftButtonText, rightButtonText, tier2Classifications);
        //Debug.Log(tier2Classifications.Length);
        //Debug.Log(tier3Classifications.Length);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateButtonTexts(TextMeshProUGUI lb, TextMeshProUGUI rb, string[] array)
    {
        int randomIndex1 = (int)Random.Range(0f, array.Length - 1);
        int randomIndex2 = (int)Random.Range(0f, array.Length - 1);
        if (randomIndex2 == randomIndex1)
        {
            while(randomIndex2 == randomIndex1)
            {
                randomIndex2 = (int)Random.Range(0f, array.Length - 1);
            }
        }
        lb.text = array[randomIndex1];
        rb.text = array[randomIndex2];
    }

    void GenerateCorrectChoice(Button button)
    {
        int coinToss = (int) Random.Range(0f, 1f);
        if(coinToss == 1)
        {
            button.isCorrect 
            score++
        }
        else score--
        loadNextImage();
    }
}

//What if for tier 3 we have it where after picking the incorrect choice enough times, the AI will
//call out the evil researcher and kill itself 
