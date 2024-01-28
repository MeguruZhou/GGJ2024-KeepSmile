using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// 单个声音预制体文件
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class OneSound : MonoBehaviour
{
    //外部拖拽绑定
    [SerializeField] private AudioSource audioSource;

    public void SetSound(AudioClip soundClip)
    {
        audioSource.clip = soundClip;
    }
}
