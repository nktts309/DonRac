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
    GameObject[] go, go1, go2;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {     
        if(Time.frameCount % 60 == 0)
        {
            go = GameObject.FindGameObjectsWithTag("trash0");
            go1 = GameObject.FindGameObjectsWithTag("trash1");
            go2 = GameObject.FindGameObjectsWithTag("trash2");
            GetScore();
            if (go.Length == 0 && go1.Length == 0 && go2.Length == 0)
            {
                GetScore();
                panel.SetActive(true);
                panel.transform.DOScale(0.7f, 0.5f);
                scoreText.text = "Score " + score.ToString();
                highScoreText.text = "HighScore " + highScore.ToString();
            }
        }
    }
    void GetScore()
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
    }
}
