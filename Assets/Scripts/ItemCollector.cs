using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    private int collectedCherries = 0;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Coin")) 
        {
            collectedCherries++;
            Destroy(collider.gameObject);
            Debug.Log("collected cherry: " + collectedCherries);
        }
    }
}
