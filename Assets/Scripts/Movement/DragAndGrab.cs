using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragAndGrab : MonoBehaviour
{
    private Rigidbody2D rig;
    private PolygonCollider2D colliderer;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 startPos;
    private bool isTriggered = false;
    public static DragAndGrab Instance;
    private SpriteRenderer sprite;
    Tween tween;
    // Start is called before the first frame update
    void Start()
    {
        colliderer = GetComponent<PolygonCollider2D>();
        startPos = transform.position;
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    private void OnMouseUp()
    {       
        isTriggered = false;
        colliderer.enabled = false;
        tween = rig.transform.DOMove(startPos, 1.0f).OnComplete(()=> {
            if (tween != null) tween.Kill();
            colliderer.enabled = true;
        });
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        if (isTriggered)
        {
            sprite.enabled = false;
            transform.position = startPos;
            DOVirtual.DelayedCall(0.75f, () => sprite.enabled = true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rig.CompareTag("trash0"))
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
        if (rig.CompareTag("trash1"))
        {           
                if (collision.CompareTag("GTC"))
                {
                    isTriggered = true;
                    transform.position = startPos;
                }
                else
                {
                    isTriggered = false;
                    colliderer.enabled = false;
                    rig.transform.DOMove(startPos, 1.0f);
                }           
        }
        if (rig.CompareTag("trash2"))
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
