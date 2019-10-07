using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonControl : MonoBehaviour {

    //This code handles with PauseButton

    [SerializeField] bool pauseKontrol;
    [SerializeField] GameObject pauseMenu;

    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void pauseGame()
    {
        pauseKontrol = !pauseKontrol;

        if (pauseKontrol)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            audioSource.Stop();
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            audioSource.Play();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
