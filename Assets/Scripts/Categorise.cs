using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Categorise : MonoBehaviour
{
    int score, redT, greenT, yellowT;
    int count = 0;
    Vector2 currentPos;
    Rigidbody2D rig;
    GameObject redTC, greenTC, yellowTC;
    GameObject[] go, go1, go2;
    Tween tweenMove = null;

    public Text number;
    [SerializeField] private GameObject bubble;
    [SerializeField] Text chatText;
    [SerializeField] private GameObject bubbleChat;
    [SerializeField] Text incorrectChatText;
    // Start is called before the first frame update
    void Start()
    {       
        //Set số rác mỗi loại
        redT = PlayerPrefs.GetInt("redTrash");
        greenT = PlayerPrefs.GetInt("greenTrash");
        yellowT = PlayerPrefs.GetInt("yellowTrash");
        //Tìm thùng rác
        redTC = GameObject.Find("RedTC");
        greenTC = GameObject.Find("GreenTC");
        yellowTC = GameObject.Find("YellowTC");
        rig = GetComponent<Rigidbody2D>();
        bubble.transform.DOScale(81f, 1f).OnComplete(()=> {
            bubble.transform.DOScale(0f, 2f).SetDelay(2.0f);
        });
        
        currentPos = rig.transform.position;
        number.text = score.ToString();
        rig = GetComponent<Rigidbody2D>();
        if (rig.tag == "trash0")
        {
            score = PlayerPrefs.GetInt("redTrash");
        }
        if (rig.tag == "trash1")
        {
            score = PlayerPrefs.GetInt("greenTrash");
        }
        if (rig.tag == "trash2")
        {
            score = PlayerPrefs.GetInt("yellowTrash");
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
        if (rig.tag == "trash0")
        {
            if (collision.tag == "RTC")
            {
                score--;
                count++;
                CorrectText();    
                //GameManager.Instance.OnRecycleTrash(0);
                if (score > 0)
                {
                    ScaleAnimate();
                }               
                if (score == 0)
                {
                    number.text = "0";
                    Destroy(gameObject);
                }
                if (count >=3 && go1.Length >0)
                {
                    count = 0;
                    ConsecutiveTrash(greenTC);                   
                }
                if (count >= 3 && go1.Length == 0 && go2.Length > 0)
                {
                    count = 0;
                    ConsecutiveTrash(yellowTC);
                }
            }
            else if (collision.tag == "trash2" || collision.tag == "trash1")
            {

            }
            else
            {
                count = 0;
                InCorrectTrash(redTC);
                InCorrectText();
                ScaleAnimate();
            }
        }
        if (rig.tag == "trash1")
        {
            if (collision.tag == "GTC")
            {
                score--;
                count++;
                CorrectText();
                //GameManager.Instance.OnRecycleTrash(1);
                if (score > 0)
                {
                    ScaleAnimate();
                }
                if (count >=3 && go2.Length >0)
                {
                    count = 0;
                    ConsecutiveTrash(yellowTC);
                }
                if (count >= 3 && go2.Length == 0 && go.Length >0)
                {
                    count = 0;
                    ConsecutiveTrash(redTC);
                }
                if (score == 0)
                {
                    number.text = "0";
                    Destroy(gameObject);
                }
            }
            else if (collision.tag == "trash0" || collision.tag == "trash2")
            {

            }
            else
            {
                count = 0;
                InCorrectTrash(greenTC);
                InCorrectText();
                ScaleAnimate();                
            }
        }
        if (rig.tag == "trash2")
        {
            if (collision.tag == "YTC")
            {               
                score--;
                count++;
                CorrectText();
                //GameManager.Instance.OnRecycleTrash(2);
                if (score > 0)
                {
                    ScaleAnimate();
                }
                if (count >=3 && go.Length >0)
                {
                    ConsecutiveTrash(redTC);
                    count = 0;
                }
                if (count >= 3 && go.Length == 0 && go1.Length > 0)
                {
                    ConsecutiveTrash(greenTC);
                    count = 0;
                }
                if (score == 0)
                {
                    number.text = "0";
                    Destroy(gameObject);
                }
            }
            else if(collision.tag == "trash0"|| collision.tag == "trash1")
            {

            }
            else
            {
                count = 0;
                InCorrectTrash(yellowTC);
                InCorrectText();
                ScaleAnimate();
            }
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
        transform.DOScale(1.0f, 0.2f).OnComplete(() => {
            transform.DOScale(2.0f, 0.2f);
        });
    }
    void BubbleSpawn()
    {
        tweenMove = bubble.transform.DOScale(81.0f, 0.5f).OnComplete(() => {
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
    public void ConsecutiveTrash(GameObject TC)
    {       
         bubbleChat.transform.DOScale(58f, 0.5f).OnComplete(() => {
            bubbleChat.transform.DOScale(0, 1).SetDelay(1.0f);
        });
        incorrectChatText.text = "Please feed me too!";
        bubbleChat.transform.position = new Vector3(TC.transform.position.x - 1.65f, TC.transform.position.y + 1.5f);
    }
}
