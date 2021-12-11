using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupOverlay : MonoBehaviour
{

    public Text popupTitleTextRef;

    public Text bodyTitleTextRef;

    public void SetPopupInactive() 
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    
}
