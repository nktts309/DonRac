using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float timeRemaining = 20;
    private bool timerIsRunning = false;
    public Text timeText;
    public GameObject nextLevelPanel;

    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                nextLevelPanel.transform.DOScale(0.7f, 1f);
                Invoke("LoadLevel", 3.0f);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void LoadLevel()
    {
        GameManager.Instance.LoadNextScene();
    }
}
