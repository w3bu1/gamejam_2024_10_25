using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    [SerializeField] private GameScenes gameScene;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameScene.IsGamePaused)
                gameScene.ResumeGame();
            else
                gameScene.PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameScene.ResumeGame();
        }
    }
}
