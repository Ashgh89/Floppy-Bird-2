using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverTxt;
    public bool gameOver = false;
    public static bool isPaused = false;
    public GameObject pauseUI;
    public Text ScoreTxt;
    public Text highScoreTxt;
    public GameObject startUI;
    private bool pressF = false;
    public float scrollSpeed = -1.5f;
    public int score = 0;
    public int hightScore = 0;
    

    // we allow it to be accessible easily from any of our scripts
    public static GameController instance;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOverTxt.SetActive(false);
        pauseUI.SetActive(false);
        startUI.SetActive(true);
        Time.timeScale = 0;
       


        if (PlayerPrefs.HasKey("HighScore"))
        {
            hightScore = PlayerPrefs.GetInt("HighScore");
            highScoreTxt.text = "High Score: " + hightScore.ToString();

        }


        // making sure that there are no other instances of game control 

        // it means there is no game control found
        if (instance == null)
        {
           // we came online we discovered no other game control, so this is the game control
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.F) && !pressF) 
        {
            Time.timeScale = 1;
            startUI.SetActive(false);
            pressF = true;
        }



        if (gameOver && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            // ResetHighScore();
            highScoreTxt.text = "High Score: " + hightScore.ToString();

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
                

            }

            else
            {
                Pause();
            }
        
        }
   
    }

    public void Resume()
    {
       
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
      

    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       // GameObject.Find("Bird").GetComponent<Move2>().enabled = false;
    }
    
    public void BirdScore()
    {
       // if (gameOver)
       // {
       //     UpdateAddScore();
       //     return;
       // }
        score++; 
        ScoreTxt.text = "Score: " + score.ToString();
       // UpdateAddScore();
       
    }

   
    public void UpdateAddScore()
    {
      
      //  highScoreTxt.text = "High Score: " + hightScore.ToString();


        if (score >= hightScore)
        {
            hightScore = score;
        }

        PlayerPrefs.SetInt("HighScore", hightScore);

    }
    
    public void Die()
    {
       
        

            gameOverTxt.SetActive(true);
            gameOver = true;
            score = 0;
        
       
   
    }

    public void QuitGame()
    {
         UnityEditor.EditorApplication.isPlaying = false; 
       // Application.Quit();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    


}
