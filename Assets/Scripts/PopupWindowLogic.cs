using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWindowLogic : MonoBehaviour
{

    public GameObject popupRef;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision - poop up");
        Destroy(gameObject);
        popupRef.SetActive(true);

        //stop game time when popup is displayed
        Time.timeScale = 0f;
    }
   
}
