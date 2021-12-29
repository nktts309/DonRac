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
   // private SpriteLibraryAsset LibraryAsset => library.spriteLibraryAsset;
    private void Start()
    {        
        charData = ResourceData.Instance.CharacterData;
        player = GetComponent<Transform>();
        //library = GetComponent<SpriteLibrary>();
        //resolver = GetComponent<SpriteResolver>();
        index = GameManager.Instance.IdSprite;
        if(index == 1 || index == 2)
        {
            player.transform.localScale = new Vector3(0.6f, 0.6f);
        }
        ChangeSprite();
    }
    // Start is called before the first frame update
   void ChangeSprite()
    {
        var spriteChar = charData.Datas[index].sprites;
        spriteRenderer.sprite = spriteChar;
    }  
}
