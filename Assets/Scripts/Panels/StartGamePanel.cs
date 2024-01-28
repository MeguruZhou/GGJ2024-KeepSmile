using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//Created From Chiwa

/// <summary>
/// 开始游戏面板
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
        //todo:游戏启动跳转到LEVEL1
        Debug.Log("游戏启动");
    }
    public void ExitGame()
    {
        EventHandler.CallVFXSoundEvent(0);
        UIManager.Instance.ExitGame();
    }
}
