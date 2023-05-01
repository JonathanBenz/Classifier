using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    //[SerializeField] float sceneLoadDelay = 2f;
    TierTracker tierTracker;

    private void Awake()
    {
        tierTracker = FindObjectOfType<TierTracker>();
    }
    public void LoadMainMenu()
    {
        tierTracker = FindObjectOfType<TierTracker>();
        tierTracker.ResetScore();
        SceneManager.LoadScene(0);
    }
    public void LoadDialogueScene()
    {
        if (tierTracker.tier3) SceneManager.LoadScene("Dialogue3 Scene");
        else if (tierTracker.tier2) SceneManager.LoadScene("Dialogue2 Scene");
        else SceneManager.LoadScene("Dialogue1 Scene");
    }
    public void LoadFailureScene()
    {
        tierTracker = FindObjectOfType<TierTracker>();
        tierTracker.ResetScore();
        SceneManager.LoadScene("Failure Scene");
    }
    public void LoadMainScene()
    {
        if (tierTracker.endGame)
        {
            tierTracker.endGame = false;
            LoadMainMenu();
        }
        else
        {
            tierTracker = FindObjectOfType<TierTracker>();
            tierTracker.ResetScore();
            SceneManager.LoadScene("Main Scene");
        }
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("End Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    /*IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }*/
}

