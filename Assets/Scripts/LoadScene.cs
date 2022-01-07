using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class LoadScene : MonoBehaviour
{
    public static LoadScene Instance;
    public GameObject QuitPanel;
    public GameObject ScorePanel;
    public GameObject wardrobe;
    Tween tween;
    public void LoadNextScene(int index)
    {
        StartCoroutine(LoadLevel(index));       
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        GameManager.Instance.ActivateCanvas();
        GameManager.Instance.ResetPref();
    }
    public void LoadHomeScreen()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.Instance.DeActivateCanvas();
        Time.timeScale = 1;
    }
    IEnumerator LoadLevel (int index)
    {
        Time.timeScale = 1;
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        GameManager.Instance.ResetPref();
        GameManager.Instance.ResetText();
        GameManager.Instance.ResetScore();
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void ShowPanel()
    {
        QuitPanel.SetActive(true);
    }
    public void HidePanel()
    {
        QuitPanel.SetActive(false);
    }
    public void ShowScore()
    {
        ScorePanel.SetActive(true);
    }
    public void HideScore()
    {
        ScorePanel.SetActive(false);
    }
    public void ShowWardrobe()
    {
        wardrobe.SetActive(true);
    }
    public void HideWardrobe()
    {
        tween = DOVirtual.DelayedCall(0.5f,() => wardrobe.SetActive(false));
        if(tween!= null)
        {
            tween.Kill();
        }
        LoadHomeScreen();
    }
}
