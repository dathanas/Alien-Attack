//Despina Athanasleri 154427
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public static bool gameOver = false;
    public GameObject gameOverMenuUI;
    public AudioClip GameOverSound;
    public AudioSource GameOverSource; 

    void Start()
    {
        GameOverSource.clip = GameOverSound; //Θέτω στην πηγη ηχου ποιον ηχο θα παραγει
        GameOverSource.Play(); //Παίζει ο ήχος 
    }

    void Update()
    {
        if (gameOver)
        {
            GameOver(); 
        }
    }

    public void GameOver()
    {
        gameOverMenuUI.SetActive(true); //Εμφανίζεται το Game Over menu
        
    }

    public void TryAgain()
    {
        gameOverMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Αν πατηθεί το κουμπί Try Again φορτώνεται ξανά η σκηνή που βρισκόμαστε τώρα
    }
    
        
    public void MainMenu()
    {
        gameOverMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //Αν πατηθεί το κουμπί Main Menu φορτώνεται η προηγούμενη σκηνή  
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit(); //Αν πατηθεί το κουμπί Quit κλείνει η εφαρμογή
    }
}
