using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Created From Chiwa

/// <summary>
/// ����ת��Manager
/// </summary>
public class TransitionManager : Singleton<TransitionManager>
{
    [Header("NewGameʱ��ĳ�����?")]
    public string startSceneName = string.Empty;

    [Header("��ǰ�ؿ�ͨ��֮���ǰ�����¸�������?ͨ��ÿһ�ص�NextSceneCheckerȷ��")]
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
    /// �����л�
    /// </summary>
    /// <param name="sceneName">Ŀ�곡��</param>
    /// <param name="targetPosition">Ŀ��λ��</param>
    /// <returns></returns>
    private IEnumerator Transition(string sceneName)
    {
        //Step1.��ʼ���س��� ��F������� ��ʾ�������
        isLoadCompleted = false;

        UIManager.Instance.PurlyChangeSceneFade();
        //StepEX.ǿ����ͣ.75��
        yield return new WaitForSeconds(Settings.fadeTime * 3f);
        //Step2.Callж�س���ǰӦ�ô������¼�
        EventHandler.CallBeforeSceneUnloadEvent();
        //Step3.ж�ص�ǰ����� ������30����
        AsyncOperation unloadAsync = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        while (!unloadAsync.isDone)
        {
            //float progress = unloadAsync.progress / 0.9f * 0.3f;
            //UIManager.Instance.fadePanel.SetLoadingProgress(progress);
            yield return null;
        }
        //Step4.������һ������������Ϊ����
        yield return LoadSceneSetActive(sceneName);
        //Step6.Call������֮����ʲô�¼�
        EventHandler.CallAfterSceneLoadedEvent();

        //Step7.������ʾ�������,������ȫ����ʱ����T �������
        //UIManager.Instance.fadePanel.EndTransitionFade();//isLoadCompleted�������EndTransitionFade�б���T;
        isLoadCompleted = true;

    }
    /// <summary>
    /// ���س���������Ϊ����
    /// </summary>
    /// <param name="sceneName">������</param>
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
        //��Ϊ������һ����1  �������Ǵ�0��ʼ+1+1  ��������Ҫ-1(���㼶��������·��ĳ���)����ȡ���ոռ��ص��ĳ���
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        //����Ϊ����
        SceneManager.SetActiveScene(newScene);
    }

    /// <summary>
    /// ����Ϸ��ʼ!
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private IEnumerator LoadSaveDataScene(string sceneName)
    {
        //StepEX.ǿ����ͣ.75��
        UIManager.Instance.StartGameCloseMenu();
        yield return new WaitForSeconds(Settings.fadeTime * 3f);

        if (SceneManager.GetActiveScene().name != "PersistentScene")    //����Ϸ������ ����������Ϸ����
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
    /// �ص���Ϸ��ҳ
    /// </summary>
    /// <returns></returns>
    private IEnumerator UnloadScene()
    {
        EventHandler.CallBeforeSceneUnloadEvent();
        //UIManager.Instance.fadePanel.StartTransitionFade();
        //StepEX.ǿ����ͣ.75��
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
