using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TrashGrabbing : MonoBehaviour
{
    bool  isRed = false, isGreen = false, isYellow = false;
    GameObject TrashCan, TrashCan1, TrashCan2;
    [SerializeField] private int idTrash;
    public List<Transform> id;

    public int IdTrash { get => idTrash; set => idTrash = value; }

    // Start is called before the first frame update
    void Start()
    {
        TrashCan = GameObject.Find("Red");
        TrashCan1 = GameObject.Find("Green");
        TrashCan2 = GameObject.Find("Yellow");
    }  
    void DestroyTrash()
    {
        Destroy(gameObject);
    }
    public void OnMouseDown()
    {
        //GameManager.Instance.OnCollectTrash(this);
        if (gameObject.tag == "trash0")
        {
            GameManager.Instance.Addredtrash();
            isRed = true;
        }
        else if (gameObject.tag == "trash1")
        {
            GameManager.Instance.Addgreentrash();
            isGreen = true;
        }
        else if (gameObject.tag == "trash2")
        {
            GameManager.Instance.Addyellowtrash();
            isYellow = true;
        }
        else
        {
            isRed = false; isGreen = false; isYellow = false;
        }
        Cautch();
    }
    void Cautch()
    {
        var posTrashBin = isRed ? TrashCan : isGreen ? TrashCan1 : TrashCan2;
        transform.DOMove(posTrashBin.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() => {
            transform.DOScale(1.5f, 0.1f).OnComplete(() =>
            {
                transform.DOScale(0, 0.1f).OnComplete(() =>
                {
                    SpawnTrash.Instance.GenerateTrash(this.gameObject);
                });
            });
            //DOVirtual.DelayedCall(5f, () => {
                //DestroyTrash();
            //});
        });

    }
}
