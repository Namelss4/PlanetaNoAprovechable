using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum hornState
{
    Chasing,
    Dead
};

public class PewterHornController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    #region MOVE RELATED
    public float moveSpeed = 2.5f;
    Vector2 position;
    #endregion

    #region ATTACK RELATED
    public float contactDamage = 0.5f;
    #endregion

    #region AI RELATED
    GameObject player;
    public hornState currState = hornState.Chasing;
    #endregion

    #region idk RELATED
    public int health = 18;
    GameObject door;
    LevelManagement LM;
    #endregion

    #region DROPS RELATED
    public GameObject drop1Prefab;
    public GameObject drop2Prefab;
    #endregion

    void Start(){
        player = GameObject.Find("Robin");
        door = GameObject.Find("Door");
        rb = GetComponent<Rigidbody2D>();
        LM = door.GetComponent<LevelManagement>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        position = rb.position;

        Vector2 Look = player.GetComponent<Rigidbody2D>().position - position;
        Look.Normalize();
        // Debug.Log($"X: {Look.x} Y: {Look.y}");

        animator.SetFloat("Move X", Look.x);
        animator.SetFloat("Move Y", Look.y);
    }

    void FixedUpdate(){

        switch (currState)
        {
            case (hornState.Chasing):
                Chase();
                break;
            case (hornState.Dead):
                Die();
                break;
        }
    }

    void Chase(){
        rb.MovePosition(Vector2.MoveTowards(rb.position, player.GetComponent<Rigidbody2D>().position,
                                            moveSpeed*Time.deltaTime));
        animator.SetBool("Moving", true);
    }

    void takeDamage(int damage){
        health -= damage;
        if (health <= 0){
            currState = hornState.Dead;
        }
    }

    void OnCollisionStay2D(Collision2D other){
        GameObject player = other.gameObject;
        Robin playerController = player.GetComponent<Robin>();

        if (playerController != null){
            playerController.changeHealth(-0.5f);
        }
    }

    void Die(){
        int opcDrop;
        for (int i = 1; i <= Random.Range(1,3); i++){
            opcDrop = Random.Range(1, 3);

            if(opcDrop == 1){
                Vector2 objectPos = transform.position;
                objectPos.x += Random.Range(-1f, 1f);
                objectPos.y += Random.Range(-1f, 1f);
                GameObject dropObject = Instantiate(drop1Prefab, objectPos, Quaternion.identity);
            }
            else if(opcDrop == 2){
                Vector2 objectPos = transform.position;
                objectPos.x += Random.Range(-1f, 1f);
                objectPos.y += Random.Range(-1f, 1f);
                GameObject dropObject = Instantiate(drop2Prefab, objectPos, Quaternion.identity);
            }
        }
        LM.enemyCount -= 1;
        Destroy(gameObject);
    }
}
