using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragAndGrab : MonoBehaviour
{
    private Rigidbody2D rig;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 startPos;
    private bool isTriggered = false;
    public static DragAndGrab Instance;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rig = GetComponent<Rigidbody2D>();      
    }
    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    private void OnMouseUp()
    {       
            isTriggered = false;
            rig.transform.DOMove(startPos, 1.0f);
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        if (isTriggered)
        {
            rig.transform.position = startPos;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rig.CompareTag("trash0"))
        {
             if (collision.CompareTag("trash2") || collision.CompareTag("trash1"))
            {

            }
            else 
            {               
                if (!collision.CompareTag("RTC"))
                {

                    isTriggered = false;
                    rig.transform.DOMove(startPos, 1.0f);
                }
                else
                {
                    isTriggered = true;
                    transform.position = startPos;
                }                             
            }
        }
        if (rig.CompareTag("trash1"))
        {
            if (collision.CompareTag("trash2") || collision.CompareTag("trash0"))
            {

            }
            else
            {
                if (collision.CompareTag("GTC"))
                {
                    isTriggered = true;
                    transform.position = startPos;
                }
                else
                {
                    isTriggered = false;
                    rig.transform.DOMove(startPos, 1.0f);
                }
            }
        }
        if (rig.CompareTag("trash2"))
        {
            if (collision.CompareTag("trash0") || collision.CompareTag("trash1"))
            {

            }
            else
            {
                if (collision.CompareTag("YTC"))
                {
                    isTriggered = true;
                    transform.position = startPos;
                }
                else
                {
                    isTriggered = false;
                    rig.transform.DOMove(startPos, 1.0f);
                }
            }
        }
    }

}
    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        // register the touch
    //        UnityEngine.Touch touch = Input.GetTouch(0);
    //        Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
    //        pos.z = 0f;
    //        if (touch.phase == TouchPhase.Began)
    //        {

    //            //if you touch the circle
    //            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(pos))
    //            {
    //                //get the offset between the touch's position and the circle's position
    //                deltaX = pos.x - transform.position.x;
    //                deltaY = pos.y - transform.position.y;
    //                //set the bool isTouching to true
    //                isTouching = true;
    //            }
    //        }
    //        // if you're touching and moving the finger
    //        if (isTouching && touch.phase == TouchPhase.Moved)
    //        {
    //            if (GetComponent<BoxCollider2D>() == Physics2D.OverlapPoint(pos))
    //            {
    //                // change the position of the circle to the position of the touch
    //                rig.MovePosition(new Vector2(pos.x - deltaX, pos.y - deltaY));
    //            }
    //        }
    //        // if you stop touching
    //        if (isTouching && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
    //        {
    //            //set isTouching to false
    //            isTouching = false;
    //            // return the removed properties of circle               
    //        }
    //    }
    //}
