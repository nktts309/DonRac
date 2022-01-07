using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SCN;

public class EventListenerTest : MonoBehaviour
{
    int redTrash = 0;
    int greenTrash = 0;
    int yellowTrash = 0;
    public Text redText;
    public Text greenText;
    public Text yellowText;

    public static EventListenerTest Instance;
    public int RedTrash { get => redTrash; set => redTrash = value; }
    public int GreenTrash { get => greenTrash; set => greenTrash = value; }
    public int YellowTrash { get => yellowTrash; set => yellowTrash = value; }


    // Start is called before the first frame update
    void Start()
    {
        //EventDispatcher.Instance.RegisterListener<EventKey.OnCollectRedTrash>(OnCollectRedTrash);
        //EventDispatcher.Instance.RegisterListener<EventKey.OnCollectGreenTrash>(OnCollectGreenTrash);
        //EventDispatcher.Instance.RegisterListener<EventKey.OnCollectYellowTrash>(OnCollectYellowTrash);
    }
    // Update is called once per frame
    void OnCollectRedTrash()
    {
        RedTrash++;
        redText.text = "" + RedTrash;
    } 
    void OnCollectGreenTrash()
    {
        GreenTrash++;
        greenText.text = "" + GreenTrash;
    } 
    void OnCollectYellowTrash()
    {
        YellowTrash++;
        yellowText.text = "" + YellowTrash;
    }
    public void OnCategoriseRedTrash()
    {
        RedTrash--;
    }
    public void OnCategoriseGreenTrash()
    {
        GreenTrash--;
    } 
    public void OnCategoriseYellowTrash()
    {
        YellowTrash--;
    }
}
