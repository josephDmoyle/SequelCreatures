using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (Health.healths.ContainsKey(collision.gameObject))
        {
            Health.healths[collision.gameObject].Damage(damage);
            gameObject.SetActive(false);
        }
    }
}
