using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScenes : MonoBehaviour
{
    [SerializeField] private Transform gamePausePanel;
    [SerializeField] private Transform gameOverPanel;
    [SerializeField] private Transform gameWinPanel;
    [SerializeField] private Transform runtimePanel;

    public static GameScenes Instance;
    public bool IsGamePaused { get { return Time.timeScale == 0; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gamePausePanel.gameObject.SetActive(true);
        runtimePanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        gameWinPanel.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        gamePausePanel.gameObject.SetActive(false);
        runtimePanel.gameObject.SetActive(true);
        Time.timeScale = 1;
        gameOverPanel.gameObject.SetActive(false);
        gameWinPanel.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        gameWinPanel.gameObject.SetActive(false);
        runtimePanel.gameObject.SetActive(false);
        gamePausePanel.gameObject.SetActive(false);
    }

    public void GameWin()
    {
        gameWinPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        runtimePanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        gamePausePanel.gameObject.SetActive(false);
        StartCoroutine(WaitAndRestart());
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        // store active scene name
        string activeSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(activeSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    private IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(5f);
        RestartGame();
    }
}
