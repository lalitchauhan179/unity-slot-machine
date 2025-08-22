using UnityEngine;
using TMPro;

public class BetManager : MonoBehaviour
{
    [Header("Bet Settings")]
    public int betAmount = 10;
    public int minBet = 10;
    public int maxBet = 100;
    public TMP_Text betText;

    public void IncreaseBet()
    {
        if (betAmount < maxBet)
        {
            betAmount += 10;
            UpdateUI();
        }
    }

    public void DecreaseBet()
    {
        if (betAmount > minBet)
        {
            betAmount -= 10;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        betText.text = $"Bet: ${betAmount}";
    }
}
