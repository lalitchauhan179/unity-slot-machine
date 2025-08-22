using UnityEngine;
using TMPro;

public class BalanceManager : MonoBehaviour
{
    [Header("Balance Settings")]
    public int balance = 1000;
    public TMP_Text balanceText;

    /// <summary>
    /// Deducts amount from balance if sufficient.
    /// Returns true if successful.
    /// </summary>
    public bool Deduct(int amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Adds amount to balance.
    /// </summary>
    public void Add(int amount)
    {
        balance += amount;
        UpdateUI();
    }

    /// <summary>
    /// Updates the balance display UI.
    /// </summary>
    void UpdateUI()
    {
        balanceText.text = $"Balance: ${balance}";
    }
}
