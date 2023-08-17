using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsController : MonoBehaviour
{
    public bool isBig;

    void OnTriggerEnter2D(Collider2D other) 
    {
        Robin playerController = other.GetComponent<Robin>();
        Debug.Log($"Colisionó con:  {other.gameObject}");
        if (playerController != null)
        {
            if (playerController.currenthealth < playerController.maxhealth)
            {
                if (isBig){
                    playerController.changeHealth(1);
                    Destroy(gameObject); 
                }
                else{
                    playerController.changeHealth(0.5f);
                    Destroy(gameObject); 
                }
            }

        }
    }
}
