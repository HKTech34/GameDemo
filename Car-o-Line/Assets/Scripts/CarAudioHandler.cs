using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudioHandler : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update() // This code makes car sound everytime user draw line
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Pause();
        }
        if (Input.GetMouseButtonUp(0))
        {
            audioSource.Play();
        }
    }
}
