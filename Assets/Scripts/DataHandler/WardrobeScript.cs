using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using EPOOutline;

public class WardrobeScript : MonoBehaviour
{
    [SerializeField] private int idSprite;
    [SerializeField] private GameObject effect;
    //bool isChoosing = false;
    private Outlinable outline;
    private SpriteRenderer sprite;
    private BoxCollider2D collider2D;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outlinable>();
        sprite = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();
        LockedSprite();
        if (idSprite != GameManager.Instance.IdSprite)
        {
            outline.enabled = false;
        }
        else
        {
            outline.enabled = true;
        }
    }
    private void Update()
    {
        if(Time.frameCount % 30 == 0)
        {
            if (idSprite != GameManager.Instance.IdSprite)
            {
                outline.enabled = false;
            }
            else
            {
                outline.enabled = true;
            }
        }
    }
    private void OnMouseDown()
    {
        GameManager.Instance.SwapSprite(idSprite);
        effect.SetActive(true);
        DOVirtual.DelayedCall(0.5f, () => effect.SetActive(false));
    }
    // Update is called once per frame
    void LockedSprite()
    {                
        if (PlayerPrefs.GetInt("PlayScene") + PlayerPrefs.GetInt("CatHighScore1") >= 420)
        {
            PlayerData.UnlockChar(1);
        }
        if (PlayerPrefs.GetInt("PlayScene1") + PlayerPrefs.GetInt("CatHighScore2") >= 690 )
        {
            PlayerData.UnlockChar(2);            
        }
        if (PlayerData.OwnedChar(idSprite))
        {
            sprite.color = new Color(255, 255, 255);
            collider2D.enabled = true;
        }
        else
        {
            sprite.color = new Color(0, 0, 0);
            collider2D.enabled = false;
        }       
    }
}
