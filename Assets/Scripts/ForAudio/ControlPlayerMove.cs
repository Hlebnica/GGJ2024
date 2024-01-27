using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerMove : MonoBehaviour
{
    public Transform bodyTransform;
    public Gosling gosling;
    public Sys sys;
    public Kibidka kibidka;

    private AudioSource goslingAudio;
    private AudioSource sysAudio;
    private AudioSource kibidkaAudio;


    private bool isPlayingGosling = false;
    private bool isPlayingSys = false;
    private bool isPlayingKibidka = false;

    private float fadeDuration = 0.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        goslingAudio = gosling.GetComponent<AudioSource>();
        goslingAudio.Stop();

        sysAudio = sys.GetComponent<AudioSource>();
        sysAudio.Stop();

        kibidkaAudio = kibidka.GetComponent<AudioSource>();
        kibidkaAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(bodyTransform.position, gosling.transform.position);

        if (distance < 5.0f && !isPlayingGosling)
        {
            if (!goslingAudio.isPlaying) 
            {
                StartCoroutine(FadeOutAndPlay(goslingAudio, sysAudio, kibidkaAudio));
            }
        }

        distance = Vector3.Distance(bodyTransform.position, sys.transform.position);
        if (distance < 5.0f && !isPlayingSys)
        {
            if (!sysAudio.isPlaying) 
            {
                StartCoroutine(FadeOutAndPlay(sysAudio, goslingAudio, kibidkaAudio));

            }
        }
        
        distance = Vector3.Distance(bodyTransform.position, kibidka.transform.position);
        if (distance < 4.0f && !isPlayingKibidka)
        {
            if (! kibidkaAudio.isPlaying) 
            {
                StartCoroutine(FadeOutAndPlay(kibidkaAudio, goslingAudio, sysAudio));

            }
            
        }
        
    }

    IEnumerator FadeOutAndPlay(AudioSource audioToFade, params AudioSource[] otherAudios)
    {
        float startVolume = audioToFade.volume;

        if (audioToFade.isPlaying)
        {
            while (audioToFade.volume > 0)
            {
                audioToFade.volume -= startVolume * Time.deltaTime / fadeDuration;
                yield return null;
            }

            audioToFade.Stop();
            audioToFade.volume = startVolume;
        }

        foreach (var otherAudio in otherAudios)
        {
            if (otherAudio.isPlaying)
            {
                float otherStartVolume = otherAudio.volume;

                while (otherAudio.volume > 0)
                {
                    otherAudio.volume -= otherStartVolume * Time.deltaTime / fadeDuration;
                    yield return null;
                }

                otherAudio.Stop();
                otherAudio.volume = otherStartVolume;
            }
        }

        if (!audioToFade.isPlaying)
        {
            audioToFade.Play();
        }
    }

}
