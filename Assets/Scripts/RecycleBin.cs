using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using EPOOutline;

public class RecycleBin : MonoBehaviour
{
    [SerializeField] private GameObject bubbleChat;
    [SerializeField] Text incorrectChatText;
    [SerializeField] private int id;
    [SerializeField] private GameObject confeti;
    private Outlinable outlineTC;

    private bool isNeeded = false;
    public int Id { get => id; set => id = value; }
    public bool IsNeeded { get => isNeeded; set => isNeeded = value; }
    private void Start()
    {
        outlineTC = GetComponent<Outlinable>();
        outlineTC.enabled = false;
        bubbleChat.transform.position = new Vector3(gameObject.transform.position.x - 2f, gameObject.transform.position.y+ 1f);
    }
    // Script cho thùng rác
    public void ShowPopupNeeded()
    {
        // show câu cho tôi ăn rác ở mỗi thùng
        IsNeeded = true;
        outlineTC.enabled = true;
        bubbleChat.transform.DOScale(58f, 0.5f).OnComplete(() => {
            bubbleChat.transform.DOScale(0, 0.5f).SetDelay(1f).OnComplete(() => {
                incorrectChatText.text = "";
                IsNeeded = false;
                outlineTC.enabled = false;
            });
        });
        incorrectChatText.text = "Please feed me too!";
        bubbleChat.transform.position = new Vector3(transform.position.x - 1.65f, transform.position.y + 1.5f);
    }
    public void PlayConfeti()
    {
        confeti.SetActive(true);
        DOVirtual.DelayedCall(0.5f, () => confeti.SetActive(false));
    }
}
