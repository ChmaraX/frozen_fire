using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelSelectEntry : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI deathsText;
    public TextMeshProUGUI levelNumberText;
    public int levelNumber;

    public string sceneName;

    public void SetLevelData(int coins, int deaths, int totalCoinsCount) 
    {
        coinsText.text = coins.ToString();
        coinsText.text = coins.ToString() + (totalCoinsCount != 0 ? " / " + totalCoinsCount.ToString() : "");
        deathsText.text = deaths.ToString();
        levelNumberText.text = levelNumber.ToString();
        
    }
}
