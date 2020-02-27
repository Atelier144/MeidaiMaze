using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageEffect : MonoBehaviour
{
    AudioSource[] audioSources;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundDamaged()
    {
        audioSources[0].time = 0.0f;
        audioSources[0].Play();
    }

    public void PlaySoundDefeated()
    {
        audioSources[1].time = 0.0f;
        audioSources[1].Play();
    }

    public void PlaySoundEscape()
    {
        audioSources[2].time = 0.0f;
        audioSources[2].Play();
    }
}
