using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource = null;
    
    
    private bool _playStart = false;

    // Update is called once per frame
    void Update()
    {
        if (_playStart == true && _audioSource.isPlaying == false)
        {

            Destroy(this.gameObject);

        }
    }

    public void SetAudioClip(AudioClip audio)
    {
        _audioSource.clip = audio;
        _audioSource.Play();
        _playStart = true;
        
    }
}
