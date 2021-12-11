using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWindowLogic : MonoBehaviour
{

    public GameObject popupRef;
    public Text popupTitleTextRef;
    public Text popupBodyTextRef;

    public string popupTitle;
    public string popupBody;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        popupTitleTextRef.text = popupTitle;
        popupBodyTextRef.text = popupBody;
        popupRef.SetActive(true);
        Destroy(gameObject);

        //stop game time when popup is displayed
        Time.timeScale = 0f;
    }
   
}
