using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource _audioSource;
    public bool loaded;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
        PlayStopMusic();
        if(FindObjectOfType<MusicController>().loaded)
        {
            Destroy(gameObject);
        }
        loaded = true;
    }

    public void PlayStopMusic()
    {
        if (_audioSource.isPlaying) 
        { 
            _audioSource.Stop(); 
        }
        else
            _audioSource.Play();
    }
}
