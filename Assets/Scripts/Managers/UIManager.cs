using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
//Created From Chiwa

/// <summary>
/// UIManager 单例管理器
/// </summary>
public class UIManager : Singleton<UIManager>
{
    [Header("各个面板,在外面进行拖拽")]

    //ScreenSpaceCanvas
    public StartGamePanel startPanel;//游戏主界面Panel
    public BlackPanel blackPanel;//转场黑屏Panel UI之间的切换用主要是
    public TipPanel tipPanel;//提示面板
    //是否正在转场
    public bool isTransitioning;


    /// <summary>
    /// LEVEL0启用情况下初始启动面板隐藏
    /// </summary>
    public void StartPanelHidden()
    {
        startPanel.gameObject.SetActive(false);
    }

    public void StartPanelShowOut()
    {
        blackPanel.UIPanelTransition(() =>
        {
            startPanel.gameObject.SetActive(true);
        });
    }


    /// <summary>
    /// 游戏启动切换
    /// </summary>
    public void StartGameCloseMenu()
    {
        blackPanel.UIPanelTransition(() =>
        {
            startPanel.gameObject.SetActive(false);
        });
    }
    /// <summary>
    /// 纯粹场景切换
    /// </summary>
    public void PurlyChangeSceneFade()
    {
        blackPanel.UIPanelTransition(null);
    }


    public void ExitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();

    }
}
