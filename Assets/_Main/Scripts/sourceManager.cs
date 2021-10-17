using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sourceManager : MonoBehaviour
{
    public static AudioClip ShootFlyEye;
    static AudioSource audioSource;
    
    void Start()
    {
        ShootFlyEye = Resources.Load<AudioClip>("ShootFlyEye");
        audioSource = GetComponent<AudioSource>();
    }
    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "ShootFlyEye": 
                audioSource.PlayOneShot(ShootFlyEye);
                break;
        }
    }
}