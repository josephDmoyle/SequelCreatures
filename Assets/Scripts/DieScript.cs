using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
    public float speed;
    public GameObject PitFall;
    public float targetX;
    [SerializeField] Animator anim;

    public void Die()
    {
        anim.SetTrigger("die");
    }
}
