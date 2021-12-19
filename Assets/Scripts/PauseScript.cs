using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPausing = false;
    // Start is called before the first frame update
    void Start()
    {
        if (isPausing)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        isPausing = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPausing = false;
    }
}
