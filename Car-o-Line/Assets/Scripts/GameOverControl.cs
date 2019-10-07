using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;
    private float screenLoadTime;
    bool gameOverControl = false;

    private void Update()
    {
        loadGameOverScene();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wheel" || collision.gameObject.tag == "Car")
        {

            gameOverControl = true;

        }
    }
    private void loadGameOverScene()
    {
        if (gameOverControl)
        {
            gameOverText.text = "GAME OVER";
            screenLoadTime += Time.deltaTime;
            if (screenLoadTime > 2) // Oyun bittikten sonra oyunbitti true olur ve 2 sn sonra diğer sahneye geçer.
            {

                SceneManager.LoadScene("GameOverMenu"); // Game over sahnesini yükle
                screenLoadTime = 0;

            }
        }
       
    }
}


