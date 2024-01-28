using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Created From Chiwa

/// <summary>
/// 每个场景都有的用于检测下一关的
/// </summary>
public class NextSceneCheker : MonoBehaviour
{
    public string sceneName = string.Empty;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TempCheck();
        }
    }

    public void TempCheck()
    {
        TransitionManager.Instance.ChangeToNextScene();
    }

    private void OnEnable()
    {
        TransitionManager.Instance.SetNextScene(sceneName);
    }

}
