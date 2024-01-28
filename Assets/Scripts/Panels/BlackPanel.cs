using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
//Created From Chiwa

/// <summary>
/// 黑屏转场Panel
/// </summary>
public class BlackPanel : MonoBehaviour
{
    [Header("外面拖拽")]
    public CanvasGroup cg;

    public Animator anim;

    public void UIPanelTransition(Action action)
    {
        UIManager.Instance.isTransitioning = true;
        cg.blocksRaycasts = true;
        cg.interactable = true;
        anim.Play("FadeAnimation");
        cg.DOFade(0.99f, Settings.fadeTime).OnComplete(() =>
        {
            
            cg.DOFade(1, 1f).OnComplete(() =>
            {
                action?.Invoke();
                cg.DOFade(0, Settings.fadeTime).OnComplete(() =>
                {
                    cg.blocksRaycasts = false;
                    cg.interactable = false;
                    UIManager.Instance.isTransitioning = false;
                });
            });
        });
    }
    /// <summary>
    /// ANIMATION EVENT
    /// </summary>
    public void ResetAnim()
    {
        anim.SetBool("PlayOnce", false);
    }
}
