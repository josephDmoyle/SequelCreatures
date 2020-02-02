using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager_Explosion : MonoBehaviour
{
    [SerializeField] int damage = 4;
    [SerializeField] float timeLength = 1f, explosionForce = 10f, explosionRadius = 30f;
    [SerializeField] bool destroyOnFinish = false;

    float timer = 0f;

    private void OnEnable()
    {
        timer = 0f;
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer >= timeLength)
        {
            timer = 0f;
            if (destroyOnFinish)
                Destroy(gameObject);
            else
            {
                SFX.Playsound("alienexploded");
                gameObject.SetActive(false);
            }

        }
    }

    private void OnTriggerEnter(Collider iCollision)
    {
        if (Health.healths.ContainsKey(iCollision.gameObject))
        {
            Health.healths[iCollision.gameObject].Damage(damage);
        }
        else if(iCollision.attachedRigidbody)
        {
            iCollision.attachedRigidbody.AddExplosionForce(explosionForce, iCollision.ClosestPoint(transform.position), 30f);
        }
    }
}
