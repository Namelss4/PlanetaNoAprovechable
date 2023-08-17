using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum rogueState
{
    CircleShot,
    ThreeShots,
    BurstShot,
    Dead
};

public class SandRogueController : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audioSource;

    #region MOVE RELATED
    Vector2 position;
    public Transform leftArm;
    public Transform rightArm;
    #endregion

    #region ATTACK RELATED
    public float fireRate = 1.5f;
    public float changeStateTime = 3.0f;
    float timer;
    float timer2;
    public GameObject RogueBullet;
    public Transform firePointRight;
    public Transform firePointLeft;
    int firePointSelection;
    #endregion

    #region AI RELATED
    Rigidbody2D player;
    public rogueState currState = rogueState.ThreeShots;
    #endregion

    #region idk RELATED
    public int health = 100;
    GameObject door;
    LevelManagement LM;
    #endregion

    #region AUDIO
    public AudioClip shotClip;
    #endregion

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        door = GameObject.Find("Door");
        timer = fireRate;
        timer2 = changeStateTime;
        player = GameObject.Find("Robin").GetComponent<Rigidbody2D>();
        LM = door.GetComponent<LevelManagement>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;
    }

    void FixedUpdate(){
        rotateArms();
        switch (currState)
        {
            case (rogueState.ThreeShots):
                if (timer < 0){
                    firePointSelection = Random.Range(1, 4);
                    if(firePointSelection == 1){
                        tripleShot(firePointRight);
                    }
                    else if(firePointSelection == 2){
                        tripleShot(firePointLeft);
                    }
                    else{
                        tripleShot(firePointRight);
                        tripleShot(firePointLeft);
                    }
                    
                    timer = Random.Range(0.5f, 1.5f);
                }
                break;
            case (rogueState.CircleShot):
                if (timer < 0){
                    circleShot();
                    timer = Random.Range(0.5f, 1.5f);
                }
                break;
            case (rogueState.BurstShot):
                firePointSelection = Random.Range(1, 4);
                if (timer < 0){
                    firePointSelection = Random.Range(1, 4);
                    if(firePointSelection == 1){
                        burstShot(firePointRight);
                    }
                    else if(firePointSelection == 2){
                        burstShot(firePointLeft);
                    }
                    else{
                        burstShot(firePointRight);
                        burstShot(firePointLeft);
                    }
                    timer = Random.Range(0.5f, 1.5f);
                }
                break;
            case (rogueState.Dead):
                Die();
                break;
        }
        if (timer2 < 0){
            int randState = Random.Range(1,4);
            currState = randState == 1 ? rogueState.ThreeShots : randState == 2 ? rogueState.CircleShot : rogueState.BurstShot;
            timer2 = Random.Range(1.0f, 2.0f);
        }
    }

    void tripleShot(Transform firePoint){
        Vector2 aimDirection = Aim(firePoint == firePointRight ? true : false);

        GameObject[] RogueBulletObject = new GameObject[5];
        RogueBulletController[] rgBullController = new RogueBulletController[5];

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        angle += 30.0f;

        for (int i = 0; i <= 4; i++){
            RogueBulletObject[i] = Instantiate(RogueBullet, firePoint.position, Quaternion.identity);
            rgBullController[i] = RogueBulletObject[i].GetComponent<RogueBulletController>();

            aimDirection.x = Mathf.Cos((angle - 15 * i) * Mathf.Deg2Rad);
            aimDirection.y = Mathf.Sin((angle - 15 * i) * Mathf.Deg2Rad);

            rgBullController[i].shoot(aimDirection, 8);
        }

        audioSource.PlayOneShot(shotClip);

        // rgBullController[0].shoot(aimDirection, 8);
        // rgBullController[1].shoot(aimDirection2, 8);
        // rgBullController[2].shoot(aimDirection3, 8);
    }

    void circleShot(){
        float xDir = Random.Range(0, 1f);
        Vector2 aimDirectionR = new Vector2(xDir, 1.0f - xDir);
        Vector2 aimDirectionL = new Vector2(xDir, -1.0f + xDir);

        // Debug.Log($"Dirección R: {aimDirectionR.x}, {aimDirectionR.y}");

        float angleL = Mathf.Atan2(aimDirectionL.y, aimDirectionL.x) * Mathf.Rad2Deg;
        float angleR = Mathf.Atan2(aimDirectionR.y, aimDirectionR.x) * Mathf.Rad2Deg;

        GameObject[] RogueBulletObject = new GameObject[12];
        RogueBulletController[] rgBulletController = new RogueBulletController[12];

        for (int i = 0; i <= 11; i++){
            if(i <= 5){
                RogueBulletObject[i] = Instantiate(RogueBullet, firePointLeft.position, Quaternion.identity);
            }
            else{
                RogueBulletObject[i] = Instantiate(RogueBullet, firePointRight.position, Quaternion.identity);
            }
        }

        for (int i = 0; i <= 11; i++){
            rgBulletController[i] = RogueBulletObject[i].GetComponent<RogueBulletController>();
        }
        
        for (int i = 0; i <= 5; i++){
            if (((angleL + 30*i >= 90) && (angleL + 30*i <= 180)) || ((angleL + 30*i >= -180 ) && ( angleL + 30*i <= -90))){
                aimDirectionL.x = Mathf.Cos((angleL + 30*i)*Mathf.Deg2Rad);
                aimDirectionL.y = Mathf.Sin((angleL + 30*i)*Mathf.Deg2Rad);
            }
            else{
                aimDirectionL.x = Mathf.Cos((angleL + 30*i + 180)*Mathf.Deg2Rad);
                aimDirectionL.y = Mathf.Sin((angleL + 30*i + 180)*Mathf.Deg2Rad);
            }
            rgBulletController[i].shoot(aimDirectionL, 5);
        }
        // Debug.Log($"Angulo inicial: {angleR}");
        for (int i = 0; i <= 5; i++){
            if (((angleR + 30*i >= 0) && (angleR + 30*i <= 90)) || ((angleR + 30*i >= -90 ) && ( angleR + 30*i <= 0))){
                aimDirectionR.x = Mathf.Cos((angleR + 30*i)*Mathf.Deg2Rad);
                aimDirectionR.y = Mathf.Sin((angleR + 30*i)*Mathf.Deg2Rad);
            }
            else{
                aimDirectionR.x = Mathf.Cos((angleR + 30*i + 180)*Mathf.Deg2Rad);
                aimDirectionR.y = Mathf.Sin((angleR + 30*i + 180)*Mathf.Deg2Rad);
                // Debug.Log("LE SUMÉ 180");
            }
            // Debug.Log($"Angulo {i}: {(angleL + 30 * i)}");
            rgBulletController[i+6].shoot(aimDirectionR, 5);
        }

        audioSource.PlayOneShot(shotClip);
    }

    void burstShot(Transform firePoint){
        GameObject[] RogueBulletObject = new GameObject[7];
        RogueBulletController[] rgBulletController = new RogueBulletController[7];
        StartCoroutine(fireBurst(RogueBulletObject, rgBulletController, firePoint)); 
    }

    IEnumerator fireBurst(GameObject[] RogueBulletObject, RogueBulletController[] rgBulletController, Transform firePoint){
        Vector2 aimDirection = Aim(firePoint == firePointRight ? true : false);

        for (int i = 0; i <= 6; i++){
            RogueBulletObject[i] = Instantiate(RogueBullet, firePoint.position, Quaternion.identity);
            RogueBulletObject[i].GetComponent<RogueBulletController>().shoot(aimDirection, 12);
            audioSource.PlayOneShot(shotClip);
            yield return new WaitForSeconds(0.05f);
        }
    }

    void Die(){

        LM.enemyCount -= 1;
        LM.isRogueDead = true;
        Destroy(gameObject);
    }

    void takeDamage(int damage){
        health -= damage;
        if (health <= 0){
            currState = rogueState.Dead;
        }
    }

    Vector2 Aim(bool isRight){
        Vector2 aimDirection;

        if (isRight){
            aimDirection = player.GetComponent<Rigidbody2D>().position - (Vector2)firePointRight.position;
            aimDirection.Normalize();
        }
        else{
            aimDirection = player.GetComponent<Rigidbody2D>().position - (Vector2)firePointLeft.position;
            aimDirection.Normalize();
        }

        return aimDirection;
    }

    void rotateArms(){
        Vector2 aimDirectionL = player.GetComponent<Rigidbody2D>().position - (Vector2)firePointLeft.position;
        Vector2 aimDirectionR = player.GetComponent<Rigidbody2D>().position - (Vector2)firePointRight.position;

        float angleL = Mathf.Atan2(aimDirectionL.y, aimDirectionL.x) * Mathf.Rad2Deg + 60;
        float angleR = Mathf.Atan2(aimDirectionR.y, aimDirectionR.x) * Mathf.Rad2Deg + 90;

        rightArm.rotation = Quaternion.Euler(0,0,angleR);
        leftArm.rotation = Quaternion.Euler(0,0,angleL);
    }
}