using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {
        UpdateScore();
        int level = LevelLoader.selectedLevel;

        Debug.Log("Current Level: " + level);

        LoadLevel(level);
    }

    void LoadLevel(int level)
    {
        // sau này load map prefab ở đây
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
    
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}