using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
    [SerializeField] GameObject spawnPosition;
    [SerializeField] float cooldownTime =5f;
    [SerializeField] float birthTime = 3f;
    public float speed;
    public GameObject PitFall;
    public float targetX;
    public GameObject highSpot;
    [SerializeField] private Animator anim;
    public bool cooldown = false;

    public SpriteRenderer SacrificeIcon;
    public Sprite Original;
    public Sprite Darkened;


    public GameObject[] grunts;

    public int minimum = 2;




    public void Die()
    {
        if (!cooldown)
        {
            SacrificeIcon.sprite = Darkened;
            cooldown = true;
            anim.SetTrigger("die");
            SFX.Playsound("aliendeath1");
            SFX.Playsound("alienexploded");
            Invoke("SpawnNewSacrifice", 3f);
            print("Success");
        }
       

    }

    public void SpawnNewSacrifice()
    {
        anim.enabled = false;
        transform.position = highSpot.transform.position;
        anim.enabled = true;
        anim.SetTrigger("fall");
        Invoke("playsplat", .9f);
        print("Object Moved");
        Invoke("coolDownOff", cooldownTime);
        Invoke("Birth", birthTime);

    }

    void playsplat()
    {
        SFX.Playsound("aliendeath1");
    }

    void Birth()
    {
        for(int i = 0; i < minimum; i++)
        {
            Instantiate(grunts[Random.Range(0, grunts.Length)], spawnPosition.transform.position, Quaternion.identity);
        }
    }

    void coolDownOff()
    {
        SacrificeIcon.sprite = Original;
        cooldown = false;
        print("Spacebar enabled again")
;    }
   
}
