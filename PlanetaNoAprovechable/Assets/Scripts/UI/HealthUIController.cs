using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUIController : MonoBehaviour
{
    
    public GameObject heartContainer;
    GameObject player;
    float fillValue;

    void Start()
    {
        player = GameObject.Find("Robin");
    }

    // Update is called once per frame
    void Update()
    {
        fillValue = player.GetComponent<Robin>().currenthealth;
        fillValue = fillValue / 3;
        heartContainer.GetComponent<Image>().fillAmount = fillValue;
    }
}
