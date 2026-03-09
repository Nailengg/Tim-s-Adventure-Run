using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static int selectedLevel;

    public void LoadLevel(int level)
    {
        selectedLevel = level;
        SceneManager.LoadScene("LoadingMap");
    }
}