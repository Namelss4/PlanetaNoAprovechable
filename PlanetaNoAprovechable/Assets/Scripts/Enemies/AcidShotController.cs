using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidShotController : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    public void shoot(Vector2 direction, float force){
        
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other){
        GameObject player = other.gameObject;
        Robin playerController = player.GetComponent<Robin>();

        if (playerController != null){
            playerController.changeHealth(-0.5f);
        }
        Destroy(gameObject);
    }
}
