using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string type;
    public Sprite icon;
    public bool empty = true;
    public int amountHeld;

    public void UpdateSlot(){
        GameObject ObjectIcon = this.transform.GetChild(0).gameObject;
        if (amountHeld > 0){
            this.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = $"{amountHeld}";
            ObjectIcon.GetComponent<Image>().enabled = true;
            ObjectIcon.GetComponent<Image>().sprite = icon;
        }
        else{
            ObjectIcon.GetComponent<Image>().enabled = false;
            this.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            ID = 0;
            type = "";
        }


    }
}
