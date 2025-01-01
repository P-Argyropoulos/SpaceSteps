using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsScript : MonoBehaviour
{
     private TextMeshProUGUI textPoints, lowCreditsText;
    private float  totalPoints , previousPointsValue = 0.5f, displaySeconds = 3f;
    private bool isTextActive;
    

    private void OnEnable()
    {
        EventHandler.OnLowCredits += LowCredits;
    }
     private void OnDisable()
    {
        EventHandler.OnLowCredits -= LowCredits;
    }
    void Start()
    {
        textPoints = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        lowCreditsText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }
    void Update()
    { 
        totalPoints = GameManager.instance.pointSummary;
        if (previousPointsValue != totalPoints)
        {
            textPoints.text = totalPoints.ToString();
            previousPointsValue = totalPoints;
        }
    }

    private void LowCredits()
    {
        lowCreditsText.alpha = 255;
        if (!isTextActive)
        {
             StartCoroutine(DisplayTextForTime(displaySeconds));
        }
    }

    IEnumerator DisplayTextForTime(float seconds)
    {
        isTextActive = true;
        yield return new WaitForSeconds(seconds);
        lowCreditsText.alpha = 0;
        isTextActive = false;
    }
}
