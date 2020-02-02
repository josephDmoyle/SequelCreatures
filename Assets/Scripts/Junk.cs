using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    private int lifeTimer = 0;
    [SerializeField] int lifeTime = 500;

    private AudioSource source;
    [SerializeField] private AudioClip pickUp;
    [SerializeField] private AudioClip destroyUp;

    // Start is called before the first frame update
    private void Awake()
    {
        //GameController.currentJunk[gameObject] = this;
        source = GetComponent<AudioSource>();
        lifeTimer = 0;
    }

    private void OnDestroy()
    {
        //GameController.currentJunk.Remove(gameObject);
    }

    private void FixedUpdate()
    {
        lifeTimer++;
        if(lifeTimer >= lifeTime)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        source.PlayOneShot(pickUp);
        Destroy(transform.parent.gameObject);
    }
}
