//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<GameObject> junk = new List<GameObject>();
    [SerializeField] private List<GameObject> traps = new List<GameObject>();

    [SerializeField] private Slider ScavengeMeter = null;

    //public static Dictionary<GameObject, Junk> currentJunk = new Dictionary<GameObject, Junk>();

    private int dumpTimer = 0;
    [SerializeField] private int dumpTime = 2000;

    private int scavengeTimer = 0;
    [SerializeField] private int scavengeTime = 500;

    public int materials = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnJunk(12);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dumpTimer++;
        scavengeTimer++;
        if (dumpTimer >= dumpTime)
        {
            SpawnJunk(30);
        }

        if(scavengeTimer < scavengeTime)
        {
            ScavengeMeter.value = (float)scavengeTimer / (float)scavengeTime;
        }
        else if (dumpTimer < dumpTime)
        {
            ScavengeMeter.value = ((float)dumpTimer - scavengeTime) / ((float)dumpTime - scavengeTime);
        }
        
    }

    void SpawnJunk(int junkAmount)
    {
        for(int i = 0; i < junkAmount; i++)
        {
            int junkIndex = (int)(Random.Range(0.0f, 0.99999999f) * (float)junk.Count);

            Instantiate(junk[junkIndex], new Vector3(Random.Range(-150, -51), 0, Random.Range(-50, 50)), Quaternion.identity);
        }

        for (int i = 0; i < junkAmount/2; i++)
        {
            int trapIndex = (int)(Random.Range(0.0f, 0.99999999f) * (float)traps.Count);

            Instantiate(traps[trapIndex], new Vector3(Random.Range(-150, -51), 0, Random.Range(-50, 50)), Quaternion.identity);
        }

        dumpTimer = 0;
        scavengeTimer = 0;
    }
}
