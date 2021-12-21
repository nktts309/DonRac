using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerMoveMent : MonoBehaviour
{
    int score, score1, score2;
    float previousDisToTouch, currentDisToTouch;
    bool isMoving = false;
    Rigidbody2D rb;
    Vector3 whereToMove, pos;
    private Vector3 screenPoint;
    Tween tween;
    //[SerializeField] public List<int> scoreList;

    public Text soRac, soRac1, soRac2;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    private void PlayerMove()
    {       
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                pos = Camera.main.ScreenToWorldPoint(touch.position);
                pos.z = 0;
                transform.DOMoveX(pos.x, 1.5f).SetEase(Ease.Linear);
                if (pos.x < transform.position.x)
                {
                    transform.localScale = new Vector3(-0.75f, 0.75f);
                }
                else
                {
                    transform.localScale = new Vector3(0.75f, 0.75f);
                }
            }
        }       
    }
    private void Update()
    {
        PlayerMove();
    }
    //private void OnMouseDown()
    //{
    //    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    //    transform.DOMoveX(screenPoint.x,1.5f).SetEase(Ease.Linear);
    //    if (screenPoint.x < transform.position.x)
    //    {
    //        transform.localScale = new Vector3(-0.75f, 0.75f);
    //    }
    //    else
    //    {
    //        transform.localScale = new Vector3(0.75f, 0.75f);
    //    }
    //}
}
