using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    int score = 0;
    int highScore1, highScore2;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
        highScore1 = PlayerPrefs.GetInt("CatHighSCore1");
        highScore2 = PlayerPrefs.GetInt("CatHighScore2");
    }

    // Update is called once per frame
    public void Correct()
    {
        score += 10;
        PlayerPrefs.SetInt("CatScore", score);
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (score > highScore1)
            {
                highScore1 = score;
                PlayerPrefs.SetInt("CatHighScore1", highScore1);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            if (score > highScore2)
            {
                highScore2 = score;
                PlayerPrefs.SetInt("CatHighScore2", highScore2);
            }
        }
    }
    public void InCorrect()
    {
        score -= 5;
        PlayerPrefs.SetInt("CatScore", score);
    }
    public void ResetScore()
    {
        score = 0;
        PlayerPrefs.SetInt("CatScore", 0);
    }
}
