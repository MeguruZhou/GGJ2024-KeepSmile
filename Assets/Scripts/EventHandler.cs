using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//Created From Chiwa

/// <summary>
/// 事件中心
/// </summary>
public static class EventHandler
{
    //场景转换相关
    //场景传送相关事件
    public static event Action<string> TransitionEvent;
    public static void CallTransitionEvent(string sceneName)
    {
        TransitionEvent?.Invoke(sceneName);
    }
    //场景加载前事件
    public static event Action BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }
    //场景加载后事件
    public static event Action AfterSceneLoadedEvent;//bool是是否切音乐的意思
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


    //音效播放
    public static event Action<int> PlayVFXSoundEvent;
    //外部使用的PlaySoundEvent
    public static void CallVFXSoundEvent(int VFXIndex)
    {
        PlayVFXSoundEvent?.Invoke(VFXIndex);
    }
    //播放VFX音效
    public static event Action<int> VFXSoundEffect;
    public static void CallVFXSoundEffect(int soundDetails)
    {
        VFXSoundEffect?.Invoke(soundDetails);
    }
    //转变音效(大小调转换)
    public static event Action<bool> ChangeSoundEffect;
    public static void CallChangeSoundEffect(bool isDa)
    {
        ChangeSoundEffect?.Invoke(isDa);
    }


    //提示事件
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
