using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    [Tooltip("Makes the sound 3D (must include an origin object)")]
    [Range(0f, 1f)]
    public float spatialBlend;

    [Tooltip("If true the sound will Loop")]
    public bool looping;

    [Tooltip("If an object is placed here the sound will originate from that object")]
    public GameObject origin;

    [HideInInspector]
    public AudioSource source;
}
