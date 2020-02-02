//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class JunkyardController : MonoBehaviour
{
    [SerializeField] private List<GameObject> junk = new List<GameObject>();
    [SerializeField] private List<GameObject> traps = new List<GameObject>();
    [SerializeField] private GameObject spawnField;
    [SerializeField] private Slider ScavengeMeter = null;

    private Vector3 spawnAreaScale;
    private float xGround;
    private float xCeiling;
    private float zGround;
    private float zCeiling;

    private int dumpTimer = 0;
    [SerializeField] private int dumpTime = 2000;

    private int scavengeTimer = 0;
    [SerializeField] private int scavengeTime = 500;

    public int materials = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnAreaScale = spawnField.transform.localScale;
        xGround  = -(spawnAreaScale.x) / 2;
        zGround  = -(spawnAreaScale.y) / 2;
        xCeiling = (spawnAreaScale.y) / 2;
        zCeiling = (spawnAreaScale.y) / 2;
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

            GameObject obj = Instantiate(junk[junkIndex], new Vector3(Random.Range(xGround, xCeiling), 0, Random.Range(zGround, zCeiling)), Quaternion.identity, spawnField.transform);
            obj.transform.localPosition = (new Vector3(Random.Range(xGround, xCeiling), 0, Random.Range(zGround, zCeiling)));
            obj.transform.localScale = (new Vector3(.1f, .1f, .1f));
        }

        for (int i = 0; i < junkAmount/2; i++)
        {
            int trapIndex = (int)(Random.Range(0.0f, 0.99999999f) * (float)traps.Count);

            GameObject obj = Instantiate(traps[trapIndex], new Vector3(Random.Range(xGround, xCeiling), 0, Random.Range(xGround, xCeiling)), Quaternion.identity, spawnField.transform);
            obj.transform.localPosition = (new Vector3(Random.Range(xGround, xCeiling), 0, Random.Range(zGround, zCeiling)));
            obj.transform.localScale = (new Vector3(.1f, .1f, .1f));
        }

        dumpTimer = 0;
        scavengeTimer = 0;
    }
}
