using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField]
    private Slider RegulVolume;

    static public float volume;

    void Start()
    {
        RegulVolume.value = volume;
    }

    void Update()
    {
        volume = RegulVolume.value;
    }

}
