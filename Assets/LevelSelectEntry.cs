using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelSelectEntry : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI deathsText;
    public TextMeshProUGUI levelNumberText;
    public int levelNumber;

    public void SetLevelData(int coins, int deaths) 
    {
        coinsText.text = coins.ToString();
        deathsText.text = deaths.ToString();
        levelNumberText.text = levelNumber.ToString();
    }
}
