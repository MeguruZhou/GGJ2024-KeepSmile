using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    //��1��2��3
    public GameObject grass1;
    public GameObject grass2;
    public GameObject grass3;

    //���ͻ���Ч��
    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;
    public GameObject flowerBuff1;
    public GameObject flowerBuff2;
    public GameObject flowerBuff3;

    public GameObject tree;


    //�Բݼ�������1��ţ1-ţ2 ����3��ţ2-ţ3
    int grassCount;
    // Start is called before the first frame update
    void Start()
    {
        //�ݳ�ʼ��
        grassCount = 0;
        grass1.SetActive(true);
        grass2.SetActive(true);
        grass3.SetActive(true);

    }

    /// <summary>
    /// �ݵĵ���¼��������õ��������ݱ���
    /// </summary>
    /// <param name="grass"></param>
    public void clickGrass(GameObject grass)
    {
        Debug.Log(""
        grassCount++;

        if (grassCount == 1)
        {
            //ţ1-ţ2 �Ե�һ��
        }
        if (grassCount == 2)
        {
            //�Եڶ��β�
        }
        if (grassCount == 3)
        {
            //ţ2-ţ3 �Ե����β�

            //ţ2-ţ3����
            //�����붯��
        }

        //ִ����֮�����ز�
        grass.SetActive(false);
    }

    public void clickTree()
    {
        //ţ������ �ƶ�
        //���Ž�ʳ����
        //ţ3�ɳ�ţ4����
        //ţ3��ֽ���ţ4��ֽ
        //ţ4�����ɶ���
        //ţ4�����ƶ�����Ļ
        //ת��
    }



    /// <summary>
    /// �Ի�1
    /// </summary>
    public void eatFlower1()
    {
        Debug.Log("�������1");
        flower1.SetActive(false);
        flowerBuff1.SetActive(true);
    }

    /// <summary>
    /// �Ի�2
    /// </summary>
    public void eatFlower2()
    {
        Debug.Log("�������2");
        flower2.SetActive(false);
        flowerBuff2.SetActive(true);
    }

    // <summary>
    /// �Ի�3
    /// </summary>
    public void eatFlower3()
    {
        Debug.Log("�������3");
        flower3.SetActive(false);
        flowerBuff3.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {

    }
}
