using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompletedController : MonoBehaviour
{

    public Text coinsText;
    public Text deathsText;

    // Start is called before the first frame update
    public void SetValuesAndOpenWindow(int coinCount, int deathCount)
    {
        coinsText.text = coinCount.ToString();
        deathsText.text = deathCount.ToString();
        this.OpenWindow();
    }

    public void OpenWindow() {
        gameObject.SetActive(true);
    }

    public void ReturnToLevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }

}
