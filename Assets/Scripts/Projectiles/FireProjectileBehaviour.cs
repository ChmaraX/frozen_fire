using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileBehaviour : MonoBehaviour
{

    [SerializeField]
    private GameObject destroyEffect;

    public readonly float defaultProjectileLifetime = 3f;

    public float speed = 4.5f;
    [SerializeField] private float projectileLife;

    void Start()
    {
        //initialize projectile with default projectile time
        projectileLife = defaultProjectileLifetime;
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;

        //update projectile life time, destroy it if the lifetime runs out
        projectileLife -= Time.deltaTime;
        if (projectileLife <= 0f) {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //only destroy iceTrap type
        if (!collision.gameObject.CompareTag("IceTrap")) 
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
