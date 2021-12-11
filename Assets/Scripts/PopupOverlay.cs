using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupOverlay : MonoBehaviour
{

    public Text popupTitleTextRef;

    public Text bodyTitleTextRef;

    public string titleText;

    public string bodyText;

    //TODO set title & body text

    public void Start() {
        popupTitleTextRef.text = titleText;
        bodyTitleTextRef.text = bodyText;
    }

    public void SetPopupInactive() 
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
        // gameObject.SetActive(false);
        //resume game time when popup deactivated
    }

    
}
