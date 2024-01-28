using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// ��Ц���ô���
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
            Debug.Log("Ц��Ц��!");
            level0Manager.mainButton.level0Progress = 2;
        }
        
    }
    //���������¼�
    public void StartFirstSmiling()
    {
        anim.SetBool("SmilingFirst", false);
    }
    //��ʾ��屣��΢Ц
    public void MidFirstSmiling()
    {
        EventHandler.CallTipPanelOpen(1);
    }
    //�ƽ�����
    public void EndFirstSmiling()
    {
        level0Manager.mainButton.level0Progress = 3;

    }

}
