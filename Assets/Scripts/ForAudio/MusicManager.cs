using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance {get;private set;}
    
    private AudioSource[] musicSources;

    public event System.Action<int> ChangeMusicEvent;

    private void Awake()
    {
        // Ensure only one instance of MusicManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSources = GetComponents<AudioSource>();

        RedCross.OnMusicChangeRequest +=ChangeMusic;
        Magnit.OnMusicChangeRequest +=ChangeMusic;
        
        foreach (var musicSource in musicSources)
        {
            musicSource.volume = 0.0f; 
            musicSource.Play();
        }
        musicSources[0].volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeMusic(int musicIndex)
    {
        // Handle changing the music based on the index received
        for (int i = 0; i < musicSources.Length; i++)
        {
            musicSources[i].volume = (i == musicIndex) ? 1.0f : 0.0f;
        }
    }
}
