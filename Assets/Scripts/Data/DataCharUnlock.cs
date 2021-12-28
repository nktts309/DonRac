using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataCharUnlock
{
    [SerializeField] private List<int> listCharUnlock= null;
    [SerializeField] private int currentChar = 0;
    public DataCharUnlock()
    {
        currentChar = 0;
        listCharUnlock = new List<int> { currentChar };
    }
    public void UnlockChar(int id_)
    {
        if (!listCharUnlock.Contains(id_))
        {
            listCharUnlock.Add(id_);
            PlayerData.SaveData();
        }
    }
    public bool OwnedChar(int id_)
    {
        return listCharUnlock.Contains(id_);
    }
}
