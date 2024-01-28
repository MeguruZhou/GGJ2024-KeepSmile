using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
//Created From Chiwa

/// <summary>
/// UIManager ����������
/// </summary>
public class UIManager : Singleton<UIManager>
{
    [Header("�������,�����������ק")]

    //ScreenSpaceCanvas
    public StartGamePanel startPanel;//��Ϸ������Panel
    public BlackPanel blackPanel;//ת������Panel UI֮����л�����Ҫ��
    public TipPanel tipPanel;//��ʾ���
    //�Ƿ�����ת��
    public bool isTransitioning;


    /// <summary>
    /// LEVEL0��������³�ʼ�����������
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
    /// ��Ϸ�����л�
    /// </summary>
    public void StartGameCloseMenu()
    {
        blackPanel.UIPanelTransition(() =>
        {
            startPanel.gameObject.SetActive(false);
        });
    }
    /// <summary>
    /// ���ⳡ���л�
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
