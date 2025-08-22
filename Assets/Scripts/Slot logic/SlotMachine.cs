using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    [Header("Reels & Logic")]
    public Reel[] reels;                 // Assign 5 reels in Inspector
    public WinChecker winChecker;
    public BalanceManager balanceManager;
    public BetManager betManager;

    [Header("UI")]
    public Button spinButton;
    public TextMeshProUGUI totalWinText;

    [Header("Handle Animation")]
    public Animator handleAnimator;      // Animator for slot handle
    private readonly string handleTrigger = "Pull";
    private readonly float handleDelay = 0.3f; // Delay before reels spin (matches animation time)

    /// <summary>
    /// Called when spin button is pressed.
    /// Deducts bet, pulls handle, spins reels, checks wins.
    /// </summary>
    public void SpinButton()
    {
        // Stop any previous animations
        foreach (Reel reel in reels)
        {
            reel.StopWinAnimation();
        }

        if (balanceManager.Deduct(betManager.betAmount))
        {
            if (handleAnimator != null)
            {
                handleAnimator.SetTrigger(handleTrigger); // Play handle animation
            }

            // Wait a short moment so the handle visibly pulls before reels start
            StartCoroutine(SpinWithHandleDelay());
        }
        else
        {
            Debug.LogWarning("Not enough balance to spin!");
        }
    }

    IEnumerator SpinWithHandleDelay()
    {
        // Small pause to sync with handle pull animation
        yield return new WaitForSeconds(handleDelay);

        // Start reel spinning
        yield return StartCoroutine(SpinAllReels());
    }

    IEnumerator SpinAllReels()
    {
        totalWinText.text = "";
        spinButton.interactable = false;

        // Reset visuals before spin
        foreach (Reel reel in reels)
        {
            reel.ResetSymbolColors();
        }

        // Spin each reel sequentially with slight delay
        for (int i = 0; i < reels.Length; i++)
        {
            yield return StartCoroutine(reels[i].Spin());
            yield return new WaitForSeconds(0.1f); // Adds realism
        }

        // Build the matrix of results
        string[][] matrix = new string[3][];
        for (int row = 0; row < 3; row++)
        {
            matrix[row] = new string[reels.Length];
        }

        for (int i = 0; i < reels.Length; i++)
        {
            string[] symbols = reels[i].GetSymbols();
            for (int row = 0; row < 3; row++)
            {
                matrix[row][i] = symbols[row];
            }
        }

        // Check win only on middle line
        int winAmount = winChecker.CheckWin(matrix, betManager.betAmount);
        balanceManager.Add(winAmount);

        // Update UI
        if (winAmount > 0)
            totalWinText.text = $"You Win: ${winAmount}";
        else
            totalWinText.text = "No Win";

        // Highlight winning symbols
        foreach (var (row, startCol, count) in winChecker.winningLines)
        {
            for (int col = startCol; col < startCol + count; col++)
            {
                Image img = reels[col].GetImageAtRow(row);
                reels[col].StartWinAnimation(img);
            }
        }

        spinButton.interactable = true;
    }
}
