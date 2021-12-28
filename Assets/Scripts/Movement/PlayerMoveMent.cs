using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerMoveMent : MonoBehaviour
{
    Vector3 pos;
    Vector3 scale, revscale;
    int index;
    //[SerializeField] public List<int> scoreList;

    public Text soRac, soRac1, soRac2;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        index = GameManager.Instance.IdSprite;
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        if(index == 0)
        {
            scale = new Vector3(0.75f, 0.75f);
            revscale = new Vector3(-0.75f, 0.75f);
        }
        if(index == 2|| index == 1)
        {
            scale = new Vector3(0.6f, 0.6f);
            revscale = new Vector3(-0.6f, 0.6f);
        }
    }

    // Update is called once per frame
    private void PlayerMove()
    {       
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                pos = Camera.main.ScreenToWorldPoint(touch.position);
                pos.z = 0;
                transform.DOMoveX(pos.x, 1.5f).SetEase(Ease.Linear);
                if (pos.x < transform.position.x)
                {
                    transform.localScale = revscale;
                }
                else
                {
                    transform.localScale = scale;
                }
            }
        }       
    }
    private void Update()
    {
        PlayerMove();
    }
}
