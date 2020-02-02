using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public static AudioClip alienchat1, alienchat2, alienchat3, aliendeath1, aliendeath2, alienexploded,
        aliengun, aliengun2, aliengun3, humanchatter, humandeath, humandeath2, humanexploded, humangun1, clickUI, humangun2;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        alienchat1 = Resources.Load<AudioClip>("alienchat1");
        alienchat2 = Resources.Load<AudioClip>("alienchat2");
        alienchat3 = Resources.Load<AudioClip>("alienchat3");
        aliendeath1 = Resources.Load<AudioClip>("aliendeath1");
        aliendeath2 = Resources.Load<AudioClip>("aliendeath2");
        alienexploded = Resources.Load<AudioClip>("alienexploded");
        aliengun = Resources.Load<AudioClip>("aliengun");
        aliengun2 = Resources.Load<AudioClip>("aliengun2");
        aliengun3 = Resources.Load<AudioClip>("aliengun3");
        humanchatter = Resources.Load<AudioClip>("humanchatter");
        humandeath = Resources.Load<AudioClip>("humandeath");
        humandeath2 = Resources.Load<AudioClip>("humandeath2");
        humanexploded = Resources.Load<AudioClip>("humanexploded");
        humangun1 = Resources.Load<AudioClip>("humangun1");
        humangun2 = Resources.Load<AudioClip>("humangun2");
        clickUI = Resources.Load<AudioClip>("clickUI");


        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Playsound(string clip)
    {
        switch (clip)
        {
            case "alienchat1":
                audioSrc.PlayOneShot(alienchat1);
                break;
            case "alienchat2":
                audioSrc.PlayOneShot(alienchat2);
                break;
            case "alienchat3":
                audioSrc.PlayOneShot(alienchat3);
                break;
            case "aliendeath1":
                audioSrc.PlayOneShot(aliendeath1);
                break;
            case "aliendeath2":
                audioSrc.PlayOneShot(aliendeath2);
                break;
            case "alienexploded":
                audioSrc.PlayOneShot(alienexploded);
                break;
            case "aliengun":
                audioSrc.PlayOneShot(aliengun);
                break;
            case "aliengun2":
                audioSrc.PlayOneShot(aliengun2);
                break;
            case "aliengun3":
                audioSrc.PlayOneShot(aliengun3);
                break;
            case "humanchatter":
                audioSrc.PlayOneShot(humanchatter);
                break;
            case "humandeath":
                audioSrc.PlayOneShot(humandeath);
                break;
            case "humandeath2":
                audioSrc.PlayOneShot(humandeath2);
                break;
            case "humanexploded":
                audioSrc.PlayOneShot(humanchatter);
                break;
            case "humangun1":
                audioSrc.PlayOneShot(humangun1);
                break;
            case "humangun2":
                audioSrc.PlayOneShot(humangun2);
                break;
            case "clickUI":
                audioSrc.PlayOneShot(clickUI);
                break;


        }
    }
}
