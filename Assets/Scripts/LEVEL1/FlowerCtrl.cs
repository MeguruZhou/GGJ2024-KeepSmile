using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCtrl : MonoBehaviour
{

    public GameObject start;
    public GameObject idle;

    public void Create()
    {
        start.SetActive(true);
        idle.SetActive(false);
    }

    public void Idle()
    {
        start.SetActive(false);
        idle.SetActive(true);
    }

    public void End()
    {
        start.SetActive(false);
        idle.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
