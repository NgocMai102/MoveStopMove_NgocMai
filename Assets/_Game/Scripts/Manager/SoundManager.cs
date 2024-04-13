using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Singleton;
using UnityEngine;

public enum AudioType
{
    SoundFX_Throw = 0,
    SoundFX_Hit = 1,
    SoundFX_Die = 2,
    SoundFX_Revive = 3,
    SoundFX_Victory = 4,
    SoundFX_Lose = 5,
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private List<AudioClip> audioClips;

    [SerializeField] private AudioClip testAudioClip;

    public void SetSound(AudioType type)
    {
        
    }
}
