using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{

    public float speed;
    public GameObject PitFall;
    public float targetX;

    public void Die()
    {
        
        
        while (transform.position.x > targetX)
        {
            print("Success");
            //float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, PitFall.transform.position, speed * Time.deltaTime);
        }
       
    }
}
