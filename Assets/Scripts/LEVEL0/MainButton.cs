using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// LEVEL0��ť�Ĵ���
/// </summary>
public class MainButton : MonoBehaviour
{
    public SpriteRenderer sr2d;
    public Level0Manager level0Manager;
    //������ק��ֵ
    public Sprite[] btnSprites;

    public int clickCount = 0;//0�׶ε���1��δ��,1�׶ε��ڵ���һ�κ�,2�׶�Ϊ΢Ц�ݳ����ٵ��һ�Ρ��ȴ�һ��������������
    public int level0Progress = 0;//0�׶ε���1��δ��,1�׶ε��ڵ���1�κ�δ����΢Ц,2�׶�Ϊ����΢Ц���ݳ�ʱ,3�׶�Ϊ΢Ц�ݳ�����,�ȴ���һ�ε��

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
