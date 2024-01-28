using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using DG.Tweening;
//Created From Chiwa

/// <summary>
/// ��Ч������
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
    [Header("�������ݿ�")]

    public AudioClip[] BGMAudioClips;//0=��׼BGM
    public AudioClip[] VFXAudioClips;//0=��ť���

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


    //��Ϸ����ʱ���ŵ�����
    public void AwakeSound()
    {
        PlayMusicClip(0);
    }

    //�ı䵱ǰBGM����������
    public void ChangeSceneSound(int  BGMIndex)
    {
        //�������������
        if (BGMIndex < BGMAudioClips.Length)
        {
            //�����ǰû�����ڲ��ŵ�BGM
            if (gameSource.clip != null)
            {
                gameSource.volume = 0;
                PlayMusicClip(BGMIndex);
                gameSource.DOFade(1, Settings.BGMChangeTime).SetEase(Ease.Linear);
            }
            //�����ǰ�����ڲ��ŵ�BGM
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
    /// ���ű�������
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
