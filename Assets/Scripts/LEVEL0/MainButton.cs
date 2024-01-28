using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// LEVEL0按钮的代码
/// </summary>
public class MainButton : MonoBehaviour
{
    public SpriteRenderer sr2d;
    public Level0Manager level0Manager;
    //外面拖拽赋值
    public Sprite[] btnSprites;

    public int clickCount = 0;//0阶段等于1次未点,1阶段等于点了一次后,2阶段为微笑演出后再点击一次→等待一会儿后进入主界面
    public int level0Progress = 0;//0阶段等于1次未点,1阶段等于点了1次后未进行微笑,2阶段为进行微笑和演出时,3阶段为微笑演出结束,等待下一次点击

    public int opsCount = 0;

    private void Start()
    {
        clickCount = 0;
        sr2d = GetComponent<SpriteRenderer>();
        level0Manager = GetComponentInParent<Level0Manager>();
    }
    private void Update()
    {

    }
    private void OnMouseDown()
    {
        if (clickCount == 0 && level0Progress == 0)
        {
            sr2d.sprite = btnSprites[1];
            EventHandler.CallVFXSoundEvent(6);
            EventHandler.CallTipPanelOpen(0);
            opsCount += 1;
            clickCount += 1;
            level0Progress += 1;
        }
        if (clickCount == 1 && level0Progress == 1 && opsCount < 3)
        {
            EventHandler.CallTipPanelOpen(0);
            opsCount += 1;
        }

        if (level0Progress == 3)
        {
            level0Manager.CompleteLevel0();
        }

    }
}
