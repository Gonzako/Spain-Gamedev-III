using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SFX/SoundEffectList")]
public class SoundPacketList : ScriptableObject
{

    [SerializeField]
    List<SoundPacket> Sounds;

    public void PlaySound(AudioSource target)
    {
        Sounds[Random.Range(0, Sounds.Count)].PlaySound(target);
    }

}
