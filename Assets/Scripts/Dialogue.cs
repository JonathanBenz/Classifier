using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Credit to the video "5 Minute DIALOGUE SYSTEM in UNITY Tutorial" by YouTuber BMo for this script.
public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] Image dialogueIndicator;
    [SerializeField] float dialogueIndicatorTransformSpeed;
    [SerializeField] string[] lines;
    [SerializeField] float textDelay;
    private int index;
    float startingPoint;

    ScenesManager scenesManager;
    // Start is called before the first frame update
    void Start()
    {
        scenesManager = FindObjectOfType<ScenesManager>();
        textComponent.text = string.Empty;
        startingPoint = dialogueIndicator.transform.position.y;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateDialogueIndicator();
        if(Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index]) NextLine();
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textDelay);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else scenesManager.LoadMainScene();
    }

    void AnimateDialogueIndicator()
    {
        float min = startingPoint + 3;
        float max = startingPoint - 5;
        dialogueIndicator.transform.position += new Vector3(0, dialogueIndicatorTransformSpeed * Time.deltaTime, 0);
        if (dialogueIndicator.transform.position.y >= min || dialogueIndicator.transform.position.y <= max) dialogueIndicatorTransformSpeed = -dialogueIndicatorTransformSpeed;
    }
}
