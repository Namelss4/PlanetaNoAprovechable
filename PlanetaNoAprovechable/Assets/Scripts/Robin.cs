using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum robinState
{
    canAct,
    cantAct
};

public class Robin : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [HideInInspector] public Animator animator;
    AudioSource audioSource;

    #region MOVE RELATED
    public float speed = 2.5f;
    float horizontal;
    float vertical;
    [HideInInspector] 
    public bool canMove = true;
    Vector2 lookDirection = new Vector2(1, 0);
    float angle;
    #endregion

    #region LIFE 
    public float maxhealth = 3.0f;
    [HideInInspector] public float currenthealth;
    float timerInvincible = 2.0f;
    bool receivedHit = false;
    #endregion

    #region SHOOTING
    public GameObject bulletPrefab;
    Vector2 mousePosition;
    public Transform firePoint;
    #endregion

    #region UI RELATED
    public robinState currState = robinState.cantAct;
    public GameObject diagDead;
    #endregion

    #region DOOR
    public GameObject door;
    #endregion

    #region AUDIOS 
    public AudioClip shotClip;
    public AudioClip damageClip;
    public AudioClip dieClip;
    #endregion

    void Start(){
        rigidbody2d = GetComponent<Rigidbody2D>();
        currenthealth = maxhealth;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update(){
        switch(currState){
            case robinState.canAct:
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 aimDirection = mousePosition - rigidbody2d.position;
                aimDirection.Normalize();

                //animator.SetFloat("Speed", Mathf.Sqrt(horizontal*horizontal + vertical*horizontal));
                animator.SetFloat("Speed", (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0) ? 1 : 0);
                animator.SetFloat("Look X", aimDirection.x);
                animator.SetFloat("Look Y", aimDirection.y);

                if (Input.GetMouseButtonDown(0))
                {
                    shoot();
                }

                if (receivedHit){
                    timerInvincible -= Time.deltaTime;
                    if (timerInvincible < 0){
                        receivedHit = false;
                        timerInvincible = 2.0f;
                    }
                }
                break;
            case robinState.cantAct:
                //jaja no puedes hacer nada wey
                break;
        }        
    }
    
    void FixedUpdate(){
        switch(currState){
            case robinState.canAct:
                Vector2 position = rigidbody2d.position;

                position.x = position.x + speed * horizontal * Time.deltaTime;
                position.y = position.y + speed * vertical * Time.deltaTime;

                rigidbody2d.MovePosition(position);
                break;
            case robinState.cantAct:
                //jaja no puedes hacer nada wey
                break;
        }
    }

    public void changeHealth(float amount){

        if(!receivedHit){
            currenthealth = Mathf.Clamp(currenthealth + amount, 0, maxhealth);
            receivedHit = true;

            if(amount < 0 && currenthealth != 0){
                PlaySound(damageClip);
            }
        }
        
        if (currenthealth == 0){
            Die();
        }
    }

    void Die(){
        PlaySound(dieClip);

        LevelManagement LM = door.GetComponent<LevelManagement>();
        LM.returnShip();
        currState = robinState.cantAct;
        animator.SetFloat("Speed", 0);
        diagDead.SetActive(true);
        currenthealth = maxhealth;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        GameObject[] pills = GameObject.FindGameObjectsWithTag("Health");

        for (int i = 0; i < enemies.Length; i++){
            Destroy(enemies[i]);
        }
        for (int i = 0; i < collectibles.Length; i++){
            Destroy(collectibles[i]);
        }
        for (int i = 0; i < pills.Length; i++){
            Destroy(pills[i]);
        }
    }

    void shoot()
    {
        Vector2 aimDirection = mousePosition - (Vector2)firePoint.position;
        aimDirection.Normalize();

        GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, 
                                              Quaternion.identity);
        BulletController bullet = bulletObject.GetComponent<BulletController>();
        bullet.shoot(aimDirection, 20);

        PlaySound(shotClip);
    }

    public void PlaySound(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }
}
