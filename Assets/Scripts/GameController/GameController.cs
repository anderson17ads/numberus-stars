using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private GameObject gameOverUI;

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
        Time.timeScale = 0;
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
