using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public static string coin = "coin";
    private static DataCharUnlock dataCharUnlock;
    public static int Coin
    {
        get => PlayerPrefs.GetInt(coin);
        set => PlayerPrefs.SetInt(coin, value);
    }
    //
    public static void UnlockChar(int id)
    {
        dataCharUnlock.UnlockChar(id);
    }
    public static bool OwnedChar(int id_)
    {
       return dataCharUnlock.OwnedChar(id_);
    }
    public static void LoadData()
    {
        var tData = PlayerPrefs.GetString("CD", string.Empty);
        dataCharUnlock = string.IsNullOrEmpty(tData) ? new DataCharUnlock() : JsonUtility.FromJson<DataCharUnlock>(tData);
         //Debug.Log(JsonUtility.ToJson(dataCharUnlock));

    }
    public static void SaveData()
    {
        Debug.Log(JsonUtility.ToJson(dataCharUnlock));
        PlayerPrefs.SetString("CD", JsonUtility.ToJson(dataCharUnlock));
    }
}

