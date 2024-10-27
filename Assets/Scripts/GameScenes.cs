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

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        if (gamePausePanel == null)
            return;
        ShowCursor();
        gamePausePanel.gameObject.SetActive(true);
        runtimePanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        gameWinPanel.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        if (runtimePanel == null)
            return;
        HideCursor();
        runtimePanel.gameObject.SetActive(true);
        gamePausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
        gameOverPanel.gameObject.SetActive(false);
        gameWinPanel.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        if (gameOverPanel == null)
            return;
        ShowCursor();
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        gameWinPanel.gameObject.SetActive(false);
        runtimePanel.gameObject.SetActive(false);
        gamePausePanel.gameObject.SetActive(false);
    }

    public void GameWin()
    {
        if (gameWinPanel == null)
            return;
        ShowCursor();
        gameWinPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        runtimePanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        gamePausePanel.gameObject.SetActive(false);
        LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        HideCursor();
        string activeSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(activeSceneName);
    }

    public void QuitGame()
    {
        ShowCursor();
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    private IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(2f);
        LoadScene("MainMenu");
    }
}
