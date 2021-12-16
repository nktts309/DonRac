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
        button.transform.DOScale(1.2f, 1).OnComplete(() => {
            button.transform.DOScale(1, 1).OnComplete(()=> {
                ButtonAnimate();
            });
        });
    }
}
