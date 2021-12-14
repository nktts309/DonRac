using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("trash0");
        GameObject[] go1 = GameObject.FindGameObjectsWithTag("trash1");
        GameObject[] go2 = GameObject.FindGameObjectsWithTag("trash2");
        if (go.Length == 0 && go1.Length == 0 && go2.Length == 0)
        {
            panel.SetActive(true);
        }
    }
    private void OnMouseOver()
    {
        
    }
}
