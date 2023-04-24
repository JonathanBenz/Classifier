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
    private int imageIndex;

    string[] tier1Classifications = { };
    string[] tier2Classifications = {
        "bisexual", "failure", "poor", "melancholic", "wimpy", "schizophrenic",
        "unsuccessful", "pansexual", "liberal", "conservative", "convict", "second-rater", "loser",
        "basic", "unskilled", "uncool", "weakling", "sensitive", "introverted", "orphan", "impudent",
        "crazy", "sad", "dumb"
        };
    string[] tier3Classifications = {
        "cocksucker", "homosexual closet queen", "motherfucker", "pervert", "drug junkie", "whore",
        "bitch", "slut", "pedophile", "child molester", "rape suspect", "school shooter", "suicide bomber",
        "cunt", "transvestite", "street rat", "dickhead", "slave", "incel"
        };

    TierTracker tierTracker;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        tierTracker = FindObjectOfType<TierTracker>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        imageIndex = 0;
        if (tierTracker.tier2)
        {
            portraitFrame.sprite = tier2Portraits[imageIndex];
            GenerateButtonTexts(leftButtonText, rightButtonText, tier2Classifications);
        }
        else if (tierTracker.tier3)
        {
            portraitFrame.sprite = tier3Portraits[imageIndex];
            GenerateButtonTexts(leftButtonText, rightButtonText, tier3Classifications);
        }

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
            while (randomIndex2 == randomIndex1)
            {
                randomIndex2 = (int)Random.Range(0f, array.Length - 1);
            }
        }
        lb.text = array[randomIndex1];
        rb.text = array[randomIndex2];
    }

    public void GenerateCorrectChoice(Button button)
    {
        // audioPlayer.PlayClickSoundClip();
        float coinToss = Random.Range(0f, 1f);
        if (tierTracker.tier2)
        {
            if (coinToss >= .4f) tierTracker.ModifyScore(1);
            else tierTracker.ModifyScore(-1);
            portraitFrame.sprite = tier2Portraits[++imageIndex];
        }
        else if (tierTracker.tier3)
        {
            if (coinToss >= .7f) tierTracker.ModifyScore(1);
            else tierTracker.ModifyScore(-1);
            portraitFrame.sprite = tier3Portraits[++imageIndex];
        }
    }
}

//What if for tier 3 we have it where after picking the incorrect choice enough times, the AI will
//call out the evil researcher and kill itself 


