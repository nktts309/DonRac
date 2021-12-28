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
            if (GameManager.Instance.Score == PlayerPrefs.GetInt("TaiChe"))
            {
                spriteRenderer.sprite = newSprite;
            }
        }
        if (gameObject.CompareTag("trash1"))
        {
            if (GameManager.Instance.Score1 == PlayerPrefs.GetInt("HuuCo"))
            {
                spriteRenderer.sprite = newSprite;
            }
        }
        if (gameObject.CompareTag("trash2"))
        {
            if (GameManager.Instance.Score2 == PlayerPrefs.GetInt("VoCo"))
            {
                spriteRenderer.sprite = newSprite;
            }
        }
    }
}
