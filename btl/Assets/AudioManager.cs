using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    private void Awake() {
        if( instance == null ) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            // s.source.loop = s.loop;
        }
    }
    void Start()
    {
        
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.loop = true;
        s.source.Play();
    }

    public void DestroyLoop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.loop = false;
    }
}
