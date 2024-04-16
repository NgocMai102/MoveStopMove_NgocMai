using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Singleton;
using _Game.Scripts.Manager.Data;
using UnityEngine;



public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    [SerializeField] private List<AudioSource> audioSources = new List<AudioSource>();
    
    private PlayerData PlayerData => DataManager.Instance.PlayerData;
    

    public void SetSound(AudioType type)
    {
        
    }
}
