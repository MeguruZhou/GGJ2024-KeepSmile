using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowCtrl : MonoBehaviour
{
    public GameObject idle;
    public GameObject walk;
    public GameObject eat;
    public GameObject upgrade;

    // Start is called before the first frame update
    

    public void End()
    {
        idle.SetActive(false);
        walk.SetActive(false);
        eat.SetActive(false);
        upgrade.SetActive(false);
    }
    public void Idle()
    {
        idle.SetActive(true);
        walk.SetActive(false);
        eat.SetActive(false);
        upgrade.SetActive(false);
    }

    public void Walk()
    {
        idle.SetActive(false);
        walk.SetActive(true);
        eat.SetActive(false);
        upgrade.SetActive(false);
    }

    public void Eat()
    {
        idle.SetActive(false);
        walk.SetActive(false);
        eat.SetActive(true);
        upgrade.SetActive(false);

    }

    public void Upgrade()
    {
        idle.SetActive(false);
        walk.SetActive(false);
        eat.SetActive(false);
        upgrade.SetActive(true);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
