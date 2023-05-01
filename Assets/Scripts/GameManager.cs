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
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] Sprite[] tier1Portraits;
    [SerializeField] Sprite[] tier2Portraits;
    [SerializeField] Sprite[] tier3Portraits;
    private int imageIndex;

    string[] tier1Classifications = { "pink hair", "blue hair", "cyclops", "third eye", "orange skin", 
        "green skin", "smiling", "frowning", "snout nose", "beak nose"};
    string[] tier2Classifications = {
        "bisexual", "failure", "poor", "melancholic", "wimpy", "schizophrenic",
        "unsuccessful", "pansexual", "liberal", "conservative", "convict", "second-rater", "loser",
        "basic", "unskilled", "uncool", "weakling", "sensitive", "introverted", "orphan", "impudent",
        "crazy", "sad", "dumb", "undesirable"
        };
    string[] tier3Classifications = {
        "cocksucker", "motherfucker", "pervert", "drug junkie", "whore",
        "bitch", "slut", "pedophile", "child molester", "rape suspect", "school shooter", "suicide bomber",
        "cunt", "street rat", "dickhead", "slave", "predator"
        };

    TierTracker tierTracker;
    AudioPlayer audioPlayer;
    ScenesManager sceneManager;

    private void Awake()
    {
        tierTracker = FindObjectOfType<TierTracker>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        sceneManager = FindObjectOfType<ScenesManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        imageIndex = 0;
        if (tierTracker.tier3)
        {
            portraitFrame.sprite = tier3Portraits[imageIndex];
            GenerateButtonTexts(leftButtonText, rightButtonText, tier3Classifications);
        }
        else if (tierTracker.tier2)
        {
            portraitFrame.sprite = tier2Portraits[imageIndex];
            GenerateButtonTexts(leftButtonText, rightButtonText, tier2Classifications);
        }
        else
        {
            portraitFrame.sprite = tier1Portraits[imageIndex];
            GenerateButtonTexts(leftButtonText, rightButtonText, tier1Classifications, 0);
        }

        //Debug.Log(tier2Classifications.Length);
        //Debug.Log(tier3Classifications.Length);

    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }
    void DisplayScore()
    {
        score.text = "Score: " + tierTracker.GetScore().ToString();
    }

    void GenerateButtonTexts(TextMeshProUGUI lb, TextMeshProUGUI rb, string[] array, int index)
    {
        lb.text = array[index];
        rb.text = array[index+1];
    }
    void GenerateButtonTexts(TextMeshProUGUI lb, TextMeshProUGUI rb, string[] array)
    {
        int randomIndex1 = (int)Random.Range(0f, array.Length - 1);
        int randomIndex2 = (int)Random.Range(0f, array.Length - 1);
        if (randomIndex2 == randomIndex1)
        {
            while (randomIndex2 == randomIndex1)
            {
                randomIndex2 = (int)Random.Range(0f, array.Length - 1);
            }
        }
        lb.text = array[randomIndex1];
        rb.text = array[randomIndex2];
    }

    public void GenerateCorrectChoice(TextMeshProUGUI buttonText)
    {
        audioPlayer.PlayClickSoundClip();
        float coinToss = Random.Range(0f, 1f);
        // Tier 3
        if (tierTracker.tier3)
        {
            if (imageIndex >= tier3Portraits.Length - 1)
            {
                tierTracker.endGame = true;
                sceneManager.LoadEndScene();
            }
            if (coinToss >= .56f) tierTracker.ModifyScore(1);
            else tierTracker.ModifyScore(-1);
            portraitFrame.sprite = tier3Portraits[++imageIndex];
            GenerateButtonTexts(leftButtonText, rightButtonText, tier3Classifications);
        }
        // Tier 2
        else if (tierTracker.tier2)
        {
            if (imageIndex >= tier2Portraits.Length - 1) sceneManager.LoadFailureScene();
            if (coinToss >= .32f) tierTracker.ModifyScore(1);
            else tierTracker.ModifyScore(-1);
            portraitFrame.sprite = tier2Portraits[++imageIndex];
            GenerateButtonTexts(leftButtonText, rightButtonText, tier2Classifications);

            if (tierTracker.GetScore() == 5)
            {
                tierTracker.tier3 = true;
                sceneManager.LoadDialogueScene();
            }
        }
        // Tier 1
        else
        {
            if (imageIndex == 0)
            {
                if (buttonText.GetParsedText().Equals(tier1Classifications[0])) tierTracker.ModifyScore(1);
                else tierTracker.ModifyScore(-1);
                portraitFrame.sprite = tier1Portraits[++imageIndex];
                GenerateButtonTexts(leftButtonText, rightButtonText, tier1Classifications, 2);
            }
            else if (imageIndex == 1)
            {
                if (buttonText.GetParsedText().Equals(tier1Classifications[3])) tierTracker.ModifyScore(1);
                else tierTracker.ModifyScore(-1);
                portraitFrame.sprite = tier1Portraits[++imageIndex];
                GenerateButtonTexts(leftButtonText, rightButtonText, tier1Classifications, 4);
            }
            else if (imageIndex == 2)
            {
                if (buttonText.GetParsedText().Equals(tier1Classifications[5])) tierTracker.ModifyScore(1);
                else tierTracker.ModifyScore(-1);
                portraitFrame.sprite = tier1Portraits[++imageIndex];
                GenerateButtonTexts(leftButtonText, rightButtonText, tier1Classifications, 6);
            }
            else if (imageIndex == 3)
            {
                if (buttonText.GetParsedText().Equals(tier1Classifications[6])) tierTracker.ModifyScore(1);
                else tierTracker.ModifyScore(-1);
                portraitFrame.sprite = tier1Portraits[++imageIndex];
                GenerateButtonTexts(leftButtonText, rightButtonText, tier1Classifications, 8);
            }
            else if (imageIndex == 4)
            {
                if (buttonText.GetParsedText().Equals(tier1Classifications[9])) tierTracker.ModifyScore(1);
                else tierTracker.ModifyScore(-1);
                if (tierTracker.GetScore() == 5)
                {
                    tierTracker.tier2 = true;
                    sceneManager.LoadDialogueScene();
                }
                else sceneManager.LoadFailureScene();
            }
        }
    }
}

//What if for tier 3 we have it where after picking the incorrect choice enough times, the AI will
//call out the evil researcher and kill itself 


