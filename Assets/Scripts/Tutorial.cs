using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    Vector2 startPos, movePos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        movePos = new Vector2(1.5f, -2);
        PointAnimate();
        Time.timeScale = 0;
    }
    void PointAnimate()
    {
        transform.DOMove(movePos, 0.75f).SetEase(Ease.Linear).OnComplete(() => {
            transform.DOMove(startPos, 0.75f).SetEase(Ease.Linear).OnComplete(()=> {
                PointAnimate();
            });
        });
    }
    private void OnMouseDown()
    {
        if (gameObject.tag == "trash1")
        {
            this.transform.localScale = new Vector3(0,0);
        }
    }
}
