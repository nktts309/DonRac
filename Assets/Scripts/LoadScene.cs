using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadScene : MonoBehaviour
{
    public static LoadScene Instance;
    public GameObject NextLevel;
    public Slider slider;
    public Text percentage;


    public void LoadNextScene(int index)
    {
        StartCoroutine(LoadLevel(index));
        
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("PlayScene");
    }
    IEnumerator LoadLevel (int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        NextLevel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress /0.9f);
            slider.value = progress;
            percentage.text = progress * 100 + "%";
            yield return null;
        }
    }
    
}