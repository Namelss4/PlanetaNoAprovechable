using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePCController : MonoBehaviour
{

    public GameObject UpgradePanel;
    bool isClose = false;
    bool isActive = false;
    Robin playerController;

    void OnTriggerStay2D(Collider2D other) {
        isClose = true;

        playerController = other.GetComponent<Robin>();
    }

    void OnTriggerExit2D(Collider2D other) {
        isClose = false;
    }

    void Update(){
        openPanel();
    }

    void openPanel(){
        if ((isClose && Input.GetKeyDown("e")) || (isClose && Input.GetKeyDown("escape") && isActive)){
            isActive = !isActive;
            UpgradePanel.SetActive(isActive);

            if(isActive){
                playerController.currState = robinState.cantAct;
            }
            else{
                playerController.currState = robinState.canAct;
            }
        }
    }
}
