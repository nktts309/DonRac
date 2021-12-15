using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrapplingHook : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject hook;
    private BoxCollider2D bc2d;
    private float currentSize, newSize;
    Tween tm;
    void Start()
    {
        hook = GetComponent<GameObject>();
        bc2d = GetComponent<BoxCollider2D>();
        currentSize = 1;
        newSize = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                HookAnimate();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void HookAnimate()
    {
        tm = bc2d.transform.DOScaleX(newSize, 1).SetEase(Ease.Linear).OnComplete(() => {
            if(tm != null)
            {
                tm.Kill();
            }
            bc2d.transform.DOScaleX(currentSize, 1).SetEase(Ease.Linear);
        });
    }
}
