using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MusicTransitioner : MonoBehaviour
{
    public AudioSource CurrentMusic;


    private float Duration;



    public void TransitionToMusic(AudioSource newMusic)
    {
        CurrentMusic.DOFade(0, Duration);
        newMusic.DOFade(1, Duration);
        CurrentMusic = newMusic;
    }

    public void SetDuration(float timeInSeconds)
    {
        Duration = timeInSeconds;
    }
}
