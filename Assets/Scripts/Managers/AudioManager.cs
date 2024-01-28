using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using DG.Tweening;
//Created From Chiwa

/// <summary>
/// 音效管理器
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
    [Header("音乐数据库")]

    public AudioClip[] BGMAudioClips;//0=标准BGM
    public AudioClip[] VFXAudioClips;//0=按钮点击

    [Header("Audio Source")]
    public AudioSource gameSource;


    [Header("Audio Mixer")]
    public AudioMixer audioMixer;


    protected override void Awake()
    {
        base.Awake();
        AwakeSound();
    }
    private void OnEnable()
    {
        EventHandler.PlayVFXSoundEvent += OnPlayVFXSoundEvent;
        EventHandler.BackToMenuEvent += BackToMenuMusic;
    }

    private void OnDisable()
    {
        EventHandler.PlayVFXSoundEvent -= OnPlayVFXSoundEvent;
        EventHandler.BackToMenuEvent -= BackToMenuMusic;
    }

    private void BackToMenuMusic()
    {
        AwakeSound();
    }

    private void OnPlayVFXSoundEvent(int VFXIndex)
    {
        if (VFXIndex <= VFXAudioClips.Length)
        {
            EventHandler.CallVFXSoundEffect(VFXIndex);
        }

    }


    //游戏开局时播放的音乐
    public void AwakeSound()
    {
        PlayMusicClip(0);
    }

    //改变当前BGM至哪首曲子
    public void ChangeSceneSound(int  BGMIndex)
    {
        //如果音乐有数据
        if (BGMIndex < BGMAudioClips.Length)
        {
            //如果当前没有正在播放的BGM
            if (gameSource.clip != null)
            {
                gameSource.volume = 0;
                PlayMusicClip(BGMIndex);
                gameSource.DOFade(1, Settings.BGMChangeTime).SetEase(Ease.Linear);
            }
            //如果当前有正在播放的BGM
            else if (gameSource.clip != BGMAudioClips[BGMIndex])
            {
                gameSource.DOFade(0, Settings.BGMChangeTime).SetEase(Ease.Linear).OnComplete(() =>
                {
                    PlayMusicClip(BGMIndex);
                    gameSource.DOFade(1, Settings.BGMChangeTime);
                });
            }


        }
       

    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="soundIndex"></param>
    private void PlayMusicClip(int soundIndex)
    {
        audioMixer.SetFloat("MusicVolume", ConvertSoundVolume(0.3f));
        gameSource.clip =BGMAudioClips[soundIndex];
        if (gameSource.isActiveAndEnabled)
            gameSource.Play();
    }

    private float ConvertSoundVolume(float amount)
    {
        return (amount * 100 - 80);
    }


}
