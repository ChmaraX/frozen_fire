using UnityEngine;
using UnityEngine.UI;

public class PopupOverlay : MonoBehaviour
{

    public Text popupTitleTextRef;

    public Text bodyTitleTextRef;

    //close popup if enter has been pressed
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            this.SetPopupInactive();
        }
    }

    public void Show(string title, string body)
    {
        this.popupTitleTextRef.text = title;
        this.bodyTitleTextRef.text = body;
        this.SetPopupActive();
    }

    //show popup and freeze time
    public void SetPopupActive()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void SetPopupInactive()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

}
