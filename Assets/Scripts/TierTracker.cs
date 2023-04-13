using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierTracker : MonoBehaviour
{
    private int score;
    private void Awake()
    {
        ManageSingleton();
    }

    public int GetScore() { return score; }
    public void ModifyScore(int value) { score += value; }
    public void ResetScore() { score = 0; }

    void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }
}