using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// Ц�ݼ��
/// </summary>
public class SmileCheck : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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

    }
}
