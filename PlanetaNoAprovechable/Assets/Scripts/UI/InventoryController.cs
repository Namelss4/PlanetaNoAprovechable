using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    private bool isEnabled = false;
    public GameObject inventoryGO;
    public GameObject slotHandler;

    int totalSlots;

    GameObject[] slot;

    float timer = 0.1f;

    public Dictionary<int, int> inventoryHash = new Dictionary<int, int>();

    void Start(){
        inventoryGO.SetActive(isEnabled);
        totalSlots = slotHandler.transform.childCount;
        slot = new GameObject[totalSlots];

        for (int i = 0; i < totalSlots; i++)
        {
            slot[i] = slotHandler.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown("i") || (isEnabled && Input.GetKeyDown("escape"))){
            isEnabled = !isEnabled;
            inventoryGO.SetActive(isEnabled);
            if(isEnabled){
                GetComponent<Robin>().currState = robinState.cantAct;
            }
            else{
                GetComponent<Robin>().currState = robinState.canAct;
            }
        }

        timer -= Time.deltaTime;

    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Collectible"){
            GameObject itemPicked = other.gameObject;
            CollectibleController itemController = itemPicked.GetComponent<CollectibleController>();
            if (timer < 0){
                Destroy(itemPicked);
                addItem(itemController);
                timer = 0.1f;
           }  
        }
    }

    void addItem(CollectibleController itemController){
        SlotController currSlot;
        for (int i = 0; i < totalSlots; i++)
        {
            currSlot = slot[i].GetComponent<SlotController>();
            if (currSlot.empty){
                currSlot.empty = false;
                currSlot.ID = itemController.ID;
                currSlot.type = itemController.type;
                currSlot.icon = itemController.icon;
                currSlot.ID = itemController.ID;
                currSlot.amountHeld = 1;

                inventoryHash.Add(itemController.ID, 1);
                currSlot.UpdateSlot();
                return;
            }
            else if (currSlot.ID == itemController.ID){
                currSlot.amountHeld += 1;
                inventoryHash[itemController.ID] += 1;
                currSlot.UpdateSlot();
                return;
            }
        }
    }

    public void removeItem(int ID, int amount){
        SlotController currSlot;
        for (int i = 0; i < totalSlots; i++){
            currSlot = slot[i].GetComponent<SlotController>();
            if(currSlot.ID == ID){
                currSlot.amountHeld -= amount;
                inventoryHash[ID] -= amount;

                currSlot.UpdateSlot();

                if(currSlot.amountHeld == 0){
                    currSlot.empty = true;
                    inventoryHash.Remove(ID);
                }
                return;
            }
        }
    }
}
