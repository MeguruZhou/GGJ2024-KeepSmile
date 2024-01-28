using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
//Created From Chiwa

/// <summary>
/// 提示面板
/// </summary>
public class TipPanel : MonoBehaviour
{
    public CanvasGroup tipCanvasGroup;

    //内容物TIP的动画
    public Animator tipInSideAnim;
    private void OnEnable()
    {
        EventHandler.TipPanelOpen += OpenTipPanel;
        EventHandler.TipPanelClose += CloseTipPanel;
    }
    private void OnDisable()
    {
        EventHandler.TipPanelOpen -= OpenTipPanel;
        EventHandler.TipPanelClose -= CloseTipPanel;
    }
    public void OpenTipPanel(int clipIndex)
    {
        tipInSideAnim.SetInteger("InsideIndex", clipIndex);
        tipCanvasGroup.DOFade(0.99f, Settings.fadeTime * 1.5f).OnComplete(() =>
        {
            tipCanvasGroup.DOFade(1f, Settings.tipProgressTime).OnComplete(() =>
            {
                CloseTipPanel();
            });
        });
    }

    public void CloseTipPanel()
    {
        tipCanvasGroup.DOFade(0, Settings.fadeTime);
    }
}
