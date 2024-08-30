using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] MusicManager musicManager;
    AudioSource Music;

    private void Start(){
        Music = musicManager.GetComponent<AudioSource>();
        UnPauseGame();
    }



    public void PauseGame(){
        Time.timeScale = 0f;
        Music.Pause();
    }

    public void UnPauseGame(){
        Time.timeScale = 1f;
        Music.Play();
    }
}
