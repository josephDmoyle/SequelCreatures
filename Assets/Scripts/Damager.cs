using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage = 1;
    private void OnCollisionEnter(Collision iCollision)
    {
        if (Health.healths.ContainsKey(iCollision.gameObject))
        {
            Health.healths[iCollision.gameObject].Damage(damage);
        }
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider iCollision)
    {
        if (Health.healths.ContainsKey(iCollision.gameObject))
        {
            Health.healths[iCollision.gameObject].Damage(damage);
        }
        gameObject.SetActive(false);
    }
}
