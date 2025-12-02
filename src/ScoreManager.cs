using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public float Score { get; private set; }
    public int Multiplier { get; private set; } = 1;

    [Header("Tuning")]
    public float pointsPerSecond = 10f;

    public event Action<float,int> OnScoreChanged;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        Score += pointsPerSecond * Multiplier * Time.deltaTime;
        OnScoreChanged?.Invoke(Score, Multiplier);
    }

    public void SetMultiplier(int m)
    {
        Multiplier = Mathf.Max(1, m);
        OnScoreChanged?.Invoke(Score, Multiplier);
    }

    public void ResetAll()
    {
        Score = 0f; Multiplier = 1;
        OnScoreChanged?.Invoke(Score, Multiplier);
    }
}
