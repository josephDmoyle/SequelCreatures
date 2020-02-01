using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
    [SerializeField] GameObject spawnPosition;
    public float speed;
    public GameObject PitFall;
    public float targetX;
    public GameObject highSpot;
    [SerializeField] private Animator anim;
    public bool cooldown = false;

    public SpriteRenderer SacrificeIcon;
    public Sprite Original;
    public Sprite Darkened;


    public Transform grunt;

    public int minimum = 2;




    public void Die()
    {
        if (!cooldown)
        {
            SacrificeIcon.sprite = Darkened;
            cooldown = true;
            anim.SetTrigger("die");
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
        print("Object Moved");
        Invoke("coolDownOff", 5f);
        Invoke("Birth", 3f);

    }

    void Birth()
    {
        for(int i = 0; i < minimum; i++)
        {
            Instantiate(grunt, spawnPosition.transform.position, Quaternion.identity);

        }
    }

    void coolDownOff()
    {
        SacrificeIcon.sprite = Original;
        cooldown = false;
        print("Spacebar enabled again")
;    }
   
}
