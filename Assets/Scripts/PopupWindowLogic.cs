using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWindowLogic : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision - poop up");
        Destroy(gameObject);
    }
   
}
