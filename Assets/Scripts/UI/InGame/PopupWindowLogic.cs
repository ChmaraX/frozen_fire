using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWindowLogic : MonoBehaviour
{
    public PopupOverlay popupOverlay;
    public string popupTitle;
    public string popupBody;

    //displays popup window in scene when triggered
    private void OnTriggerEnter2D(Collider2D collider)
    {
        SoundManagerScript.PlaySound("popupPickupSound");
        popupOverlay.Show(popupTitle, popupBody);
        Destroy(gameObject);
    }
   
}