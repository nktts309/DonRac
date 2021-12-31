using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class Categorise : MonoBehaviour
{
    int score;
    int count = 0;
    Rigidbody2D rig;
    GameObject redTC, greenTC, yellowTC;
    GameObject[] go, go1, go2;
    Tween tweenMove = null;
    private GameObject lastBinNeeded = null;
    private int idTrash = -1;

    public Text number;
    [SerializeField] private GameObject bubble;
    [SerializeField] Text chatText;
    [SerializeField] private GameObject bubbleChat;
    [SerializeField] private Text incorrectChatText;
    private List<RecycleBin> listRecycleBin;
    private Action onRemoveTrash;
    private CharacterData characterData;

    // Start is called before the first frame update
    void Start()
    {
        characterData = ResourceData.Instance.CharacterData;
        listRecycleBin = new List<RecycleBin>();
        //Tìm thùng rác
        redTC = GameObject.Find("RedTC");
        greenTC = GameObject.Find("GreenTC");
        yellowTC = GameObject.Find("YellowTC");
        listRecycleBin.Add(redTC.GetComponent<RecycleBin>());
        listRecycleBin.Add(greenTC.GetComponent<RecycleBin>());
        listRecycleBin.Add(yellowTC.GetComponent<RecycleBin>());
        rig = GetComponent<Rigidbody2D>();
        bubble.transform.DOScale(54f, 1f).OnComplete(() => {
            bubble.transform.DOScale(0f, 2f).SetDelay(2.0f);
        });
        number.text = score.ToString();
        rig = GetComponent<Rigidbody2D>();
        if (rig.tag == "trash0")
        {
            score = GameManager.Instance.Score; /*PlayerPrefs.GetInt("redTrash");*/
            onRemoveTrash = () => GameManager.Instance.RemoveRedTrash();
            idTrash = 0;
            if (score == 0)
            {
                Destroy(gameObject);
            }
        }
        if (rig.tag == "trash1")
        {
            score = GameManager.Instance.Score1;
            onRemoveTrash = () => GameManager.Instance.RemoveGreenTrash();
            if (score == 0)
            {
                Destroy(gameObject);
            }
            idTrash = 1;
        }
        if (rig.tag == "trash2")
        {
            score = GameManager.Instance.Score2;
            onRemoveTrash = () => GameManager.Instance.RemoveYellowTrash();
            if (score == 0)
            {
                Destroy(gameObject);
            }
            idTrash = 2;
        }
    }
    // Update is called once per frame
    void Update()
    {
        number.text = score.ToString();
        go = GameObject.FindGameObjectsWithTag("trash0");
        go1 = GameObject.FindGameObjectsWithTag("trash1");
        go2 = GameObject.FindGameObjectsWithTag("trash2");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Keo len sau do check rac
        int idBin = collision.GetComponent<RecycleBin>().Id;
        if (idTrash == idBin)
        {
            ScaleAnimate();
            // Correct
            score--;
            onRemoveTrash?.Invoke();
            count = GameManager.Instance.CheckTrash(idBin);
            bool idNeeded = listRecycleBin[idBin].IsNeeded;
            if (idNeeded)
            {
                listRecycleBin[idBin].PlayConfeti();
                // Bonus point
                ScoreManager.Instance.Correct();
            }
            CorrectText();
            ScoreManager.Instance.Correct();
            if (count == 3)
            {
                var NeededBinID = GameManager.Instance.SpawnConsecutiveTrash(idBin);
                if (NeededBinID >= 0)
                {
                    listRecycleBin[NeededBinID].ShowPopupNeeded();
                }
            }
            if (score == 0)
            {
                number.text = "0";
                Destroy(this.gameObject);
            }
        }
        else
        {
            ScoreManager.Instance.InCorrect();
            //GameManager.Instance.ResetTrashCount();
            InCorrectTrash(listRecycleBin[idTrash].gameObject);
            InCorrectText();
        }
        if (PlayerPrefs.GetInt("PlayScene") + PlayerPrefs.GetInt("CatHighScore1") == 420)
        {
            Debug.Log("Mở khóa pando");
        }
        if (PlayerPrefs.GetInt("PlayScene1") + PlayerPrefs.GetInt("CatHighScore2") == 600)
        {
            Debug.Log("Mở khóa croc");
        }
    } 
    void CorrectText()
    {
        BubbleSpawn();
        chatText.text = "You're correct";
    }
    void InCorrectText()
    {
        BubbleSpawn();
        chatText.text = "You're almost correct";
    }
    void ScaleAnimate()
    {
        transform.DOScale(1.0f, 0.75f).OnComplete(() => {
            transform.DOScale(2.5f, 0.5f);
        });
    }
    void BubbleSpawn()
    {
        tweenMove = bubble.transform.DOScale(54.0f, 0.5f).OnComplete(() => {
            tweenMove =bubble.transform.DOScale(0, 1.0f).SetDelay(1.0f);         
        });      
        bubble.SetActive(true);
    }
    public void InCorrectTrash(GameObject TC)
    {
         tweenMove = bubbleChat.transform.DOScale(58f, 0.5f).OnComplete(() => {
            tweenMove =bubbleChat.transform.DOScale(0, 1).SetDelay(1.0f);
        });
        incorrectChatText.text = "I want that";
        bubbleChat.transform.position = new Vector3(TC.transform.position.x- 1.65f, TC.transform.position.y + 1.5f) ;
    }
}
// if (rig.CompareTag("trash0"))
//{
//    if (collision.tag == "RTC")
//    {
//        score--;
//        count = GameManager.Instance.CheckTrash(0);
//        CorrectText();
//        ScoreManager.Instance.Correct();
//        GameManager.Instance.RemoveRedTrash();
//        if (score > 0)
//        {
//            ScaleAnimate();
//        }                             
//        if (count >=3 && go1.Length >0)
//        {
//            GameManager.Instance.ResetTrashCount();
//            ConsecutiveTrash(greenTC);
//            isNeeding = true;
//        }
//        if (count >= 3 && go1.Length == 0 && go2.Length > 0)
//        {
//            GameManager.Instance.ResetTrashCount();
//            ConsecutiveTrash(yellowTC);
//            isNeeding = true;
//        }
//        if (isNeeding)
//        {
//            PlayFirework(redTC);
//        }
//        if (score == 0)
//        {
//            number.text = "0";
//            Destroy(gameObject);
//        }
//    }
//    else if (collision.CompareTag("trash2") || collision.CompareTag("trash1"))
//    {

