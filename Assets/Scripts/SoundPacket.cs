using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="SFX/SoundEffect")]
public class SoundPacket : ScriptableObject
{
    [SerializeField]
    public AudioClip Sound;

    [Range(0, 1)]
    public float VolumeMax = 1;
    [Range(0, 1)]
    public float VolumeMin = 0.8f;

    [Range(-3, 3)]
    public float PitchMax = 1.2f;
    [Range(-3, 3)]
    public float PitchMin = 0.8f;



    public void PlaySound(AudioSource target)
    {
        target.volume = Random.Range(VolumeMin, VolumeMax);
        target.volume = Random.Range(PitchMin, PitchMax);
        target.PlayOneShot(Sound);
    }


    private void OnValidate()
    {
        if(PitchMin > PitchMax)
        {
            PitchMin = PitchMax;
        }
        if(VolumeMin > VolumeMax)
        {
            VolumeMin = VolumeMax;
        }

    }
}
