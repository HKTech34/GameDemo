using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //This Code deals with SceneManagement for spesific Scenes

    [SerializeField] private AudioClip buttonClickSound;

    public void StartGame()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonClickSound);
        SceneManager.LoadScene("Level1");
    }
    public void QuitGame() 
    {
        GetComponent<AudioSource>().PlayOneShot(buttonClickSound);
        Application.Quit();
    }
    public void MMenu() 
    {
        GetComponent<AudioSource>().PlayOneShot(buttonClickSound);
        SceneManager.LoadScene("MainMenu");
    }
    public void InfoMenu()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonClickSound);
        SceneManager.LoadScene("InfoMenu");
    }
    public void NextLevel()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonClickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void PreviousScene()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonClickSound);
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
    }
}
