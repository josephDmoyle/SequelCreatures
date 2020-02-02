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
    [SerializeField] private Slider MaterialsMeter = null;
    [SerializeField] private Slider ScavengeHealth = null;

    private float inc = 0.05f;
    [SerializeField] private Image MaterialWarning = null;

    private Vector3 spawnAreaScale;
    private float xGround;
    private float xCeiling;
    private float zGround;
    private float zCeiling;

    [SerializeField] private float health = 10;
    [SerializeField] private float maxHealth = 10;

    public bool selected = false;

    private int dumpTimer = 500;
    [SerializeField] private int dumpTime = 2000;

    private int scavengeTimer = 500;
    [SerializeField] private int scavengeTime = 500;

    public int materials = 0;
    [SerializeField] private int maxMaterials = 500;

    [SerializeField] private Scavenger scavenger = null;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        spawnAreaScale = spawnField.transform.localScale;
        xGround  = -(spawnAreaScale.x) / 2;
        zGround  = -(spawnAreaScale.y) / 2;
        xCeiling = (spawnAreaScale.y) / 2;
        zCeiling = (spawnAreaScale.y) / 2;
        //SpawnJunk(12);
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
            ScavengeMeter.value = ((float)scavengeTime - (float)scavengeTimer) / (float)scavengeTime;
        }
        else if (dumpTimer < dumpTime)
        {
            ScavengeMeter.value = ((float)dumpTimer - scavengeTime) / ((float)dumpTime - scavengeTime);
        }

        if (selected)
        {
            ScavengeHealth.gameObject.SetActive(true);
            ScavengeHealth.value = health / maxHealth;
        }
        else
        {
            ScavengeHealth.gameObject.SetActive(false);
        }

        if(scavengeTimer <= 100 && scavengeTimer >= 0)
        {
            if ((MaterialWarning.color.a > 0.9 && inc > 0) || (MaterialWarning.color.a < 0.5 && inc < 0))
            {
                inc *= -1;
            }
            MaterialWarning.color += new Color(0,0,0,inc);
        }
        else
        {
            MaterialWarning.color = new Color(1, 1, 1, 0);
        }

        MaterialsMeter.value = (float)materials / (float)maxMaterials;
        
    }

    void SpawnJunk(int junkAmount)
    {
        for(int i = 0; i < junkAmount; i++)
        {
            int junkIndex = (int)(Random.Range(0.0f, 0.99999999f) * (float)junk.Count);

            GameObject obj = Instantiate(junk[junkIndex], new Vector3(Random.Range(xGround, xCeiling), 0, Random.Range(zGround, zCeiling)), Quaternion.identity, spawnField.transform);
            obj.transform.localPosition = (new Vector3(Random.Range(xGround, xCeiling), 0, Random.Range(zGround, zCeiling)));
            obj.transform.localScale = (new Vector3(.1f, .1f, .1f));
            obj.transform.Rotate(obj.transform.up * Random.Range(0, 360));
        }

        for (int i = 0; i < junkAmount/2; i++)
        {
            int trapIndex = (int)(Random.Range(0.0f, 0.99999999f) * (float)traps.Count);

            GameObject obj = Instantiate(traps[trapIndex], new Vector3(Random.Range(xGround, xCeiling), 0, Random.Range(xGround, xCeiling)), Quaternion.identity, spawnField.transform);
            obj.transform.localPosition = (new Vector3(Random.Range(xGround, xCeiling), 0, Random.Range(zGround, zCeiling)));
            obj.transform.localScale = (new Vector3(.1f, .1f, .1f));
            obj.transform.Rotate(obj.transform.up * Random.Range(0, 360));
        }

        dumpTimer = 0;
        scavengeTimer = 0;
    }

    public void TookDamage()
    {
        health -= 1;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        scavenger.gameObject.SetActive(false);
        Invoke("Respawn", 5);
    }

    void Respawn()
    {
        health = maxHealth;
        scavenger.gameObject.SetActive(true);
    }
}
