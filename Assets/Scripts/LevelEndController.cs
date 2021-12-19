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

    public int currentLifeBuyout { get; private set; } = 2;

    private int buyoutIncrement = 3;

    //show window with game over elements (invoked when player died)
    public void ShowGameOver(PlayerLife playerLife)
    {
        SetPlayerValues(playerLife);
        levelEndMessage.text = "GAME OVER";
        EnableBuyoutButton();
        this.OpenWindow();
    }

    //called when level has been succesfully completed
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

    //take coins from player and teleport him to the previous checkpoint
    public void BuyoutAndResume()
    {
        itemCollector.decreaseCoinsBy(currentLifeBuyout);
        currentLifeBuyout += buyoutIncrement;
        this.CloseWindow();
        this.playerLife.HandleCheckpoint();
    }

    public void ReturnToLevelSelect()
    {
        this.CloseWindow();
        SceneManager.LoadScene("LevelSelect");
    }

    //set needed values for both gameover and level complete scenarios
    private void SetPlayerValues(PlayerLife playerLife)
    {
        this.playerLife = playerLife;
        this.itemCollector = playerLife.itemCollector;
        coinsText.text = playerLife.itemCollector.collectedCoins.ToString();
        deathsText.text = playerLife.itemCollector.deathCount.ToString();
    }

    //workaround for disabling level end screen - rather disable wrapper canvas group
    private void OpenWindow()
    {
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    //enables buyout button and makes in interactable if player can buy himself out using coins
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
