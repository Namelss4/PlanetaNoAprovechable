using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUp1Controller : MonoBehaviour
{

    Button _button;
    public GameObject pistolButton;
    public GameObject Upgradelvl1Panel;
    public GameObject Upgradelvl2Panel;
    public GameObject Robin;

    public GameObject bullPrefab;

    public Sprite bullLVL2;

    PistolButtonController PBC;
    InventoryController inventory;
    Robin playerController;

    public AudioClip upgradeClip;

    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(upgradeLVL1);
        PBC = pistolButton.GetComponent<PistolButtonController>();
        inventory = Robin.GetComponent<InventoryController>();
        playerController = Robin.GetComponent<Robin>();

    }

    void upgradeLVL1()
    {
        if(inventory.inventoryHash[5] >= 5 && inventory.inventoryHash[4] >= 8){
            playerController.PlaySound(upgradeClip);
            Upgradelvl2Panel.SetActive(true);
            PBC.upgradeCount = 1;
            Upgradelvl1Panel.SetActive(false);
            inventory.removeItem(5, 5);
            inventory.removeItem(4, 8);

            bullPrefab.GetComponent<BulletController>().damage = 3;
            bullPrefab.GetComponent<SpriteRenderer>().sprite = bullLVL2;
        }
    }
}
