using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] GameObject explode = null;
    [SerializeField] float countDown = 4f;
    float timer = 0f;

    private void OnEnable()
    {
        timer = 0f;
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= countDown)
        {
            explode.transform.parent = null;
            explode.transform.position = transform.position;
            explode.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
