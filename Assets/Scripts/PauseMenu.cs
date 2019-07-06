//Despina Athanasleri 154427
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioClip PauseSound;
    public AudioSource PauseSource;

    void Start()
    {
        PauseSource.clip = PauseSound; //Θέτω στην πηγη ηχου ποιον ηχο θα παραγει
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) //Αν πατηθεί το κουμπί esc
        {
            if (GameIsPaused)//Αν το παιχνίδι είναι σταματημένο
            {
                Resume(); //Καλώ την μεθοδο Resume
            }
            else
            {
                Pause();//Αλλιώς καλώτην μέθοδο Pause
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false); //Απενεργοποιείται το μενού
        Time.timeScale = 1f; //Συνεχίζεται η αντίστροφη μέτρηση
        GameIsPaused = false; 
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); //Ενεργοποιείται το μενού 
        Time.timeScale = 0f; //Παγώνει ο χρόνος
        GameIsPaused = true;
        PauseSource.Play(); //Παίζει ο ήχος του μενού
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Αν πατηθεί το κουμπί Try Again φορτώνεται ξανά η σκηνή που βρισκόμαστε τώρα
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void MainMenu()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //Αν πατηθεί το κουμπί Main Menu φορτώνεται η προηγούμενη σκηνή
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit(); //Αν πατηθεί το κουμπί Quit κλείνει η εφαρμογή
    }
}
