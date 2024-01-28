using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level1Manager : MonoBehaviour
{
    //��1��2��3
    public GameObject grass1;
    public GameObject grass2;
    public GameObject grass3;

    public GameObject endPoint;

    public GameObject currentGrass;

    //���ͻ���Ч��
    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;
    public GameObject flowerBuff1;
    public GameObject flowerBuff2;
    public GameObject flowerBuff3;

    public GameObject tree;

    public GameObject cow;
    public CowCtrl cow1;
    public CowCtrl cow2;
    public CowCtrl cow3;
    public CowCtrl cow4;

    //�Բݼ�������1��ţ1-ţ2 ����3��ţ2-ţ3
    int grassCount;
    // Start is called before the first frame update
    void Start()
    {
        //�ݳ�ʼ��
        grassCount = 0;
        cow1.Idle();
    }

    /// <summary>
    /// �ݵĵ���¼��������õ��������ݱ���
    /// </summary>
    /// <param name="grass"></param>
    public void clickGrass(GameObject grass)
    {
        Debug.Log("�����:" + grass.name);
        grassCount++;
        currentGrass = grass;
        //1 �ƶ�����
        Vector3 grassPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (grassCount == 1)
        {
            cow1.Walk();
        }
        if (grassCount == 2)
        {
            cow2.Walk();
        }
        if (grassCount == 3)
        {
            cow2.Walk();
        }
        if (grassCount == 4)
        {
            cow3.Walk();
        }
        cow.transform.DOMove(new Vector3(grassPos.x, grassPos.y), 2).OnComplete(delegate { checkGrass(); });

    }

    void checkGrass()
    {
        if (grassCount == 1)
        {
            //ţ1-ţ2 �Ե�һ��
            cow1.Eat();
            cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
            {
                //ִ����֮�����ز�
                currentGrass.SetActive(false);
                cow1.Upgrade();
                cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
                {
                    //�л���ţ2
                    cow1.End();
                    cow2.Idle();
                    //�������ɻ���
                    flower1.SetActive(true);
                    flower2.SetActive(true);
                    flower3.SetActive(true);
                    Debug.Log("���ɻ���");
                });
            });
        }
        if (grassCount == 2)
        {
            //�Եڶ��β�
            cow2.Eat();
            cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
            {
                currentGrass.SetActive(false);
                cow2.Idle();
            });
        }
        if (grassCount == 3)
        {
            //ţ2-ţ3 �Ե����β�

            //ţ2-ţ3����
            //�����붯��
            cow2.Eat();
            cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
            {
                //ִ����֮�����ز�
                currentGrass.SetActive(false);
                cow2.Upgrade();
                cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
                {
                    //�л���ţ3
                    cow2.End();
                    cow3.Idle();
                    //�������ɻ���
                    tree.SetActive(true);
                    Debug.Log("������");
                });
            });
        }

    }


    /// <summary>
    /// �����
    /// </summary>
    public void clickTree()
    {
        Debug.Log("�����֦");
        //ţ������ �ƶ�
        cow.transform.DOMove(new Vector3(tree.transform.position.x, tree.transform.position.y), 2).OnComplete(delegate
        {
            cow3.Eat();
            cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
            {
                //ִ����֮��������
                tree.SetActive(false);
                cow3.Upgrade();
                cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
                {
                    cow.transform.DOMoveY(endPoint.transform.position.y, 3);
                    Debug.Log("ţ3��������");
                });
            });
        });
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
    public void clickFlower1()
    {
        Debug.Log("�������1");
        flower1.SetActive(false);
        flowerBuff1.SetActive(true);
    }

    /// <summary>
    /// �Ի�2
    /// </summary>
    public void clickFlower2()
    {
        Debug.Log("�������2");
        flower2.SetActive(false);
        flowerBuff2.SetActive(true);
    }

    // <summary>
    /// �Ի�3
    /// </summary>
    public void clickFlower3()
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
