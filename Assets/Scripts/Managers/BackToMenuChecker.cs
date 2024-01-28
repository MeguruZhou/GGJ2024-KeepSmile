using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// 
/// </summary>
public class BackToMenuChecker : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            EventHandler.CallBackToMenuEvent();
        }
    }
}
