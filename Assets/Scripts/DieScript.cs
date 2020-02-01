using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{

    public Vector3 x;
    float DieY;
    float DieZ;
    public float speed;
    public GameObject PitFall;
    public float targetX;

    // Start is called before the first frame update
    public void Die()
    {
        print("Success");
        float step = speed * Time.deltaTime;
        while (transform.position.x < targetX)
        {
            transform.position = Vector3.MoveTowards(transform.position, PitFall.transform.position, step);
        }
       
    }
}
