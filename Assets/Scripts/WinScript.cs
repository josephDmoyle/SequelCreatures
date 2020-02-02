using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Grunt.grunts.ContainsKey(other.gameObject))
        {
            if (Grunt.grunts[other.gameObject].team == Team.Antags)
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }
}
