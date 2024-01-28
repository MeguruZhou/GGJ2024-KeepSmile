using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// ��������Ԥ�����ļ�
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class OneSound : MonoBehaviour
{
    //�ⲿ��ק��
    [SerializeField] private AudioSource audioSource;

    public void SetSound(AudioClip soundClip)
    {
        audioSource.clip = soundClip;
    }
}
