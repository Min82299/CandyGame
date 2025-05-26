using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FloatingScoreEffect : MonoBehaviour
{
    public float floatSpeed = 30f;
    public float duration = 1.5f;
    public Vector3 moveOffset = new Vector3(0, 100, 0); 

    private TextMeshProUGUI scoreText;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector3 startPos;

    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        startPos = rectTransform.anchoredPosition;
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        float timer = 0f;

        while (timer < duration)
        {
            float progress = timer / duration;

            rectTransform.anchoredPosition = startPos + moveOffset * progress;
            canvasGroup.alpha = 1f - progress;

            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

    public void SetText(string text)
    {
        if (scoreText != null)
        {
            scoreText.text = text;
        }
    }
}
