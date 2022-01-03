using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class FishMovement : MonoBehaviour
{
    Vector2 startPos, endPos, jumpPos;
    Vector3 scale, revScale;
    public Transform player;
    Tween tweenMove=null;
    int sceneIndex;
    [SerializeField] private float jumpHeight = 1f;
    public int id;
        
    // Start is called before the first frame update
    void Start()
    {
        scale = new Vector3(1.5f, 1.5f);
        revScale = new Vector3(-1.5f, 1.5f);
        startPos = new Vector2(-8.0f, -3.5f);
        endPos = new Vector2(8.5f, -3.5f);
        jumpPos = new Vector2(0, -3.5f);
        if(id == 1)
        {
            FishJump();
        }
        if (id == 2)
        {
            AnimateRabbit();
        }
        if(id == 0)
        {
            AnimFish();
        }

    }
    private void OnMouseDown()
    {
        if (id == 1)
        {
            if (tweenMove != null) tweenMove.Kill();
            tweenMove = transform.DOShakePosition(1f, 1.5f, 2, 9).OnComplete(() => {
                transform.position = new Vector3(transform.position.x, startPos.y);
                player.transform.DOShakePosition(0.5f, 1, 2, 10);
                player.transform.DOShakePosition(0.5f, 1, 2, 10);
                if (transform.position.x > 0f && transform.localScale == revScale)
                {
                    transform.localScale = revScale;
                    tweenMove = transform.DOMoveX(startPos.x, 4.5f).SetEase(Ease.Linear).SetSpeedBased(true).OnComplete(() =>
                    {
                        FishJump();
                    });
                }
                else if (transform.position.x > 0 && transform.localScale == scale)
                {
                    tweenMove = transform.DOMoveX(endPos.x, 4.5f).SetEase(Ease.Linear).SetSpeedBased(true).OnComplete(() =>
                    {
                        transform.localScale = revScale;
                        tweenMove = transform.DOMoveX(startPos.x, 4.5f).SetEase(Ease.Linear).SetSpeedBased(true).OnComplete(() =>
                        {
                            FishJump();
                        });
                    });
                }
                else FishJump();
            });
        } 
        if (id == 0)
        {
            if (tweenMove != null) tweenMove.Kill();
            transform.DOShakePosition(1f, 1.5f, 2, 9).OnComplete(() => {
                transform.position = new Vector3(transform.position.x, startPos.y);
                player.transform.DOShakePosition(0.5f, 1, 2, 10);
                if (transform.position.x > 0 && transform.localScale == scale)
                {
                    transform.localScale = revScale;
                    transform.DOMoveX(startPos.x, 3f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        AnimFish();
                    });
                }
                else
                {
                    AnimFish();
                }
            });
        }
        if (id == 2)
        {
            if (tweenMove != null) tweenMove.Kill();
            transform.DOShakePosition(1f, 1.5f, 2, 9).OnComplete(() => {
                transform.position = new Vector3(transform.position.x, startPos.y);
                player.transform.DOShakePosition(0.5f, 1, 2, 10);
                if (transform.position.x > 0 && transform.localScale == revScale)
                {
                    tweenMove = transform.DOJump(startPos, jumpHeight, 5, 3.5f).SetEase(Ease.Linear).SetSpeedBased(true).OnComplete(() =>
                      {
                          AnimateRabbit();
                      });
                }
                else if (transform.position.x > 1.5f && transform.localScale == scale)
                {
                    tweenMove = transform.DOJump(endPos, jumpHeight, 2, 1.5f).SetEase(Ease.Linear).SetSpeedBased(true).OnComplete(() =>
                    {
                        transform.localScale = revScale;
                        tweenMove = transform.DOJump(startPos, jumpHeight, 5, 3.5f).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(() => {
                            AnimateRabbit();
                        });
                    });
                }
                else AnimateRabbit();
            });
        }
    }
    private void AnimFish()
    {
        transform.localScale = scale;
        tweenMove = transform.DOMoveX(startPos.x + 15f, 5f).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(()=> {
        if (tweenMove != null) tweenMove.Kill();
            transform.localScale = revScale;
            tweenMove = transform.DOMoveX(startPos.x, 5f).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(() => {
                AnimFish();
            });
        });
    }
    void AnimateRabbit()
    {
        transform.localScale = scale;
        tweenMove = transform.DOJump(endPos, jumpHeight,5,4f).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(() => {
            if (tweenMove != null) tweenMove.Kill();
            transform.localScale = revScale;
            tweenMove = transform.DOJump(startPos, jumpHeight,5,4f).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(() => {             
                AnimateRabbit();
            });
        });
    }
    void FishJump()
    {
        transform.localScale = scale;
        if (tweenMove != null) tweenMove.Kill();
        tweenMove = transform.DOMoveX(startPos.x + 5f, 4.5f).SetEase(Ease.Linear).SetSpeedBased(true).OnComplete(() =>
            {
                tweenMove = transform.DOJump(jumpPos, jumpHeight, 1, 0.75f).SetEase(Ease.Linear).OnComplete(() =>
                   {
                       if (tweenMove != null) tweenMove.Kill();
                       tweenMove = transform.DOMoveX(startPos.x + 15f, 4.5f).SetEase(Ease.Linear).SetSpeedBased(true).OnComplete(() =>
                       {
                           transform.localScale = revScale;
                           tweenMove = transform.DOMoveX(startPos.x + 10, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
                           {
                               tweenMove = transform.DOJump(jumpPos, jumpHeight, 1, 0.75f).SetEase(Ease.Linear).OnComplete(() =>
                               {
                                   if (tweenMove != null) tweenMove.Kill();
                                   tweenMove = transform.DOMoveX(startPos.x, 4.5f).SetEase(Ease.Linear).SetSpeedBased(true).OnComplete(() =>
                                   {
                                       FishJump();
                                   });
                               });

                           });
                       });

                   });
            });       
    }
}
