using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public int damage = 2;
    
    void Awake(){
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    public void shoot(Vector2 direction, float force){
        
        rigidbody2d.AddForce(direction * force, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other){
        Destroy(gameObject);

        if (other.tag == "Enemy"){
            other.gameObject.SendMessage("takeDamage", damage);
        }
    }
}
