using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//Created From Chiwa

/// <summary>
/// �¼�����
/// </summary>
public static class EventHandler
{
    //����ת�����
    //������������¼�
    public static event Action<string> TransitionEvent;
    public static void CallTransitionEvent(string sceneName)
    {
        TransitionEvent?.Invoke(sceneName);
    }
    //��������ǰ�¼�
    public static event Action BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }
    //�������غ��¼�
    public static event Action AfterSceneLoadedEvent;//bool���Ƿ������ֵ���˼
    public static void CallAfterSceneLoadedEvent()
    {
        AfterSceneLoadedEvent?.Invoke();
    }


    public static event Action StartNewGameEvent;
    public static void CallStartNewGameEvent()
    {
        StartNewGameEvent?.Invoke();
    }
    public static event Action BackToMenuEvent;
    public static void CallBackToMenuEvent()
    {
        BackToMenuEvent?.Invoke();
    }


    //��Ч����
    public static event Action<int> PlayVFXSoundEvent;
    //�ⲿʹ�õ�PlaySoundEvent
    public static void CallVFXSoundEvent(int VFXIndex)
    {
        PlayVFXSoundEvent?.Invoke(VFXIndex);
    }
    //����VFX��Ч
    public static event Action<int> VFXSoundEffect;
    public static void CallVFXSoundEffect(int soundDetails)
    {
        VFXSoundEffect?.Invoke(soundDetails);
    }
    //ת����Ч(��С��ת��)
    public static event Action<bool> ChangeSoundEffect;
    public static void CallChangeSoundEffect(bool isDa)
    {
        ChangeSoundEffect?.Invoke(isDa);
    }


    //��ʾ�¼�
    public static event Action<int> TipPanelOpen;
    public static void CallTipPanelOpen(int clipIndex)
    {
        TipPanelOpen?.Invoke(clipIndex);
    }
    public static event Action TipPanelClose;
    public static void CallTipPanelClose()
    {
        TipPanelClose?.Invoke();
    }

}
