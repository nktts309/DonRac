using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score;
    private int score1;
    private int score2;
    private int huuCo, voCo, taiChe;
    [SerializeField] Text greenText;
    [SerializeField] Text redText;
    [SerializeField] Text yellowText;
    //Categorise trash
    [SerializeField] private List<RecycleBin> recycleBins = new List<RecycleBin>();
    private int lastBinId = -1;
    private int tempCount = 0;
    //Get Scene
    GameObject canvas;
    //Get score and highscore
    private int scoreCollect;
    private int highScore;
    private int highScore1, highScore2;

    public int Score { get => score; set => score = value; }
    public int Score1 { get => score1; set => score1 = value; }
    public int Score2 { get => score2; set => score2 = value; }
    public int IdSprite { get => idSprite; set => idSprite = value; }
    public bool IsChoosing { get => isChoosing; set => isChoosing = value; }
    // Swap sprite
    int idSprite;
    bool isChoosing;
    private void Awake()
    {      
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
        highScore = PlayerPrefs.GetInt("PlayScene");
        highScore1 = PlayerPrefs.GetInt("PlayScene1");
        highScore2 = PlayerPrefs.GetInt("PlayScene2");
        tempCount = 1;
        idSprite = PlayerPrefs.GetInt("SpriteID");
    }
    public void Addredtrash()
    {
        Score++;
        redText.text = Score.ToString();
    }
    public void Addgreentrash()
    {
        Score1++;
        greenText.text =Score1.ToString();
    }   
    public void Addyellowtrash()
    {
        Score2++;
        yellowText.text = Score2.ToString();
    }   
    public void RemoveRedTrash()
    {
        Score--;
    }
    public void RemoveGreenTrash()
    {
        Score1--;
    }
    public void RemoveYellowTrash()
    {
        Score2--;
    }
    public void AddOrganic()
    {
        huuCo++;
        PlayerPrefs.SetInt("HuuCo", huuCo);
        Debug.Log("HuuCo" + huuCo);
    }
    public void AddInOrganic()
    {
        voCo++;
        PlayerPrefs.SetInt("VoCo", voCo);
        Debug.Log("VoCo" + voCo);
    }
    public void AddRecycle()
    {
        taiChe++;
        PlayerPrefs.SetInt("TaiChe", taiChe);
        Debug.Log("TaiChe" + taiChe);
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //lastBinId = -1;
        ResetText();
        DeActivateCanvas();
    }
    public void LoadCollectTrash()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ResetPref();
        ResetScore();
        ActivateCanvas();
    }
    public void DeActivateCanvas()
    {
        canvas = GameObject.FindGameObjectWithTag("CanV") ;
        canvas.GetComponent<Canvas>().enabled = false;        
    }
    public void ActivateCanvas()
    {
        canvas = GameObject.FindGameObjectWithTag("CanV");
        canvas.GetComponent<Canvas>().enabled = true;
    }
    public void ResetPref()
    {
        Score = 0;
        Score1 = 0;
        Score2 = 0;
        PlayerPrefs.SetInt("HuuCo", 0);
        PlayerPrefs.SetInt("VoCo", 0);
        PlayerPrefs.SetInt("TaiChe", 0);
    }
    public void ResetText()
    {
        redText.text = "0";
        greenText.text = "0";
        yellowText.text = "0";
    }
    public void AddScore()
    {
        scoreCollect += 10;
        PlayerPrefs.SetInt("Score", scoreCollect);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (scoreCollect > highScore)
            {
                highScore = scoreCollect;
                PlayerPrefs.SetInt("PlayScene", highScore);
            }
        }      
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (scoreCollect > highScore1)
            {
                highScore1 = scoreCollect;
                PlayerPrefs.SetInt("PlayScene1", highScore1);
            }         
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (scoreCollect > highScore2)
            {
                highScore2 = scoreCollect;
                PlayerPrefs.SetInt("PlayScene2", highScore2);
            }         
        }
    }
    public void ResetScore()
    {
        scoreCollect = 0;
        PlayerPrefs.SetInt("Score", 0);
    }
    public int CheckTrash(int binId)
    {
        if(lastBinId == binId)
        {
            tempCount++;
        }
        else
        {
            lastBinId = binId;
            tempCount = 1;
        }
        return tempCount;
    }
    public void ResetTrashCount()
    {
        lastBinId = -1;
        tempCount = 1;
    }
    public int SpawnConsecutiveTrash(int currentBin)
    {
        switch (currentBin)
        {
            case 0: 
                if (score1 > 0)
                {
                    ResetTrashCount();
                    return 1;
                }
                else if (score1 == 0 && score2 > 0)
                {
                    return 2;
                }
                break;
            case 1:
                if (score2 > 0)
                {
                    ResetTrashCount();
                    return 2 ;
                }
                else if (score2 == 0 && score > 0)
                {
                    return 0;
                }
                break;
            case 2:
                if (score > 0)
                {
                    ResetTrashCount();
                    return 0;
                }
                else if (score == 0 && score1 > 0)
                {
                    return 1;
                }
                break;
        }

        return -1;
    }
    public void SwapSprite(int id)
    {
        idSprite = id;
        PlayerPrefs.SetInt("SpriteID", idSprite);
    }   
}
