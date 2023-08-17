using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playUpgrade : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip upgradeClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayUpgSound(){
        audioSource.PlayOneShot(upgradeClip);
    }
}
