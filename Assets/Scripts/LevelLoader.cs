using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex = 0;
    int loadSceneDelay = 4;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(SceneLoadDelay());
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void OptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    private void OnDestroy()
    {
        Time.timeScale = 1; //When this was in the LoadMainMenu(), my start button wouldn't work. 
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    IEnumerator SceneLoadDelay()
    {
        yield return new WaitForSeconds(loadSceneDelay);
        LoadNextScene();
    }
}
