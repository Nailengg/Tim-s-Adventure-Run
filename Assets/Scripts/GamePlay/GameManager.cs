using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        int level = LevelLoader.selectedLevel;

        Debug.Log("Current Level: " + level);

        LoadLevel(level);
    }

    void LoadLevel(int level)
    {
        // sau này load map prefab ở đây
    }
}