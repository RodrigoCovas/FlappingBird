using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    AudioManager audioManager;
    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void PlayGame()
    {
        audioManager.PlaySFX(audioManager.clickButton);
        StartCoroutine(LoadSceneDelay());
    }

    public void QuitGame()
    {
        audioManager.PlaySFX(audioManager.clickButton);
        StartCoroutine(QuitGameDelay());

    }

    public IEnumerator LoadSceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator QuitGameDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
