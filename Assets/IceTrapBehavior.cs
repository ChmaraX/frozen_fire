using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrapBehavior : MonoBehaviour
{

    [SerializeField]
    private GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) 
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);   
        }
    }
}
