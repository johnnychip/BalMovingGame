using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    #region Properties

    public List<AudioSource> music = new List<AudioSource>();
    public List<AudioSource> effects = new List<AudioSource>();

    //Singleton!
    public static AudioManager Instance
    {
        get; private set;
    }

    #endregion

    #region Unity functions

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);

        GetAudioSources();
    }

    #endregion

    #region Class functions

    private void GetAudioSources() //Improve! --- Async
    {
        AudioSource[] audioSourcesInScene = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach(AudioSource audioSource in audioSourcesInScene)
        {
            switch (audioSource.tag)
            {
                case "Music":
                    music.Add(audioSource);
                    break;

                case "Effect":
                    effects.Add(audioSource);
                    break;

                default:
                    break;
            }
        }
    }

    public void Music (bool state)
    {
        foreach (AudioSource audioSource in music)
            audioSource.mute = !state;
    }

    public void Effects (bool state)
    {
        foreach (AudioSource audioSource in music)
            audioSource.mute = !state;
    }

    #endregion
}
