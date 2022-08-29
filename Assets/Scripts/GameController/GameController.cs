using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private Text gameOverScoreText;

    [SerializeField]
    private Text gameOverBetterScoreText;

    public static GameController instance;

    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        Time.timeScale = 1;
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        
        gameOverScoreText.text = "Pontuação: " + PlayerController.instance.score;
        
        gameOverBetterScoreText.text = "Melhor Pontuação: " + PlayerController.instance.betterScore;
                
        Time.timeScale = 0;
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
