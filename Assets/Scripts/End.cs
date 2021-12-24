using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class End : MonoBehaviour
{
    public GameObject panel;
    int highScore, score;
    public Text highScoreText, scoreText;
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("CatScore");
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            highScore = PlayerPrefs.GetInt("CatHighScore1");
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            highScore = PlayerPrefs.GetInt("CatHighScore2");
        }
       
        GameObject[] go = GameObject.FindGameObjectsWithTag("trash0");
        GameObject[] go1 = GameObject.FindGameObjectsWithTag("trash1");
        GameObject[] go2 = GameObject.FindGameObjectsWithTag("trash2");
        if (go.Length == 0 && go1.Length == 0 && go2.Length == 0)
        {
            panel.transform.DOScale(0.7f, 0.5f);
            scoreText.text = "Score " + score.ToString();
            highScoreText.text = "HighScore " + highScore.ToString();
        }
    }
}
