using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tutorial3 : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelPanel;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        nextLevelPanel.transform.DOScale(0,0);      
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("redTrash") + PlayerPrefs.GetInt("greenTrash") + PlayerPrefs.GetInt("yellowTrash");
        if (score == 6)
        {
            nextLevelPanel.transform.DOScale(1, 1) ;
            Invoke("LoadLevel", 3);
        }
    }
    void LoadLevel()
    {
        GameManager.Instance.LoadNextScene();
    }
}
