using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audiosource;
    void Start()
    {
        audiosource = FindObjectOfType<AudioSource>();
        audiosource.loop = false;
        audiosource.clip = clips[0];
        audiosource.Play();

    }

    void Update()
    {

        if(!audiosource.isPlaying)
        {

            audiosource.clip = clips[1];//Random.Range(0, clips.Length)];
            audiosource.Play();
            audiosource.loop = true;

        }
    }


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
