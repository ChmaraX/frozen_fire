using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    public Text levelEndMessage;
    public Text coinsText;
    public Text deathsText;
    public Button buyoutButton;
    public ItemCollector itemCollector;

    private PlayerLife playerLife;

    public int currentLifeBuyout { get; private set; } = 1;

    public void ShowLevelEnd(PlayerLife playerLife, bool gameOver)
    {
        coinsText.text = playerLife.itemCollector.collectedCoins.ToString();
        deathsText.text = playerLife.itemCollector.deathCount.ToString();
        this.playerLife = playerLife;
        if (gameOver)
        {
            levelEndMessage.text = "GAME OVER";
            buyoutButton.gameObject.SetActive(true);
            buyoutButton.interactable = playerLife.itemCollector.collectedCoins >= currentLifeBuyout;
            buyoutButton.GetComponentInChildren<Text>().text = "Buy another life (" + currentLifeBuyout + " coins)";
        }
        else
        {
            buyoutButton.gameObject.SetActive(false);
            levelEndMessage.text = "Level Completed";
        }
         this.OpenWindow();
    }

    public void OpenWindow()
    {
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void CloseWindow()
    {
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void BuyoutAndResume()
    {
        itemCollector.decreaseCoinsBy(currentLifeBuyout);
        itemCollector.increaseHPsBy(1);
        currentLifeBuyout += 3;
        this.CloseWindow();
        this.playerLife.HandleCheckpoint();
    }

    public void ReturnToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

}
