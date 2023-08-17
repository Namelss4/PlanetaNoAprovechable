using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagement : MonoBehaviour
{
    Rigidbody2D playerRb;
    Transform cameraPos;

    int level = 0;
    bool isLevelFinished = false;
    bool isClose = false;
    public bool isRogueDead = false;

    public int enemyCount = 1;

    GameObject Robin;
    GameObject Camera;

    public GameObject lizPrefab;
    public GameObject hornPrefab;
    public GameObject Rogue;
    public GameObject sPillprefab;
    public GameObject bPillprefab;

    public AudioSource audioSource;

    public AudioClip shipBG;
    public AudioClip desertBG;
    public AudioClip rogueBG;
    public AudioClip successClip;

    public GameObject diagLvlF;
    public GameObject diagRogueD;

    Vector2 playerPos;
    Vector3 newCameraPos;
    Vector2 doorPos;

    public AudioSource succAS;

    bool succPLayed = true;

    float dr = 28.02f;

    Robin pc;

    void Start()
    {
        playerRb = GameObject.Find("Robin").GetComponent<Rigidbody2D>();
        cameraPos = GameObject.Find("Main Camera").GetComponent<Transform>();
        pc = GameObject.Find("Robin").GetComponent<Robin>();
    }

    public IEnumerator success(){
        audioSource.volume = 0.25f;
        yield return new WaitForSeconds(0.5f);
        audioSource.volume = 0.3f;
    }

    void Update(){
        if (enemyCount == 0 && !succPLayed){
            StartCoroutine(success());
            succAS.PlayOneShot(successClip);
            succPLayed = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            switch (level)
            {
                case 1:
                    if(enemyCount == 0){
                        lvl2(isLevelFinished);
                        succPLayed = false;
                    }
                    break;
                case 2:
                    if(enemyCount == 0){
                        lvl3(isLevelFinished);
                        succPLayed = false;                        
                    }
                    break;
                case 3:
                    if(enemyCount == 0){
                        lvl4(isLevelFinished);
                        succPLayed = false;                        
                    }
                    break;
                case 4:
                    if(enemyCount == 0){
                        lvl5(isLevelFinished);
                        succPLayed = false;                       
                    }
                    break;
                case 5:
                    if(enemyCount == 0){
                        returnShip();                        
                    }
                    break;
                default:
                    if(!isClose){
                        lvl1(isLevelFinished);
                        succPLayed = false;
                    }
                    break;
            }
        }
    }

    void lvl1(bool isLevelFinished){
        if (!isLevelFinished){
            audioSource.clip = desertBG;
            audioSource.Play();

            newCameraPos = new Vector3(0.71f, -0.15f,-10f);
            playerPos = new Vector2(0.81f, -0.07f);
            doorPos = new Vector2(0.7f, 6.15f);

            playerRb.position = playerPos;
            cameraPos.position = newCameraPos;

            enemyCount = 2;

            Instantiate(lizPrefab, new Vector3(-8.524986f, -4.782836f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(10.34972f, 4.541496f) , Quaternion.identity);


            transform.position = doorPos;
            level += 1;
            
        }
        else{
            audioSource.clip = desertBG;
            audioSource.Play();

            newCameraPos = new Vector3(0.71f, -18.11f,-10f);
            playerPos = new Vector2(0.81f, -18.03f);
            doorPos = new Vector2(0.7f, -11.81f);

            playerRb.position = playerPos;
            cameraPos.position = newCameraPos;

            enemyCount = 3;

            Instantiate(lizPrefab, new Vector3(-7.963669f, -14.45527f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(9.710754f, -22.18784f) , Quaternion.identity);
            Instantiate(hornPrefab, new Vector3(9.342541f, -14.45527f) , Quaternion.identity);


            transform.position = doorPos;
            level += 1;
            
        }
    }

    void lvl2(bool isLevelFinished){
        if (!isLevelFinished){
            newCameraPos = new Vector3(0.71f+dr, -0.15f,-10f);
            playerPos = new Vector2(0.81f+dr, -4.86f);
            doorPos = new Vector2(0.7f+dr, 6.15f);

            playerRb.position = playerPos;
            cameraPos.position = newCameraPos;

            enemyCount = 1;

            Instantiate(hornPrefab, new Vector3(19.95661f, -4.104703f) , Quaternion.identity);

            transform.position = doorPos;
            level += 1;
        }
        else{
            newCameraPos = new Vector3(0.71f+dr, -18.11f,-10f);
            playerPos = new Vector2(0.81f+dr, -23.29f);
            doorPos = new Vector2(0.7f+dr, -11.81f);

            playerRb.position = playerPos;
            cameraPos.position = newCameraPos;

            enemyCount = 4;

            Instantiate(lizPrefab, new Vector3(37.7205f, -23.1344f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(37.85051f, -17.72494f) , Quaternion.identity);
            Instantiate(hornPrefab, new Vector3(21.07779f, -20.66881f) , Quaternion.identity);
            Instantiate(hornPrefab, new Vector3(20.66686f, -15.53217f) , Quaternion.identity);
            Instantiate(sPillprefab, new Vector3(37.76989f, -14.20088f), Quaternion.identity);

            transform.position = doorPos;
            level += 1;
        }
    }

    void lvl3(bool isLevelFinished){
        if (!isLevelFinished){
            newCameraPos = new Vector3(0.71f+dr*2, -0.15f,-10f);
            playerPos = new Vector2(0.81f+dr*2, -4.86f);
            doorPos = new Vector2(0.7f+dr*2, 6.15f);

            playerRb.position = playerPos;
            cameraPos.position = newCameraPos;

            enemyCount = 3;

            Instantiate(lizPrefab, new Vector3(65.9004f, -4.95241f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(66.23947f, 4.371923f) , Quaternion.identity);
            Instantiate(hornPrefab, new Vector3(47.87336f, -4.217765f) , Quaternion.identity);
            Instantiate(sPillprefab, new Vector3(48.50654f, 3.764827f), Quaternion.identity);

            transform.position = doorPos;
            level += 1;
        }
        else{
            newCameraPos = new Vector3(0.71f+dr*2, -18.11f,-10f);
            playerPos = new Vector2(0.81f+dr*2, -23.29f);
            doorPos = new Vector2(0.7f+dr*2, -11.81f);

            playerRb.position = playerPos;
            cameraPos.position = newCameraPos;

            enemyCount = 6;

            Instantiate(lizPrefab, new Vector3(65.86929f, -22.41527f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(65.45836f, -14.91577f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(47.72f, -13.82f) , Quaternion.identity);
            Instantiate(hornPrefab, new Vector3(64.1f, -17.8f) , Quaternion.identity);
            Instantiate(hornPrefab, new Vector3(50.65f, -21.63f) , Quaternion.identity);
            Instantiate(hornPrefab, new Vector3(51.33f, -14.22f) , Quaternion.identity);

            transform.position = doorPos;
            level += 1;
        }
    }

    void lvl4(bool isLevelFinished){
        if (!isLevelFinished){
            newCameraPos = new Vector3(0.71f+dr*3, -0.15f,-10f);
            playerPos = new Vector2(0.81f+dr*3, -4.86f);
            doorPos = new Vector2(0.7f+dr*3, 6.15f);

            playerRb.position = playerPos;
            cameraPos.position = newCameraPos;

            enemyCount = 3;

            Instantiate(lizPrefab, new Vector3(84.54902f, 4.202362f) , Quaternion.identity);
            Instantiate(hornPrefab, new Vector3(93.64731f, 3.750273f) , Quaternion.identity);
            Instantiate(hornPrefab, new Vector3(75.84631f, 3.750273f) , Quaternion.identity);

            transform.position = doorPos;
            level += 1;
        }
        else{
            newCameraPos = new Vector3(0.71f+dr*3, -18.11f,-10f);
            playerPos = new Vector2(0.81f+dr*3, -23.29f);
            doorPos = new Vector2(0.7f+dr*3, -11.81f);

            playerRb.position = playerPos;
            cameraPos.position = newCameraPos;

            enemyCount = 6;

            Instantiate(lizPrefab, new Vector3(78.34999f, -14.42f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(75.85043f, -18.69596f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(76.43224f, -22.33228f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(93.59566f, -22.62318f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(93.98354f, -16.56265f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(87.92f, -13.67f) , Quaternion.identity);
            Instantiate(sPillprefab, new Vector3(93.66213f, -14.10736f), Quaternion.identity);

            transform.position = doorPos;
            level += 1;
        }
    }

    void lvl5(bool isLevelFinished){
        if (!isLevelFinished){
            newCameraPos = new Vector3(0.71f+dr*4, -0.15f,-10f);
            playerPos = new Vector2(0.81f+dr*4, -4.86f);
            doorPos = new Vector2(0.7f+dr*4, 6.15f);

            playerRb.position = playerPos;
            cameraPos.position = newCameraPos;

            enemyCount = 7;

            Instantiate(lizPrefab, new Vector3(103.2541f, -0.6010949f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(108.8487f, 4.371882f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(103.1976f, 4.76746f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(122.1288f, 2.05464f) , Quaternion.identity);
            Instantiate(lizPrefab, new Vector3(120.0944f, 4.428107f) , Quaternion.identity);

            Instantiate(hornPrefab, new Vector3(121.4507f, -4.105071f) , Quaternion.identity);
            Instantiate(hornPrefab, new Vector3(105.1755f, 2.959105f) , Quaternion.identity);

            Instantiate(bPillprefab, new Vector3(117.7774f, 4.269637f), Quaternion.identity);

            transform.position = doorPos;
            level += 1;

        }
        else{
            audioSource.clip = rogueBG;
            audioSource.Play();

            newCameraPos = new Vector3(0.71f+dr*4, -18.11f,-10f);
            playerPos = new Vector2(0.81f+dr*4, -23.29f);
            doorPos = new Vector2(0.7f+dr*4, -11.81f);

            playerRb.position = playerPos;
            cameraPos.position = newCameraPos;

            enemyCount = 1;

            Instantiate(Rogue, new Vector3(112.89f, -17.64f), Quaternion.identity);

            Instantiate(bPillprefab, new Vector3(122.0274f, -22.91651f), Quaternion.identity);

            transform.position = doorPos;
            level += 1;
        }
    }

    public void returnShip(){
        audioSource.clip = shipBG;
        audioSource.Play();

        newCameraPos = new Vector3(-31.81f, 0.01f,-10f);
        playerPos = new Vector2(-31.71f, -3.14f);
        doorPos = new Vector2(-31.77f, 6.15f);

        playerRb.position = playerPos;
        cameraPos.position = newCameraPos;
        transform.position = doorPos;

        if(isRogueDead){
            isClose = true;
            pc.currState = robinState.cantAct;
            pc.animator.SetFloat("Speed", 0);
            diagRogueD.SetActive(true);
        }

        

        if(level == 5 && !isRogueDead && !isLevelFinished){
            pc.currState = robinState.cantAct;
            pc.animator.SetFloat("Speed", 0);
            diagLvlF.SetActive(true);
        }

        level = 0;
        
        if(enemyCount == 0){
            isLevelFinished = true;
        }
    }
}
