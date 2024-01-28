using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// Ц�ݼ�������
/// </summary>
public class SmileCheckManager : Singleton<SmileCheckManager>
{
    //��ǰ�Ƿ�����Ц
    public bool isSmiling = false;
    public float smileFloat = -1;

    //�Ƿ񱣳�΢Ц
    public bool isKeepingSmiling = false;
    public float keepingSmilingCounter = 0f;

    public float loseSmilingCounter = 0f;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        //��������Цһ��ʱ����Խ���΢Ц����״̬
        if (isSmiling)
        {
            loseSmilingCounter = 0;
            keepingSmilingCounter += Time.deltaTime;
            if (keepingSmilingCounter >= Settings.isSmileKeepingNeedTime)
            {
                isKeepingSmiling = true;
            }
        }

        //������Цһ��ʱ�� ΢Ц����״̬����
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
    /// ��������,����ʵʱЦ��״̬
    /// </summary>
    /// <returns></returns>
    public bool GetCurrentIsSmiling()
    {
        return isSmiling;
    }
    /// <summary>
    /// ��������,�����Ƿ��ڱ���Ц�ݵ�״̬
    /// </summary>
    /// <returns></returns>
    public bool GetCurrentKeepingSmiling()
    {
        return isKeepingSmiling;
    }


    /// <summary>
    /// ͨ��Python.csʵʱ�趨,��ǰЦ�ݲ���ֵΪ
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
