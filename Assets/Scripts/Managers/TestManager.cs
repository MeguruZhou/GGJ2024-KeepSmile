using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// �����ù�����
/// </summary>
public class TestManager : Singleton<TestManager>
{
    [Header("�Ƿ���ʾ��0������")]
    public TestState ts;

    public Level0Manager level0Manager;

    protected override void Awake()
    {
        base.Awake();
        if (level0Manager != null)
        {
            if (ts == TestState.BeginAtLevel0)
            {
                UIManager.Instance.StartPanelHidden();
                level0Manager.gameObject.SetActive(true);
            }
            else if (ts == TestState.BeginAtLevel1)
            {
                UIManager.Instance.StartPanelShowOut();
                level0Manager.gameObject.SetActive(false);
            }
        }
        else
        {
            UIManager.Instance.StartPanelShowOut();
        }

    }


}
public enum TestState
{
    BeginAtLevel0,
    BeginAtLevel1,
}
