using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip successfullyTieredUp;
    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] [Range(0f, 1f)] float clickSoundVolume = 1f;
    [SerializeField] [Range(0f, 1f)] float successfullyTieredUpVolume = 1f;
    [SerializeField] [Range(0f, 1f)] float backgroundMusicVolume = 1f;

    private void Awake()
    {
        ManageSingleton();
    }

    public void PlayBackgroundMusic()
    {
    //TODO
    }

    public void PlayClickSoundClip()
    {
        PlayClip(clickSound, clickSoundVolume);
    }
    public void PlaySuccessfullyTieredUpClip()
    {
        PlayClip(successfullyTieredUp, successfullyTieredUpVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position, volume);
        }
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