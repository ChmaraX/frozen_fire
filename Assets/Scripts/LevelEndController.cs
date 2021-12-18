using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    public Text levelEndMessage;
    public Text coinsText;
    public Text deathsText;
    public Button buyoutButton;
    private ItemCollector itemCollector;

    private PlayerLife playerLife;

    public int currentLifeBuyout { get; private set; } = 1;

    public void ShowGameOver(PlayerLife playerLife)
    {
        SetPlayerValues(playerLife);
        levelEndMessage.text = "GAME OVER";
        EnableBuyoutButton();
        this.OpenWindow();
    }

    public void ShowLevelCompleted(PlayerLife playerLife)
    {
        SetPlayerValues(playerLife);
        levelEndMessage.text = "Level Completed";
        this.OpenWindow();
    }

    public void CloseWindow()
    {
        buyoutButton.gameObject.SetActive(false);
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
        this.CloseWindow();
        SceneManager.LoadScene("LevelSelect");
    }

     private void SetPlayerValues(PlayerLife playerLife) 
    {
        this.playerLife = playerLife;
        this.itemCollector = playerLife.itemCollector;
        coinsText.text = playerLife.itemCollector.collectedCoins.ToString();
        deathsText.text = playerLife.itemCollector.deathCount.ToString();
    }

    private void OpenWindow()
    {
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void EnableBuyoutButton() 
    {
        buyoutButton.gameObject.SetActive(true);
        bool isInteractable = playerLife.itemCollector.collectedCoins >= currentLifeBuyout;
        buyoutButton.interactable = isInteractable;
        if (!isInteractable) 
        {
            SoundManagerScript.PlaySound("gameOver");
        }
        buyoutButton.GetComponentInChildren<Text>().text = "Buy another life (" + currentLifeBuyout + " coins)";
    }

}
