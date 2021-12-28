using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterData", menuName = "DataSO/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public List<Data> Datas;
    [System.Serializable] public struct Data
    {
        public string name;
        public Sprite sprites;
        public int cost;
    }


}
