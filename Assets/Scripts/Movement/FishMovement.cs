using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class FishMovement : MonoBehaviour
{
    Vector2 startPos, endPos, jumpPos;
    public Transform player;
    Tween tweenMove=null;
    int sceneIndex;
    [SerializeField] private float jumpHeight = 2.5f;
        
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector2(-8.0f, -3.5f);
        endPos = new Vector2(8.5f, -3.5f);
        jumpPos = new Vector2(0, -3.5f);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex == 3)
        {
            FishJump();
        }
        if (sceneIndex == 5)
        {
            AnimateRabbit();
        }

    }
    private void OnMouseDown()
    {
        if (sceneIndex == 3 || sceneIndex == 1)
        {
            if (tweenMove != null) tweenMove.Kill();
            transform.DOShakePosition(1f, 1.5f, 2, 9).OnComplete(() => {
                transform.position = new Vector3(transform.position.x, startPos.y);
                player.transform.DOShakePosition(0.5f, 1, 2, 10);
                    AnimFish();
            });
        }
        if (sceneIndex == 5)
        {
            if (tweenMove != null) tweenMove.Kill();
            transform.DOShakePosition(1f, 1.5f, 2, 9).OnComplete(() => {
                transform.position = new Vector3(transform.position.x, startPos.y);
                player.transform.DOShakePosition(0.5f, 1, 2, 10);
                    AnimateRabbit();
            });
        }
    }
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
        tweenMove = transform.DOJump(endPos, jumpHeight,6,5).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(() => {
            if (tweenMove != null) tweenMove.Kill();
            transform.localScale = new Vector3(-1.5f, 1.5f);
            tweenMove = transform.DOJump(startPos, jumpHeight,6,5).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(() => {
                AnimateRabbit();
            });
        });
    }
    void FishJump()
    {
        transform.localScale = new Vector3(1.5f, 1.5f);
        tweenMove = transform.DOMoveX(startPos.x + 5f, 1.5f).SetEase(Ease.Linear).OnComplete(() => {
            {
                tweenMove = transform.DOJump(jumpPos,jumpHeight,1,0.75f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    if (tweenMove != null) tweenMove.Kill();
                    tweenMove = transform.DOMoveX(startPos.x + 15f, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        transform.localScale = new Vector3(-1.5f, 1.5f);
                        tweenMove = transform.DOMoveX(startPos.x + 10, 1.5f).SetEase(Ease.Linear).OnComplete(() => {
                            tweenMove = transform.DOJump(jumpPos, jumpHeight, 1, 0.75f).SetEase(Ease.Linear).OnComplete(() =>
                            {
                                if (tweenMove != null) tweenMove.Kill();
                                tweenMove = transform.DOMoveX(startPos.x, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
                                {
                                    FishJump();
                                });
                            });

                        });
                    });

                });
            }                      
        });        
    }
}
