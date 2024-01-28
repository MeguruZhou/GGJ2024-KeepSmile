using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
//Created From Chiwa

/// <summary>
/// 对象池 UnityAPI
/// </summary>
public class PoolManager : Singleton<PoolManager>
{
    //对象池内物体的预制体
    public List<GameObject> poolPrefabs;
    //对应预制体的对象池
    private List<ObjectPool<GameObject>> poolEffectList = new List<ObjectPool<GameObject>>();
    //音效对象队列
    private Queue<GameObject> soundQueue = new Queue<GameObject>();

    private void Start()
    {
        CreatePool();
    }

    private void OnEnable()
    {
        EventHandler.VFXSoundEffect += InitSoundEffect;
    }
    private void OnDisable()
    {
        EventHandler.VFXSoundEffect -= InitSoundEffect;
    }

    /// <summary>
    /// 生成对象池
    /// </summary>
    private void CreatePool()
    {
        foreach (GameObject item in poolPrefabs)
        {
            Transform parent = new GameObject(item.name).transform;
            parent.SetParent(transform);

            var newPool = new ObjectPool<GameObject>(
                () => Instantiate(item, parent),
                e => { e.SetActive(true); },
                e => { e.SetActive(false); },
                e => { Destroy(e); }
            );

            poolEffectList.Add(newPool);
        }
    }

    //声音相关:
    private void CreateSoundPool()
    {
        Transform parent = new GameObject(poolPrefabs[0].name).transform;
        parent.SetParent(this.transform);

        for (int i = 0; i < 20; i++)
        {
            GameObject newObj = Instantiate(poolPrefabs[0], parent);
            newObj.SetActive(false);
            soundQueue.Enqueue(newObj);
        }
    }

    private GameObject GetPoolObject()
    {
        if (soundQueue.Count < 2)
            CreateSoundPool();
        return soundQueue.Dequeue();
    }

    private void InitSoundEffect(int VFXIndex)
    {
        var obj = GetPoolObject();
        AudioClip tempClip = AudioManager.Instance.VFXAudioClips[VFXIndex];

        obj.GetComponent<OneSound>().SetSound(tempClip);
        obj.SetActive(true);
        StartCoroutine(DisableSound(obj, tempClip.length));
    }

    private IEnumerator DisableSound(GameObject obj, float duration)
    {
        yield return new WaitForSeconds(duration);
        obj.SetActive(false);
        soundQueue.Enqueue(obj);
    }


}
