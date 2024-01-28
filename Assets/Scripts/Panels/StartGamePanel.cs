using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//Created From Chiwa

/// <summary>
/// ��ʼ��Ϸ���
/// </summary>
public class StartGamePanel : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public Button startBtn;
    public Button exitBtn;
    private void OnEnable()
    {
        startBtn.onClick.AddListener(StartGame);
        exitBtn.onClick.AddListener(ExitGame);
    }
    private void OnDisable()
    {
        startBtn.onClick.RemoveListener(StartGame);
        exitBtn.onClick.RemoveListener(ExitGame);
    }
    
 
    


    public void StartGame()
    {
        EventHandler.CallVFXSoundEvent(0);
       
        EventHandler.CallStartNewGameEvent();
        //todo:��Ϸ������ת��LEVEL1
        Debug.Log("��Ϸ����");
    }
    public void ExitGame()
    {
        EventHandler.CallVFXSoundEvent(0);
        UIManager.Instance.ExitGame();
    }
}
