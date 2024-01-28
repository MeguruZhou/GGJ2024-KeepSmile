using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// 初始关卡
/// </summary>
public class Level0Manager : MonoBehaviour
{
    [Header("拖拽挂载") ]
    public MainButton mainButton;
    public SmileWhiteVer smileWhiteVer;


    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CompleteLevel0();
        }
    }
    /// <summary>
    /// 第0关通关时
    /// </summary>
    public void CompleteLevel0()
    {
        UIManager.Instance.StartPanelShowOut();
        Destroy(this.gameObject);
    }
}
