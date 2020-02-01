//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<GameObject> junk = new List<GameObject>();
    [SerializeField] private List<GameObject> traps = new List<GameObject>();

    private int dumpTimer = 0;
    [SerializeField] int dumpTime = 1000;

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
        if(dumpTimer >= 1000)
        {
            SpawnJunk(15);
            dumpTimer = 0;
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
    }
}
