using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics.Tracing;
using System;

public class CandyMananger : MonoBehaviour
{
    public int defaultCandyAmount = 30;
    public int candy;
    public TextMeshProUGUI candyAmount;
    public TextMeshProUGUI countDown;
    const int RecoveryTime = 10;    //Time de tang them keo
    int counter;    // Dong ho dem nguoc

    public int totalScore = 0;
    public TextMeshProUGUI totalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        candy = defaultCandyAmount; // dat so luong keo ban dau
        DisplayCandyAmount();
    }
    private void Update()
    {
        if (counter <= 0 && candy < defaultCandyAmount)
        {
            StartCoroutine(RecoveryCandy()); // Neu bo dem ve 0 thi bat dau lai
        }
    }
    IEnumerator RecoveryCandy() // Bat dau dem
    {
        counter = RecoveryTime;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1.0f); // Cho 1s
            counter--;
            // Debug.Log("counter: " + counter);
            countDown.SetText("(" + counter + "s )");
        }
        candy++;
        DisplayCandyAmount();
    }

    public void ConsumeCandy()
    {
        if (candy > 0)
        {
            candy--;
        }
    }

    public void AddCandy(int amount)
    {
        candy += amount;
    }

    // Hien thi so luong keo
    public void DisplayCandyAmount()
    {
        candyAmount.SetText("Candy :" + candy);
    }
    public int GetCandyAmount()
    {
        return candy;
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (totalScoreText != null)
        {
            totalScoreText.SetText("Score: " + totalScore);
        }
    }
}
