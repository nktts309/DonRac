using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamFocus : MonoBehaviour
{
    private int touchCount = 0;
    public GameObject focus;
    [SerializeField] private int id;
    [SerializeField ]private SpriteRenderer[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if(id == 0)
        {
            HideSprite(0);
            ShowSprite(1);
        }      
        if(id == 1)
        {
            ShowSprite(2); ShowSprite(3); ShowSprite(4);
            HideSprite(1);
        }
        if(id == 2)
        {
            ShowSprite(5);
            HideSprite(2); HideSprite(3); HideSprite(4);
        }
        if(id == 3)
        {
            HideSprite(5);
            focus.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void ShowSprite(int index)
    {
        sprites[index].sortingOrder = 4;
         
    }
    public void HideSprite(int index)
    {
        sprites[index].sortingOrder = 0;
    }
    //void FocusSprite()
    //{
    //    touchCount++;
    //    for (int i = 0; i < touchCount + 1; i++)
    //    {
    //        ShowSprite(i);
    //        if (i > 0)
    //        {
    //            HideSprite(i - 1);
    //        }
    //        if (i == 2)
    //        {
    //            ShowSprite(2); ShowSprite(3); ShowSprite(4);
    //        }
    //        if (i == 3)
    //        {
    //            ShowSprite(5);
    //            HideSprite(2); HideSprite(3); HideSprite(4);
    //            break;
    //        }
    //    }
    //    if (touchCount == 4)
    //    {
    //        focus.SetActive(false);
    //        touchCount = 0;
    //        Time.timeScale = 1;
    //    }
    //}
}
