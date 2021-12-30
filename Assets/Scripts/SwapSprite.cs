using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;


public class SwapSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Transform player;
    private int index;
    private CharacterData charData;
    private void Start()
    {        
        charData = ResourceData.Instance.CharacterData;
        player = GetComponent<Transform>();
        index = GameManager.Instance.IdSprite;
        if(index == 1 || index == 2)
        {
            player.transform.localScale = new Vector3(0.6f, 0.6f);
        }
        ChangeSprite();
    }
   void ChangeSprite()
    {
        var spriteChar = charData.Datas[index].sprites;
        spriteRenderer.sprite = spriteChar;
    }  
}
