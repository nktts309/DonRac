using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class FishMovement : MonoBehaviour
{
    Vector2 startPos;
    public GameObject Player;
    Tween tweenMove=null;
    int sceneIndex;
    Vector2 endPos;
        
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector2(-8.0f, -3.6f);
        endPos = new Vector2(8.5f, -3.5f);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex == 3)
        {
            AnimFish();
        }
        if (sceneIndex == 5)
        {
            AnimateRabbit();
        }

    }
    private void OnMouseDown()
    {
        if (sceneIndex == 3)
        {
            if (tweenMove != null) tweenMove.Kill();
            transform.DOShakePosition(1f, 1.5f, 2, 9).OnComplete(() => {
                transform.position = new Vector3(transform.position.x, startPos.y);
                AnimFish();
            });
        }
        if (sceneIndex == 5)
        {
            if (tweenMove != null) tweenMove.Kill();
            transform.DOShakePosition(1f, 1.5f, 2, 9).OnComplete(() => {
                transform.position = new Vector3(transform.position.x, startPos.y);
                AnimateRabbit();
            });
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
    void AnimateRabbit()
    {
        transform.localScale = new Vector3(1.5f, 1.5f);
        tweenMove = transform.DOJump(endPos, 1f,6,6).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(() => {
            if (tweenMove != null) tweenMove.Kill();
            transform.localScale = new Vector3(-1.5f, 1.5f);
            tweenMove = transform.DOJump(startPos, 1f,6,6).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(() => {
                AnimateRabbit();
            });
        });
    }
}
