using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created From Chiwa

/// <summary>
/// 这里存放所有的特定固定数据
/// </summary>
public class Settings
{

    //渐入渐出时间
    public const float fadeTime = 0.27f;

    //提示面板显示时间
    public const float tipProgressTime = 2.5f;

    //判定为笑容的Python参数大于值
    public const float smileThreshold = 1f;

    //记录为笑容保持的所需时间
    public const float isSmileKeepingNeedTime=2.5f;
    //笑容失去多少时间算保持失败
    public const float isSmileKeepingLoseNeedTime = 1f;


    //音效系统里面 BGM和环境音的渐变时间
    public const float BGMChangeTime = 1.5f;

}