//    }
//    else
//    {
//        ScoreManager.Instance.InCorrect();
//        //GameManager.Instance.ResetTrashCount();
//        InCorrectTrash(redTC);
//        InCorrectText();
//    }
//}
//if (rig.CompareTag("trash1"))
//{
//    if (collision.tag == "GTC")
//    {
//        score--;
//        count = GameManager.Instance.CheckTrash(1);
//        CorrectText();
//        ScoreManager.Instance.Correct();
//        GameManager.Instance.RemoveGreenTrash();
//        if (score > 0)
//        {
//            ScaleAnimate();
//        }
//        if (count >=3 && go2.Length >0)
//        {
//            GameManager.Instance.ResetTrashCount();
//            ConsecutiveTrash(yellowTC);
//        }
//        if (count >= 3 && go2.Length == 0 && go.Length >0)
//        {
//            GameManager.Instance.ResetTrashCount();
//            ConsecutiveTrash(redTC);
//        }
//        if (isNeeding)
//        {
//            PlayFirework(greenTC);
//            //ScoreManager.Instance.Correct();
//        }
//        if (score == 0)
//        {
//            number.text = "0";
//            Destroy(gameObject);
//        }             
//    }
//    else if (collision.CompareTag("trash0") || collision.CompareTag("trash2"))
//    {

//    }
//    else
//    {
//        ScoreManager.Instance.InCorrect();
//        //GameManager.Instance.ResetTrashCount();
//        InCorrectTrash(greenTC);
//        InCorrectText();              
//    }
//}
//if (rig.CompareTag("trash2"))
//{
//    if (collision.tag == "YTC")
//    {               
//        score--;
//        count = GameManager.Instance.CheckTrash(2);
//        CorrectText();
//        GameManager.Instance.RemoveYellowTrash();
//        ScoreManager.Instance.Correct();
//        if (score > 0)
//        {
//            ScaleAnimate();
//        }
//        if (count >=3 && go.Length >0)
//        {
//            ConsecutiveTrash(redTC);
//            GameManager.Instance.ResetTrashCount();
//        }
//        if (count >= 3 && go.Length == 0 && go1.Length > 0)
//        {
//            ConsecutiveTrash(greenTC);
//            GameManager.Instance.ResetTrashCount();
//        }
//        if (isNeeding)
//        {
//            PlayFirework(yellowTC);
//        }
//        if (score == 0)
//        {
//            number.text = "0";
//            Destroy(gameObject);
//        }               
//    }
//    else if(collision.CompareTag("trash0") || collision.CompareTag("trash1"))
//    {

//    }
//    else
//    {
//        ScoreManager.Instance.InCorrect();
//        //GameManager.Instance.ResetTrashCount();
//        InCorrectTrash(yellowTC);
//        InCorrectText();
//    }
//}
