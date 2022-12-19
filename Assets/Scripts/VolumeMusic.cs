using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMusic : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    float musicVolume = 1f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = musicVolume;    
    }
    public void UpdateVolume( float volume)
    {
        musicVolume = volume; 
    }    
}
