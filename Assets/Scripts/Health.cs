using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Dictionary<GameObject, Health> healths = new Dictionary<GameObject, Health>();

    [SerializeField] int hitpoints = 10;
    [SerializeField] bool destroyOnDeath = true;

    private void Awake()
    {
        healths[gameObject] = this;
    }

    private void OnDestroy()
    {
        healths.Remove(gameObject);
    }

    public void Damage(int iDamage)
    {
        if (hitpoints > iDamage)
            hitpoints -= iDamage;
        else
            Death();
    }

    public void Death()
    {
        if (destroyOnDeath)
            Destroy(transform.root.gameObject);
        else
            transform.root.gameObject.SetActive(false);
    }
}
