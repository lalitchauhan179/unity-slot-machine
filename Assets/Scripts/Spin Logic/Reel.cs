using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Reel : MonoBehaviour
{
    public Image[] symbolImages; // 0 = Top, 1 = Middle, 2 = Bottom
    public Sprite[] availableSprites;
    public float spinDuration = 100f;

    public IEnumerator Spin()
    {
        float timer = 0f;
        while (timer < spinDuration)
        {
            foreach (Image img in symbolImages)
            {
                img.sprite = availableSprites[Random.Range(0, availableSprites.Length)];
            }
            timer += Time.deltaTime;
            yield return new WaitForSeconds(0.003f);
        }

        // Final assignment to ensure consistency
        foreach (Image img in symbolImages)
        {
            img.sprite = availableSprites[Random.Range(0, availableSprites.Length)];
        }
    }


    public string[] GetSymbols()
    {
        string[] symbols = new string[symbolImages.Length];
        for (int i = 0; i < symbolImages.Length; i++)
        {
            symbols[i] = symbolImages[i].sprite != null ? symbolImages[i].sprite.name : "NULL";
        }
        return symbols;
    }
    public Image GetImageAtRow(int row)
    {
        return symbolImages[row]; // 0 = Top, 1 = Middle, 2 = Bottom
    }
    public void ResetSymbolColors()
    {
        foreach (var img in symbolImages)
        {
            img.color = Color.white;
        }
    }
    public IEnumerator AnimateWin(Image img)
    {
        Color originalColor = img.color;
        Color highlightColor = Color.yellow;

        float duration = 20.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = Mathf.PingPong(Time.time * 5f, 1f);
            img.color = Color.Lerp(originalColor, highlightColor, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        img.color = originalColor;

    }
    private Coroutine currentAnimation;

    public void StartWinAnimation(Image img)
    {
        StopWinAnimation(); // Stop any existing animation
        currentAnimation = StartCoroutine(HeartbeatEffect(img));
    }

    public void StopWinAnimation()
    {
        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
            currentAnimation = null;
        }

        // Reset all symbol image transforms and colors
        foreach (var image in symbolImages)
        {
            image.transform.localScale = Vector3.one;
            image.color = Color.white;
        }
    }

    private IEnumerator HeartbeatEffect(Image img)
    {
        Color highlightColor = Color.yellow;
        Vector3 originalScale = Vector3.one;
        Vector3 pulseScale = originalScale * 1.2f;

        while (true) // run until manually stopped
        {
            img.color = highlightColor;

            // Pulse up
            float t = 0f;
            while (t < 0.2f)
            {
                img.transform.localScale = Vector3.Lerp(originalScale, pulseScale, t / 0.2f);
                t += Time.deltaTime;
                yield return null;
            }

            // Pulse down
            t = 0f;
            while (t < 0.2f)
            {
                img.transform.localScale = Vector3.Lerp(pulseScale, originalScale, t / 0.2f);
                t += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(0.3f); // pause between beats
        }
    }





}