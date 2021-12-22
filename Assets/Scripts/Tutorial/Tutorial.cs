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
        movePos = new Vector2(0.25f, 3);
        PointAnimate();
    }
    void PointAnimate()
    {
        transform.DOMove(movePos, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOLookAt(movePos, 1).OnComplete(() =>
            {
                PointAnimate();
                transform.position = startPos;
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
