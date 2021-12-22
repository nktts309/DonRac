using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float timeRemaining = 20;
    private bool timerIsRunning = false;
    public Text timeText;
    public GameObject nextLevelPanel;
    public Text scoreText;
    public Text highScoreText;
    int highScore;
    private void Start()
    {
        timerIsRunning = true;
        highScore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name);
    }

    void Update()
    {      
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }           
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                nextLevelPanel.transform.DOScale(0.7f, 1f);
                if(PlayerPrefs.GetInt("Score") > highScore)
                {
                    highScore = PlayerPrefs.GetInt("Score");
                }
                scoreText.text = "Score " + PlayerPrefs.GetInt("Score");
                highScoreText.text = "HighScore " + highScore;
                Invoke("LoadLevel", 3.0f);
            }
        }     
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void LoadLevel()
    {
        GameManager.Instance.LoadNextScene();       
    }
}
