using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolButtonController : MonoBehaviour
{

    Button _button;
    public GameObject UpgradeHandler;

    public int upgradeCount = 0;

    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(showUpgrade);
    }

    // Update is called once per frame
    void showUpgrade()
    {
        if(upgradeCount == 0){
            UpgradeHandler.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(upgradeCount == 1){
            UpgradeHandler.transform.GetChild(1).gameObject.SetActive(true);
        }
        else{
            UpgradeHandler.transform.GetChild(2).gameObject.SetActive(true);
        }
        
    }
}
