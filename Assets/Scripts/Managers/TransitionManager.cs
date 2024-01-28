using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Created From Chiwa

/// <summary>
/// 场景转换Manager
/// </summary>
public class TransitionManager : Singleton<TransitionManager>
{
    [Header("NewGame时候的场景是?")]
    public string startSceneName = string.Empty;

    [Header("当前关卡通过之后会前往的下个场景是?通过每一关的NextSceneChecker确定")]
    public string nextSceneIs = string.Empty;

    private bool isLoadCompleted;
    public void SetIsLoadCompleted(bool isCompleted)
    {
        isLoadCompleted = isCompleted;
    }

    protected override void Awake()
    {
        base.Awake();
        isLoadCompleted = true;
    }
    private void OnEnable()
    {


        EventHandler.TransitionEvent += OnTransitionEvent;
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
        EventHandler.BackToMenuEvent += BackToMenuEvent;
    }
    private void OnDisable()
    {


        EventHandler.TransitionEvent -= OnTransitionEvent;
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
        EventHandler.BackToMenuEvent -= BackToMenuEvent;
    }

    public void SetNextScene(string nextSceneName)
    {
        nextSceneIs=nextSceneName;
    }
    public void ChangeToNextScene()
    {
        EventHandler.CallTransitionEvent(nextSceneIs);
    }

    private void OnTransitionEvent(string sceneToGo)
    {
        if (isLoadCompleted)
        {
            StartCoroutine(Transition(sceneToGo));
        }

    }
    private void BackToMenuEvent()
    {
        StartCoroutine(UnloadScene());
    }

    private void OnStartNewGameEvent()
    {
        StartCoroutine(LoadSaveDataScene(startSceneName));
    }


    /// <summary>
    /// 场景切换
    /// </summary>
    /// <param name="sceneName">目标场景</param>
    /// <param name="targetPosition">目标位置</param>
    /// <returns></returns>
    private IEnumerator Transition(string sceneName)
    {
        //Step1.开始加载场景 置F加载完成 显示渐隐面板
        isLoadCompleted = false;

        UIManager.Instance.PurlyChangeSceneFade();
        //StepEX.强行暂停.75秒
        yield return new WaitForSeconds(Settings.fadeTime * 3f);
        //Step2.Call卸载场景前应该触发的事件
        EventHandler.CallBeforeSceneUnloadEvent();
        //Step3.卸载当前激活场景 这里算30进度
        AsyncOperation unloadAsync = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        while (!unloadAsync.isDone)
        {
            //float progress = unloadAsync.progress / 0.9f * 0.3f;
            //UIManager.Instance.fadePanel.SetLoadingProgress(progress);
            yield return null;
        }
        //Step4.加载下一个场景并设置为激活
        yield return LoadSceneSetActive(sceneName);
        //Step6.Call加载完之后做什么事件
        EventHandler.CallAfterSceneLoadedEvent();

        //Step7.不再显示渐隐面板,并在完全隐的时候置T 加载完成
        //UIManager.Instance.fadePanel.EndTransitionFade();//isLoadCompleted将在这个EndTransitionFade中被置T;
        isLoadCompleted = true;

    }
    /// <summary>
    /// 加载场景并设置为激活
    /// </summary>
    /// <param name="sceneName">场景名</param>
    /// <returns></returns>
    private IEnumerator LoadSceneSetActive(string sceneName)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!loadAsync.isDone)
        {
            //float progress = loadAsync.progress / 0.9f * 0.7f + 0.3f;
            //UIManager.Instance.fadePanel.SetLoadingProgress(progress);
            yield return null;
        }
        //因为数量是一个是1  而计数是从0开始+1+1  所以这里要-1(即层级面板中最下方的场景)才能取到刚刚加载到的场景
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        //设置为激活
        SceneManager.SetActiveScene(newScene);
    }

    /// <summary>
    /// 新游戏开始!
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private IEnumerator LoadSaveDataScene(string sceneName)
    {
        //StepEX.强行暂停.75秒
        UIManager.Instance.StartGameCloseMenu();
        yield return new WaitForSeconds(Settings.fadeTime * 3f);

        if (SceneManager.GetActiveScene().name != "PersistentScene")    //在游戏过程中 加载另外游戏进度
        {
            EventHandler.CallBeforeSceneUnloadEvent();

            AsyncOperation unloadAsync = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            while (!unloadAsync.isDone)
            {
                float progress = unloadAsync.progress / 0.9f * 0.3f;
                //UIManager.Instance.fadePanel.SetLoadingProgress(progress);
                yield return null;
            }

        }

        yield return LoadSceneSetActive(sceneName);
        EventHandler.CallAfterSceneLoadedEvent();
        //UIManager.Instance.fadePanel.EndTransitionFade();
        isLoadCompleted = true;
    }

    /// <summary>
    /// 回到游戏主页
    /// </summary>
    /// <returns></returns>
    private IEnumerator UnloadScene()
    {
        EventHandler.CallBeforeSceneUnloadEvent();
        //UIManager.Instance.fadePanel.StartTransitionFade();
        //StepEX.强行暂停.75秒
        UIManager.Instance.StartPanelShowOut();
        yield return new WaitForSeconds(Settings.fadeTime * 3f);
        AsyncOperation unloadAsync = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        while (!unloadAsync.isDone)
        {
            //float progress = unloadAsync.progress / 0.9f * 0.3f;
            //UIManager.Instance.fadePanel.SetLoadingProgress(progress);
            yield return null;
        }
        UIManager.Instance.startPanel.canvasGroup.alpha = 0f;
        UIManager.Instance.startPanel.canvasGroup.interactable = false;
        UIManager.Instance.startPanel.gameObject.SetActive(true);

        yield return UIManager.Instance.startPanel.canvasGroup.DOFade(1, Settings.fadeTime * 4).OnComplete(() =>
        {
            UIManager.Instance.startPanel.canvasGroup.interactable = true;
        }).WaitForCompletion();
        //UIManager.Instance.fadePanel.EndTransitionFade();
        isLoadCompleted = true;

    }

 
}
