using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// ��ʼ�ؿ�
/// </summary>
public class Level0Manager : MonoBehaviour
{
    [Header("��ק����") ]
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
    /// ��0��ͨ��ʱ
    /// </summary>
    public void CompleteLevel0()
    {
        UIManager.Instance.StartPanelShowOut();
        Destroy(this.gameObject);
    }
}
