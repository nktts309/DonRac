using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    private Transform template;
    private Transform container;
    private GameObject board;
    private float spacing;
    // Start is called before the first frame update
    void Awake()
    {
        board = GameObject.Find("HighScore");
        spacing = -100f;
        container = transform.Find("ScoreContainer");
        template = container.Find("ScoreTemplate");
        template.gameObject.SetActive(false);
        for (int i=0; i <3 ; i++)
        {
            Transform transform = Instantiate(template,container);
            RectTransform rectTransform = transform.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, spacing * i);
            template.gameObject.SetActive(true);

            int rank = i;
            string levelIndex = rank.ToString();
            string levelName = "" ;       
            switch (rank)
            {
                case 1: levelName = "PlayScene"; break;
                case 2: levelName ="PlayScene1"; break;
            }
            int score = PlayerPrefs.GetInt(levelName);         
            transform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
            transform.Find("LevelText").GetComponent<Text>().text = levelIndex;           
        }
    }
}
