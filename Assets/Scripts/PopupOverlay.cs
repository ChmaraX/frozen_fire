using UnityEngine;
using UnityEngine.UI;

public class PopupOverlay : MonoBehaviour
{

    public Text popupTitleTextRef;

    public Text bodyTitleTextRef;

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
