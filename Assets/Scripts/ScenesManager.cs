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
        //scoreKeeper = FindObjectOfType<ScoreKeeper>();
        //scoreKeeper.ResetScore();
        SceneManager.LoadScene(0);
    }
    public void LoadDialogueScene()
    {
        //tierTracker = FindObjectOfType<TierTracker>();
        //tierTracker.ResetScore();
        SceneManager.LoadScene("Dialogue Scene");
    }
    public void LoadMainScene()
    {
        //tierTracker = FindObjectOfType<TierTracker>();
        //tierTracker.ResetScore();
        SceneManager.LoadScene("Main Scene");
    }

    /*public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }*/

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