using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamFocus : MonoBehaviour
{
    private int touchCount = 0;
    public GameObject focus;
    [SerializeField ]private SpriteRenderer[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        touchCount++;        
        for(int i = 0 ; i < touchCount +1; i++)
        {
            ShowSprite(i);
            if(i > 0)
            {
                HideSprite(i - 1);
            }
            if (i == 5)
            {
                break;
            }            
        }
        if(touchCount == 6)
        {
            focus.SetActive(false);
            touchCount = 0;
            Time.timeScale = 1;
        }
        //if(touchCount == 1)
        //{
        //    ShowSprite(0);
        //} 
        //if(touchCount == 2)
        //{
        //    ShowSprite(1);
        //    HideSprite(0);
        //}
        //if (touchCount == 3)
        //{
        //    ShowSprite(2);
        //    HideSprite(1);
        //}
        //if (touchCount == 4)
        //{
        //    ShowSprite(3);
        //    HideSprite(2);
        //}
        //if (touchCount == 5)
        //{
        //    ShowSprite(4);
        //    HideSprite(3);
        //}
    }
    public void ShowSprite(int index)
    {
        sprites[index].sortingOrder = 4;
         
    }
    public void HideSprite(int index)
    {
        sprites[index].sortingOrder = 0;
    }
}
