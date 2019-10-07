using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] bool MusicOnOff = true; // Muzik açık kapalı kontrol
    [SerializeField] Sprite musicONIMG, musicOFFIMG; // Muzik açıkken, muzik kapalı iken sprite
    [SerializeField] Image targetIMG; // Tıklanabilmesi için bir image gerekiyordu bizde bu resmi atadık ve onun spriteını değiştirdik tıklama oldukça
    AudioSource audioSource; // Audio source u aldık
    

    void Awake()
    {
        SetUpSingleton();
    }
    
    private void SetUpSingleton() // Sahneler değiştikçe müzik devam etsin diye singleton oluşturduk.
    {
     
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
          
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        stopOnGameScene();
    }

    public void muteButtonControl() // Mute buttonun çağırdığı metod
    {

        MusicOnOff = !MusicOnOff; // Her clickte değişiyor açık ise kapalı,kapalı ise açık oluyor
        audioSource = GetComponent<AudioSource>(); // Ses componentini aldık

        if (MusicOnOff) // Eğer muzik açık ise
        {
            audioSource.Play(); // Müziği çal
            targetIMG.sprite = musicONIMG; // Ve müzik açık resmini göster

        }
        else
        {
            audioSource.Stop(); // müziği durdur
            targetIMG.sprite = musicOFFIMG; // müzik kapalı resmini göster
        }
    }
    private void stopOnGameScene() // DontDestroy kullandığımız için gamescenede çalışıyor bu class bunun önüne geçmek için oluşturulmuş metod.
    {

        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Level3") // Eğer oyun ekranında isek
        {
            GetComponent<Canvas>().enabled = false;  // Butonu kapat
            GetComponent<Button>().interactable = false;// Butonu kapat
            GetComponent<AudioSource>().enabled = false; // Sesi kapat
         
        }
        if (SceneManager.GetActiveScene().name == "MainMenu"|| SceneManager.GetActiveScene().name == "InfoMenu" || SceneManager.GetActiveScene().name == "GameOverMenu") 
        {
            GetComponent<Canvas>().enabled = true;  // Butonu aç
            GetComponent<Button>().interactable = true; // Butonu aç
            if (MusicOnOff) { GetComponent<AudioSource>().enabled = true; } // Eğer muzik kontrol true ise müziği aç
            
          
        }
       
    }

}