using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// 白笑脸用代码
/// </summary>
public class SmileWhiteVer : MonoBehaviour
{
    public Animator anim;
    public Level0Manager level0Manager;

    void Start()
    {
        anim=GetComponent<Animator>();
        level0Manager=GetComponentInParent<Level0Manager>();
    }

    void Update()
    {
        if (SmileCheckManager.Instance.GetCurrentIsSmiling())
        {
            anim.SetBool("IsSmiling", true);
        }
        else
        {
            anim.SetBool("IsSmiling", false);
        }

        if(level0Manager.mainButton.level0Progress == 1&& SmileCheckManager.Instance.GetCurrentKeepingSmiling())
        {
            anim.SetBool("SmilingFirst", true);
            Debug.Log("笑咯笑咯!");
            level0Manager.mainButton.level0Progress = 2;
        }
        
    }
    //动画调用事件
    public void StartFirstSmiling()
    {
        anim.SetBool("SmilingFirst", false);
    }
    //提示面板保持微笑
    public void MidFirstSmiling()
    {
        EventHandler.CallTipPanelOpen(1);
    }
    //推进进度
    public void EndFirstSmiling()
    {
        level0Manager.mainButton.level0Progress = 3;

    }

}
