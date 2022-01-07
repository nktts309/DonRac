using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceData : MonoBehaviour
{
    public static ResourceData Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(this.gameObject);
        PlayerData.LoadData();
    }
    private CharacterData characterData = null;
    public CharacterData CharacterData
    {
        get
        {
            if (characterData==null)
            {
                characterData = Resources.Load<CharacterData>("CharacterData");
            }
            return characterData;
        }
    
    }
}
