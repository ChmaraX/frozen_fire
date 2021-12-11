using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupOverlay : MonoBehaviour
{

    public Text popupTitleTextRef;

    public Text bodyTitleTextRef;

    //TODO set title & body text

    public void SetPopupInactive() 
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        //resume game time when popup deactivated
    }
}
