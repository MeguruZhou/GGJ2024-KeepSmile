using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// 笑容检测管理器
/// </summary>
public class SmileCheckManager : Singleton<SmileCheckManager>
{
    //当前是否正在笑
    public bool isSmiling = false;
    public float smileFloat = -1;

    //是否保持微笑
    public bool isKeepingSmiling = false;
    public float keepingSmilingCounter = 0f;

    public float loseSmilingCounter = 0f;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        //连续保持笑一定时间可以进入微笑保持状态
        if (isSmiling)
        {
            loseSmilingCounter = 0;
            keepingSmilingCounter += Time.deltaTime;
            if (keepingSmilingCounter >= Settings.isSmileKeepingNeedTime)
            {
                isKeepingSmiling = true;
            }
        }

        //连续不笑一定时间 微笑保持状态结束
        if (!isSmiling)
        {
            loseSmilingCounter += Time.deltaTime;
            if (loseSmilingCounter >= Settings.isSmileKeepingLoseNeedTime)
            {
                isKeepingSmiling = false;
                keepingSmilingCounter = 0f;
            }
        }

    }
    /// <summary>
    /// 供外界调用,返回实时笑容状态
    /// </summary>
    /// <returns></returns>
    public bool GetCurrentIsSmiling()
    {
        return isSmiling;
    }
    /// <summary>
    /// 供外界调用,返回是否在保持笑容的状态
    /// </summary>
    /// <returns></returns>
    public bool GetCurrentKeepingSmiling()
    {
        return isKeepingSmiling;
    }


    /// <summary>
    /// 通过Python.cs实时设定,当前笑容参数值为
    /// </summary>
    /// <param name="SmileFloat"></param>
    public void SetSmileFloat(float SmileFloat)
    {
        smileFloat = SmileFloat;
        if (smileFloat > Settings.smileThreshold)
        {
            isSmiling = true;
        }
        else
        {
            isSmiling = false;
        }
    }
}
