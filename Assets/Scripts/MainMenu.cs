//Despina Athanasleri 154427
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Αν πατηθεί το κουμπί PLAY μεταφερόμαστε στην αμέσως επόμενη σκηνή
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit(); //Αν πατηθεί το κουμπί Quit κλείνει η εφαρμογή
    }
}
