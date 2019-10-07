using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishLineTrigger : MonoBehaviour
{
    //This code handles with trigger of Finish Line

    [SerializeField] private TextMeshProUGUI nextRaceText;
    [SerializeField] private TextMeshProUGUI gameOverText;

    [SerializeField] drawLine drawLine;

    [SerializeField] GameObject nextLevelButton;

    private float screenLoadTime;
    public bool gameOverControl;
    public bool nextGameControl;

    [SerializeField] GameObject homeButton;

    AudioSource audioSource;

    private void Start()
    {
        nextLevelButton.SetActive(false);
        homeButton.SetActive(false);
        gameOverControl = false;
        nextGameControl = false;

        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }
    private void Update()
    {
        LoadNextScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameOverControl) // If game is not over
        {
            if (collision.tag == "Car" && SceneManager.GetActiveScene().name!="Level3") // If Player reached finish line
            {
                audioSource.Play(); // Play sound
                nextRaceText.text = "CONGRATS!"; // Change the text

                drawLine.camFollow = false; // Camera stops to follow the car

                nextLevelButton.SetActive(true); // Next level button is active
                nextGameControl = true;
            }
            else if(collision.tag == "Car" && SceneManager.GetActiveScene().name == "Level3") // For level3 different text and menu opens
            {
                audioSource.Play();
                nextRaceText.text = "THANKS FOR PLAYING";
                drawLine.camFollow = false;
                homeButton.SetActive(true);
                nextGameControl = true;
            }
        }
        
        if(collision.tag == "Racer") // If the enemy finishes first
        {
            if (!nextGameControl)
            {
                gameOverText.text = "OTHER CAR FINISHED" +"\n" +"GAME OVER"; // Game over text is shown
                drawLine.camFollow = false;
                gameOverControl = true;
            }
           
        }
    }
    void LoadNextScene()
    {
       if(gameOverControl) // It loads GameOver menu
       {
            screenLoadTime += Time.deltaTime;
            if (screenLoadTime > 2)
            {
                SceneManager.LoadScene("GameOverMenu");
                screenLoadTime = 0;

            }
        }
    }
}
