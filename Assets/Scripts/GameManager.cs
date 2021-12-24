using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    //SpawnTrash 
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private List<GameObject> currentList;
    [SerializeField] private List<GameObject> redTrash;
    [SerializeField] private List<GameObject> greenTrash;
    [SerializeField] private List<GameObject> yellowTrash;

    [SerializeField] private List<RecycleBin> recycleBins = new List<RecycleBin>();
    private int lastBinId = -1;
    private int tempCount = 0;
    //Get Scene
    GameObject canvas;
    //Get score and highscore
    private int scoreCollect;
    private int highScore;
    private int highScore1 ;

    private void Awake()
    {      
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
        highScore = PlayerPrefs.GetInt("PlayScene");
        highScore1 = PlayerPrefs.GetInt("PlayScene1");
    }
    public void Addredtrash()
    {
        score++;
        redText.text = score.ToString();
        PlayerPrefs.SetInt("redTrash", score);
    }
    public void Addgreentrash()
    {
        score1++;
        PlayerPrefs.SetInt("greenTrash", score1);
        greenText.text = PlayerPrefs.GetInt("greenTrash").ToString();
    }   
    public void Addyellowtrash()
    {
        score2++;
        yellowText.text = score2.ToString();
        PlayerPrefs.SetInt("yellowTrash", score2);
    }   
    public void RemoveRedTrash()
    {
        score--;
        PlayerPrefs.SetInt("redTrash", score);
    }
    public void RemoveGreenTrash()
    {
        score1--;
        PlayerPrefs.SetInt("greenTrash", score1);
    }
    public void RemoveYellowTrash()
    {
        score2--;
        PlayerPrefs.SetInt("yellowTrash", score2);
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
        lastBinId = -1;
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
    public void ButtonAnimate()
    {
        GameObject button = new GameObject();
        button.transform.DOScale(1.5f, 0.5f).OnComplete(() => {
            button.transform.DOScale(0.5f, 0.5f);
        });
    }
    //public void OnRecycleTrash(int idBin = 0)
    //{
    //    if(idBin == lastBinId)
    //    {
    //        tempCount += 1;
    //        if (tempCount >= 3)
    //        {
    //            // Show Popup
    //            tempCount = 0;
    //            // idBin là thùng nào đc ăn 3 lần liên tiếp rồi 
    //            // => random show popup ở 2 thùng kia
    //            var rd = Random.Range(0, recycleBins.Count);
    //            while(rd == idBin)
    //            {
    //                rd = Random.Range(0, recycleBins.Count);
    //            }
    //            recycleBins[rd].ShowPopup();
    //        }
    //    }
    //    else
    //    {
    //        tempCount = 0;
    //    }
    //    lastBinId = idBin;
    //}    
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
        score = 0;
        score1 = 0;
        score2 = 0;
        PlayerPrefs.SetInt("redTrash", 0);
        PlayerPrefs.SetInt("greenTrash", 0);
        PlayerPrefs.SetInt("yellowTrash", 0);
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
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, highScore);
            }
        }      
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (scoreCollect > highScore1)
            {
                highScore1 = scoreCollect;
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, highScore1);
            }         
        }

    }
    public void ResetScore()
    {
        scoreCollect = 0;
        PlayerPrefs.SetInt("Score", 0);
    }
}
