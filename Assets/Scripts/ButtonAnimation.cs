using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonAnimation : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        ButtonAnimate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ButtonAnimate()
    {
        button.transform.DOScale(0.75f, 1).OnComplete(() => {
            button.transform.DOScale(0.6f, 1).OnComplete(()=> {
                ButtonAnimate();
            });
        });
    }
}
