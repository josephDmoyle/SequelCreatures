using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerOWO : MonoBehaviour
{
    public float countDown = 120f;
    public GameObject army = null, gate = null;

    bool done = false, failed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (Grunt.grunts.ContainsKey(other.gameObject))
        {
            if (Grunt.grunts[other.gameObject].team == Team.Protags && !failed)
            {
                failed = true;
                Invoke("EndGame", 2f);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!done)
        {
            countDown -= Time.fixedDeltaTime;
            if (countDown <= 0f)
            {
                army.SetActive(true);
                gate.SetActive(false);
                done = true;
            }
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
