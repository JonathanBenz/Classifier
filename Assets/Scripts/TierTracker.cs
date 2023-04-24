using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierTracker : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] int numIncorrect;
    public bool tier1 = true;
    public bool tier2 = true;
    public bool tier3;
    private void Awake()
    {
        ManageSingleton();
    }
    private void Update()
    {
        TrackTier();
    }
    public int GetScore() { return score; }
    public void ModifyScore(int value) { score += value; if (value < 0) numIncorrect++; if (score < 0) score = 0; }
    public void ResetScore() { score = 0; numIncorrect = 0; }
    public void TrackTier()
    {
        if (score >= 8) UnlockNextTier();
    }
    void UnlockNextTier()
    {
        if (!tier2 && !tier3) tier2 = true;
        if (tier2 && !tier3) tier3 = true;
    }

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

