//Despina Athanasleri 154427\
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject alienContainer;
    public TextMesh infoText;
    public Text scoreText;
    public Text highScoreText;
    public float spawnDuration = 1.5f;
    public float spawnDecrement = 0.1f;
    public float minimumSpawnDuration = 0.5f;
    public float gameTimer = 30f;
    public Player player;
    private float spawnTimer = 0f;

    public int highScore = 0;
    string highScoreKey = "HighScore";

    private Alien[] aliens;

    // Use this for initialization
    void Start()
    {
        aliens = alienContainer.GetComponentsInChildren<Alien>();
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    // Update is called once per frame
    void Update()
    {

        gameTimer -= Time.deltaTime;
        if (gameTimer > 0f) //Αν ο χρονος του παιχνιδιου είναι μεγαλυτερος απο μηδεν 
        {
            GameOverMenu.gameOver = false;
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f) //Αν ο μετρητής "εκκόλαψης" είναι μικρότερος από το μηδέν επιστρέφει true 
            {
                aliens[Random.Range(0, aliens.Length)].Rise(); //Εμφανίζεται ένας τυχαίος εξωγήινος
                spawnDuration -= spawnDecrement; //Μειώνεται ο χρόνος που θα εμφανίζονται οι εξωγήινοι(θα εμφανίζονται πιο γρήγορα ο ένας μετά τον άλλο)
                if (spawnDuration <= minimumSpawnDuration) //Αν φτάσει ο χρόνος το μικρότερο δυνατό σημείο
                {
                    spawnDuration = minimumSpawnDuration; //Παραμένει σε αυτό
                }
                spawnTimer = spawnDuration; //Περνάμε αυτόν τον χρόνο στον μετρητή
            }

            infoText.text = "Hit all the aliens!\nTime: " + Mathf.Floor(gameTimer) + "\nScore: " + player.score; //Το μήνυμα που εμφανιζεται για τον χρόνο που μένει και για το σκορ
        }
        else //Όταν μηδενιστεί ο χρόνος του παιχνιδιού
        {
            scoreText.text = "Score: " + player.score; //Εμφάνιση του τελικού score
            if (player.score > highScore)
            {
                highScore = player.score;
                PlayerPrefs.SetInt(highScoreKey, player.score);
                PlayerPrefs.Save();
            }
            highScoreText.text = "High Score: " + highScore; //Εμφάνιση του high score
            GameOverMenu.gameOver = true;
 
        }
    }
}
