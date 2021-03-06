using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using SCN;
using System;
public class PlayerMoveMent : MonoBehaviour
{
    Vector3 scale, revscale;
    int index;
    Tween tween;

    private List<Action> listAction = new List<Action>();
    private List<Vector3> listPos = new List<Vector3>();
    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        EventDispatcher.Instance.RegisterListener<EventKey.OnCollect>(MovePlayer);
        index = GameManager.Instance.IdSprite;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        if (index == 0)
        {
            scale = new Vector3(0.75f, 0.75f);
            revscale = new Vector3(-0.75f, 0.75f);
        }
        if (index == 2 || index == 1)
        {
            scale = new Vector3(0.6f, 0.6f);
            revscale = new Vector3(-0.6f, 0.6f);
        }
    }
    private void OnDestroy()
    {
        EventDispatcher.Instance.RemoveListener<EventKey.OnCollect>(MovePlayer);
    }
    private void MovePlayer(EventKey.OnCollect data)
    {
        listAction.Add(data.action);
        listPos.Add(data.posMove);
        if (!isMoving)
        {
            CheckAndAction();
        }
    }
    private void CheckAndAction()
    {
        if (listAction.Count <= 0 || isMoving) return;
        isMoving = true;
        transform.localScale = transform.position.x < listPos[0].x ? scale : revscale;
        tween = transform.DOMoveX(listPos[0].x, 9f).SetEase(Ease.Linear).SetSpeedBased(true).OnComplete(()=> {
            var ActionCallback = listAction[0];
            listAction.RemoveAt(0);
            listPos.RemoveAt(0);
            ActionCallback.Invoke();
            isMoving = false;
            CheckAndAction();
        });
    }
}
