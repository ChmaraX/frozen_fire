using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

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
        if (collision.gameObject.CompareTag("Trap")) {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
