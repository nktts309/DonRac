using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    [SerializeField] private int totalScore;
    [SerializeField] private int scoreDiff;
    [SerializeField] private int scoreGot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetStar()
    {
        if(totalScore - scoreGot <= scoreDiff)
        {

        }
    }
}
