using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnTrash : MonoBehaviour
{

    public static SpawnTrash Instance;
    public GameObject nextLevelPanel;
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private List<GameObject> currentList;
    [SerializeField] private TrashCount[] trashCounts;
    [SerializeField] private GameObject pinPoint;
    // Start is called before the first frame update
    [System.Serializable]
    public struct TrashCount
    {
        public string trashName;
        public int countTrash;
    }
    void Start()
    {
        nextLevelPanel.transform.DOScale(0, 0);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void AddTrash()
    {
        int index = Random.Range(0, trashCounts.Length);
        while(trashCounts[index].countTrash == 0)
        {
            index = Random.Range(0, trashCounts.Length);
        }
        trashCounts[index].countTrash -= 1;
        GameObject newTrash = (GameObject)Instantiate(prefab[index]);
        currentList.Add(newTrash);
       
        newTrash.transform.position = new Vector2(Random.Range(-8, 8), Random.Range(-3, -4.5f));
    }
    public void GenerateTrash(GameObject trash)
    {
        currentList.Remove(trash);
        Destroy(trash);       
        if (currentList.Count < 5 && (trashCounts[0].countTrash != 0 | trashCounts[1].countTrash != 0 | trashCounts[2].countTrash != 0))
        {
                AddTrash();
        }
        else if(currentList.Count == 0 && trashCounts[0].countTrash == 0 && trashCounts[1].countTrash == 0 && trashCounts[2].countTrash == 0)
        {
            nextLevelPanel.transform.DOScale(0.7f, 1f);
            Invoke("LoadLevel", 3.0f);
        }
    }
    void LoadLevel()
    {
        GameManager.Instance.LoadNextScene();
    }
}

