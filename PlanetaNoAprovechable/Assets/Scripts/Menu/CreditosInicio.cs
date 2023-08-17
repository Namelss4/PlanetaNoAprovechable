using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosInicio : MonoBehaviour
{

    float timer = 9.0f;
    float currTime;

    public GameObject MainPanel;
    public GameObject BGMusic;
    public GameObject Hyacilux;
    bool acopi = false;

    void Start()
    {
        currTime = timer;
    }

    void Update()
    {
        currTime -= Time.deltaTime;
        if (currTime < 0 && !acopi){
            menu();
        }
        else if (currTime < 0 && acopi){
            Debug.Log("a");
            menu2();
        }
    }

    void menu(){
        Hyacilux.SetActive(true);
        currTime = 4.0f;
        acopi = true;
    }

    void menu2(){
        gameObject.SetActive(false);
        Hyacilux.SetActive(false);
        BGMusic.SetActive(true);
        MainPanel.SetActive(true);
    }
}
