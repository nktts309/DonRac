using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("trash0"))
        {
            if (PlayerPrefs.GetInt("redTrash") == PlayerPrefs.GetInt("TaiChe"))
            {
                spriteRenderer.sprite = newSprite;
            }
        }
        if (gameObject.CompareTag("trash1"))
        {
            if (PlayerPrefs.GetInt("greenTrash") == PlayerPrefs.GetInt("HuuCo"))
            {
                spriteRenderer.sprite = newSprite;
            }
        }
        if (gameObject.CompareTag("trash2"))
        {
            if (PlayerPrefs.GetInt("yellowTrash") == PlayerPrefs.GetInt("VoCo"))
            {
                spriteRenderer.sprite = newSprite;
                gameObject.transform.localScale = new Vector2(1,1);
            }
        }
    }
}
