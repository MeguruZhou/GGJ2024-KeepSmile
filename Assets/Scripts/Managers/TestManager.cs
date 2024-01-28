using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// 测试用管理器
/// </summary>
public class TestManager : Singleton<TestManager>
{
    [Header("是否显示第0关内容")]
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
