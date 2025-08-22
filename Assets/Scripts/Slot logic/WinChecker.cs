using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class WinChecker : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI wonAt;

    public List<(int row, int startCol, int count)> winningLines = new();

    /// <summary>
    /// Checks win only on the middle row.
    /// Returns total win amount.
    /// </summary>
    public int CheckWin(string[][] matrix, int betAmount)
    {
        wonAt.text = "";
        int totalWin = 0;
        winningLines.Clear();

        int middleRow = 1; // Always middle
        string[] line = matrix[middleRow];
        int matchCount = 1;
        string currentSymbol = line[0];

        for (int col = 1; col < line.Length; col++)
        {
            if (line[col] == currentSymbol)
            {
                matchCount++;
            }
            else
            {
                break;
            }
        }

        if (matchCount == line.Length) // All reels match
        {
            winningLines.Add((middleRow, 0, matchCount));
            totalWin += matchCount * betAmount;
            ShowWin(middleRow, currentSymbol, totalWin);
        }

        return totalWin;
    }

    void ShowWin(int row, string symbol, int amount)
    {
        Debug.Log($"WIN on Row {row + 1}: {symbol}, Amount: {amount}");
        wonAt.text = $"WIN on Row {row + 1}: {symbol}, Amount: ${amount}";
    }
}
