using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FishMovement : MonoBehaviour
{
    Vector2 startPos;
    bool isTriggered = false;
    public Vector2 distance = new Vector2(15, 0);
    public GameObject Player;
    Tween tweenMove=null;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector2(-8.0f,-3.6f);
        AnimFish();
    }
    

    private void OnMouseDown()
    {
        if (gameObject.tag == "Fish")
        {
            if (tweenMove != null) tweenMove.Kill();
            transform.DOShakePosition(1f, 1.5f, 2,9).OnComplete(()=> {
                transform.position = new Vector3(transform.position.x, startPos.y); 
                AnimFish();
            });
            Debug.Log("Chạm vào cá");
            isTriggered = true;
           // Invoke("DisableTrigger", 2);
        }
    }
    //void DisableTrigger()
    //{
    //    isTriggered = false;
    //}
    private void AnimFish()
    {
        transform.localScale = new Vector3(1.5f, 1.5f);
        tweenMove = transform.DOMoveX(startPos.x + 15f, 3f).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(()=> {
        if (tweenMove != null) tweenMove.Kill();
            transform.localScale = new Vector3(-1.5f, 1.5f);
            tweenMove = transform.DOMoveX(startPos.x, 3f).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(() => {
                AnimFish();
            });
        });
            }
}
