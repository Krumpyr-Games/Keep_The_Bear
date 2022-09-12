using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisValueVolume : MonoBehaviour
{
    [SerializeField]
    private AudioSource Audio;

    Buttons b = new Buttons();

    void Start()
    {

    }

    void Update()
    {
        Audio.volume = VolumeSettings.volume;
    }
}
