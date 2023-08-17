using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUp2Controller : MonoBehaviour
{
    Button _button;
    public GameObject pistolButton;
    public GameObject NoMoreUpgPanel;
    public GameObject Upgradelvl2Panel;
    public GameObject Robin;

    public GameObject bullPrefab;

    public Sprite bullLVL3;

    PistolButtonController PBC;
    InventoryController inventory;

    public AudioClip upgradeClip;
    Robin playerController;

    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(upgradeLVL2);
        PBC = pistolButton.GetComponent<PistolButtonController>();
        inventory = Robin.GetComponent<InventoryController>();
        playerController = Robin.GetComponent<Robin>();

    }

    void upgradeLVL2()
    {
        if(inventory.inventoryHash[5] >= 8 && inventory.inventoryHash[4] >= 14){
            playerController.PlaySound(upgradeClip);
            PBC.upgradeCount = 2;
            Upgradelvl2Panel.SetActive(false);
            inventory.removeItem(5, 8);
            inventory.removeItem(4, 14);

            bullPrefab.GetComponent<BulletController>().damage = 5;
            bullPrefab.GetComponent<SpriteRenderer>().sprite = bullLVL3;
            NoMoreUpgPanel.SetActive(true);
            
        }
    }
}
