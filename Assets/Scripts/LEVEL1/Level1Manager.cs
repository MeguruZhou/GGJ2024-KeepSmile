using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level1Manager : MonoBehaviour
{
    //草1，2，3
    public GameObject grass1;
    public GameObject grass2;
    public GameObject grass3;

    public GameObject endPoint;

    public GameObject currentGrass;

    //花和花的效果
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

    //吃草计数，吃1次牛1-牛2 ，吃3次牛2-牛3
    int grassCount;
    // Start is called before the first frame update
    void Start()
    {
        //草初始化
        grassCount = 0;
        cow1.Idle();
    }

    /// <summary>
    /// 草的点击事件主动调用到这里，传入草本身
    /// </summary>
    /// <param name="grass"></param>
    public void clickGrass(GameObject grass)
    {
        Debug.Log("点击草:" + grass.name);
        grassCount++;
        currentGrass = grass;
        //1 移动到草
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
            //牛1-牛2 吃第一次
            cow1.Eat();
            cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
            {
                //执行完之后隐藏草
                currentGrass.SetActive(false);
                cow1.Upgrade();
                cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
                {
                    //切换到牛2
                    cow1.End();
                    cow2.Idle();
                    //背景生成花朵
                    flower1.SetActive(true);
                    flower2.SetActive(true);
                    flower3.SetActive(true);
                    Debug.Log("生成花朵");
                });
            });
        }
        if (grassCount == 2)
        {
            //吃第二次草
            cow2.Eat();
            cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
            {
                currentGrass.SetActive(false);
                cow2.Idle();
            });
        }
        if (grassCount == 3)
        {
            //牛2-牛3 吃第三次草

            //牛2-牛3动画
            //树移入动画
            cow2.Eat();
            cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
            {
                //执行完之后隐藏草
                currentGrass.SetActive(false);
                cow2.Upgrade();
                cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
                {
                    //切换到牛3
                    cow2.End();
                    cow3.Idle();
                    //背景生成花朵
                    tree.SetActive(true);
                    Debug.Log("生成树");
                });
            });
        }

    }


    /// <summary>
    /// 点击树
    /// </summary>
    public void clickTree()
    {
        Debug.Log("点击树枝");
        //牛靠近树 移动
        cow.transform.DOMove(new Vector3(tree.transform.position.x, tree.transform.position.y), 2).OnComplete(delegate
        {
            cow3.Eat();
            cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
            {
                //执行完之后隐藏树
                tree.SetActive(false);
                cow3.Upgrade();
                cow.transform.DOMove(cow.transform.position, 2).OnComplete(delegate
                {
                    cow.transform.DOMoveY(endPoint.transform.position.y, 3);
                    Debug.Log("牛3升级结束");
                });
            });
        });
        //播放进食动画
        //牛3成长牛4动画
        //牛3贴纸变成牛4贴纸
        //牛4点火起飞动画
        //牛4向上移动出屏幕
        //转场
    }



    /// <summary>
    /// 吃花1
    /// </summary>
    public void clickFlower1()
    {
        Debug.Log("点击花朵1");
        flower1.SetActive(false);
        flowerBuff1.SetActive(true);
    }

    /// <summary>
    /// 吃花2
    /// </summary>
    public void clickFlower2()
    {
        Debug.Log("点击花朵2");
        flower2.SetActive(false);
        flowerBuff2.SetActive(true);
    }

    // <summary>
    /// 吃花3
    /// </summary>
    public void clickFlower3()
    {
        Debug.Log("点击花朵3");
        flower3.SetActive(false);
        flowerBuff3.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {

    }
}
