using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
    public float speed;
    public GameObject PitFall;
    public float targetX;

    bool play = false;

    public void Die()
    {
        play = true;  
    }

    private void FixedUpdate()
    {
        if (play)
            transform.position = Vector3.MoveTowards(transform.position, PitFall.transform.position, speed * Time.fixedDeltaTime);
    }
}
