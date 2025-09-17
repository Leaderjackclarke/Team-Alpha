using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Will load in the menu.
/// Will keep track of gameplay elements from all scenes.
/// </summary>
public class MainGameManager : MonoBehaviour
{
    int currentLevel = 1;
    [SerializeField] int maxLevels = 1;


    public static MainGameManager Instance;


    void Start()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;

        DontDestroyOnLoad(gameObject);
        maxLevels = SceneManager.sceneCountInBuildSettings;
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        if (currentLevel >= maxLevels)
            currentLevel = 0;

        SceneManager.LoadScene(currentLevel);
    }


}
