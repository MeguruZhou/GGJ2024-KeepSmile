using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
//Created From Chiwa

/// <summary>
/// ����� UnityAPI
/// </summary>
public class PoolManager : Singleton<PoolManager>
{
    //������������Ԥ����
    public List<GameObject> poolPrefabs;
    //��ӦԤ����Ķ����
    private List<ObjectPool<GameObject>> poolEffectList = new List<ObjectPool<GameObject>>();
    //��Ч�������
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
    /// ���ɶ����
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

    //�������:
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
