using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapBehavior : MonoBehaviour
{

    [SerializeField]
    private GameObject explosion;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("IceProjectile")) 
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);   
        }
    }
}
