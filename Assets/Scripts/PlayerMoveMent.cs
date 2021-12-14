using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerMoveMent : MonoBehaviour
{
    int score, score1, score2;
    float previousDisToTouch, currentDisToTouch;
    bool isMoving = false;
    Rigidbody2D rb;
    Vector3 whereToMove, pos;
    [SerializeField] public List<int> scoreList;

    public Text soRac, soRac1, soRac2;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score =  0; score1 = 0; score2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            currentDisToTouch = (pos - transform.position).magnitude;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);      

            if (touch.phase == TouchPhase.Began)
            {
                previousDisToTouch = 0;
                currentDisToTouch = 0;
                pos = Camera.main.ScreenToWorldPoint(touch.position);
                isMoving = true;
                pos.z = 0;
                whereToMove = (pos - transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * speed, 0);
                if(pos.x < transform.position.x)
                {
                    transform.localScale = new Vector3(-0.75f, 0.75f);
                }
                else
                {
                    transform.localScale = new Vector3(0.75f, 0.75f);
                }
            }           
        }
        if (currentDisToTouch > previousDisToTouch)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }
        if (isMoving)
        {
            previousDisToTouch = (pos - transform.position).magnitude;
        }
    }
    private void OnMouseDown()
    {
        if (gameObject.tag == "trash0")
        {
            score++;
            soRac.text = score.ToString();

        }      
        else if(gameObject.tag == "trash1")
        {
            score1++;
            soRac1.text = score1.ToString();
        }
        else if(gameObject.tag == "trash2")
        {
            score2++;
            soRac2.text = score2.ToString();
        } 
    }
}
