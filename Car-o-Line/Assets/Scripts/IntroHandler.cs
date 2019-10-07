using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroHandler : MonoBehaviour {

    // It loads MainMenu after intro
    private float sceneLoadTime;

    private void FixedUpdate()
    {
        sceneLoadTime += Time.fixedDeltaTime;
        if (sceneLoadTime > 3.3)
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }
}
