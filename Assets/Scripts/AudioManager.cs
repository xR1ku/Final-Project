using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour{
    [Header("---------Audio Sources---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("---------Audio Clips---------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip jump;
    public AudioClip[] ballBounce;

    
    private void Start(){
        musicSource.clip = background;
        //musicSource.loop = true;
        musicSource.Play();
    }
    

    public void playSFX(AudioClip sound){
        SFXSource.PlayOneShot(sound);
    }
}
