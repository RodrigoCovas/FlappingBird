using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text score;
    public GameObject gameOverScreen;
    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!gameOverScreen.activeSelf)
        {
            playerScore += scoreToAdd;
            score.text = playerScore.ToString();
        }

    }

    public void restartGame()
    {
        audioManager.PlaySFX(audioManager.clickButton);
        StartCoroutine(restartGameDelay());
    }

    public void ReturnMainMenu()
    {
        audioManager.PlaySFX(audioManager.clickButton);
        StartCoroutine(ReturnMainMenuDelay());
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        audioManager.PlaySFX(audioManager.death);
        Debug.Log("Game Over");
    }

    private IEnumerator restartGameDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator ReturnMainMenuDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
