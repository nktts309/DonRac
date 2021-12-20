using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadScene : MonoBehaviour
{
    public static LoadScene Instance;
    public GameObject QuitPanel;
    public void LoadNextScene(int index)
    {
        StartCoroutine(LoadLevel(index));       
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadHomeScreen()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.Instance.DeActivateCanvas();
    }
    IEnumerator LoadLevel (int index)
    {
        Time.timeScale = 1;
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        GameManager.Instance.ResetPref();
        GameManager.Instance.ActivateCanvas();
        while (!operation.isDone)
        {
            yield return null;
        }
    }
    public void LoadNext()
    {
        GameManager.Instance.LoadCollectTrash();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowPanel()
    {
        QuitPanel.SetActive(true);
    }
    public void HidePanel()
    {
        QuitPanel.SetActive(false);
    }
    
}
