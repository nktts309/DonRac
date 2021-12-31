using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDSystem : UIPanels<HUDSystem>
{
    [SerializeField] private Transform transLevel;
    private void Awake()
    {
    }
    private static bool isLock = false;
    public static bool IsLock
    {
        get => isLock;
        set => isLock = value;
    }
    public Transform TransLevel { get => transLevel; set => transLevel = value; }

    private void Start()
    {
        
        
    }
}
