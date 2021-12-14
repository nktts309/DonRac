using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RecycleBin : MonoBehaviour
{
    [SerializeField] private GameObject bubbleChat;
    [SerializeField] Text incorrectChatText;
    [SerializeField] private int id;
    // Script cho tung thùng rác
    public void ShowPopup()
    {
        // show câu cho tôi ăn rác ở mỗi thùng
        bubbleChat.transform.DOScale(58f, 0.5f).OnComplete(() => {
            bubbleChat.transform.DOScale(0, 1).SetDelay(2.0f).OnComplete(() => {
                incorrectChatText.text = "";
            });
        });
        incorrectChatText.text = "Please feed me too!";
        bubbleChat.transform.position = new Vector3(transform.position.x - 1.65f, transform.position.y + 1.5f);
    }
}
