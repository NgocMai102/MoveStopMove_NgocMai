using System.Collections.Generic;
using _Framework.Singleton;
using _Game.Scripts.Manager.Data;
using UnityEngine;

public enum AudioTye
{
    SFX_ButtonClick = 0,
    SFX_PlayerDie = 1,
    SFX_ThrowWeapon = 2,
    SFX_SizeUp = 3,
    SFX_WeaponHit = 4,
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] List<AudioClip> clips = new List<AudioClip>();

    [SerializeField] private List<AudioSource> audioSources = new List<AudioSource>();

    private PlayerData PlayerData => DataManager.Instance.PlayerData;

    private bool isSoundOn => PlayerData.isSound;

    private void Start()
    {
        for (int i = 0; i < clips.Count; i++)
        {
            GameObject audioObject = new GameObject("AudioSource_" + i);

            AudioSource audioSource = audioObject.AddComponent<AudioSource>();

            audioSource.clip = clips[i];

            audioSources.Add(audioSource);

            audioObject.transform.SetParent(transform);
        }
    }
    public void Play(AudioType type)
    {
        if(isSoundOn) {
            audioSources[(int)type]?.Play();
        }   
    }
}
