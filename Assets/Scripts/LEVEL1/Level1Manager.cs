using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    //草1，2，3
    public GameObject grass1;
    public GameObject grass2;
    public GameObject grass3;

    //花和花的效果
    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;
    public GameObject flowerBuff1;
    public GameObject flowerBuff2;
    public GameObject flowerBuff3;

    public GameObject tree;


    //吃草计数，吃1次牛1-牛2 ，吃3次牛2-牛3
    int grassCount;
    // Start is called before the first frame update
    void Start()
    {
        //草初始化
        grassCount = 0;
        grass1.SetActive(true);
        grass2.SetActive(true);
        grass3.SetActive(true);

    }

    /// <summary>
    /// 草的点击事件主动调用到这里，传入草本身
    /// </summary>
    /// <param name="grass"></param>
    public void clickGrass(GameObject grass)
    {
        Debug.Log(""
        grassCount++;

        if (grassCount == 1)
        {
            //牛1-牛2 吃第一次
        }
        if (grassCount == 2)
        {
            //吃第二次草
        }
        if (grassCount == 3)
        {
            //牛2-牛3 吃第三次草

            //牛2-牛3动画
            //树移入动画
        }

        //执行完之后隐藏草
        grass.SetActive(false);
    }

    public void clickTree()
    {
        //牛靠近树 移动
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
    public void eatFlower1()
    {
        Debug.Log("点击花朵1");
        flower1.SetActive(false);
        flowerBuff1.SetActive(true);
    }

    /// <summary>
    /// 吃花2
    /// </summary>
    public void eatFlower2()
    {
        Debug.Log("点击花朵2");
        flower2.SetActive(false);
        flowerBuff2.SetActive(true);
    }

    // <summary>
    /// 吃花3
    /// </summary>
    public void eatFlower3()
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
