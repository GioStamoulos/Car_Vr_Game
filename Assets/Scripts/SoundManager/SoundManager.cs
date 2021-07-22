using System;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            if (sound.origin != null)
            {
                sound.source = sound.origin.AddComponent<AudioSource>();
            }
            else
            {
                sound.source = gameObject.AddComponent<AudioSource>();
            }

            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.spatialBlend = sound.spatialBlend;
        }
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }

}

