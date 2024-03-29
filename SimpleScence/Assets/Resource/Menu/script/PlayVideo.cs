﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayVideo : MonoBehaviour
{
    public MovieTexture movie;
    public GameObject movieObject;
    public GameObject menuObject;
    public GameObject SettingObject;
    public GameObject background;
    public AudioSource audioSource;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        SettingObject.SetActive(false);
        menuObject.SetActive(false);
        background.SetActive(false);
        audioSource.Stop();
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!movie.isPlaying)
        {
            movieObject.SetActive(false);
            menuObject.SetActive(true);
            background.SetActive(true);
            audioSource.Play();
        }
    }
}
