using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;

    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged += UpdateHUD;
            UpdateHUD(ScoreManager.Instance.Score, ScoreManager.Instance.Multiplier);
        }
    }

    void OnDestroy()
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.OnScoreChanged -= UpdateHUD;
    }

    void UpdateHUD(float score, int mult)
    {
        if (scoreText) scoreText.text = Mathf.FloorToInt(score).ToString("N0");
        if (multiplierText) multiplierText.text = "x" + mult;
    }
}
