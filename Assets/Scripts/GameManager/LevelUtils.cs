using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUtils : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private Text scoreText;
    public static LevelUtils instance;
    public GameObject[] enemies;
    public GameObject[] coins;

    private int enemyCountTotal;
    private int coinCountTotal;

    private int remainingEnemies;
    private int remainingCoins;

    private int collectedCoins = 0;
    private int defeatedEnemies = 0;

    private int score = 0;

    private void Start()
    {
        enemyCountTotal = GameObject.FindGameObjectsWithTag("Enemy").Length;
        coinCountTotal = GameObject.FindGameObjectsWithTag("Coin").Length;
        UpdateScore(score);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        remainingCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        if (remainingEnemies == 0)
        {
            Debug.Log("All enemies are defeated!");
        }

        if (remainingCoins == 0)
        {
            Debug.Log("All coins are collected!");
        }
    }

    public GameObject[] GetEnemies()
    {
        defeatedEnemies = enemyCountTotal - remainingEnemies;
        return enemies;
    }

    public GameObject[] GetCoins()
    {
        collectedCoins = coinCountTotal - remainingCoins;
        return coins;
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
