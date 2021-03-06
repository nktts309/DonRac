using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using SCN;
public class TrashGrabbing : MonoBehaviour
{
    bool isRed = false, isGreen = false;
    GameObject TrashCan, TrashCan1, TrashCan2;
    [SerializeField] private int idTrash;
    bool isGrabbed = false;
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
        if (!isGrabbed)
        {
            if (gameObject.CompareTag("trash0"))
            {
                GameManager.Instance.Addredtrash();
                GameManager.Instance.AddScore();
                isRed = true;
            }
            else if (gameObject.CompareTag("trash1"))
            {
                GameManager.Instance.Addgreentrash();
                GameManager.Instance.AddScore();
                isGreen = true;
            }
            else if (gameObject.CompareTag("trash2"))
            {
                GameManager.Instance.Addyellowtrash();
                GameManager.Instance.AddScore();
            }
            if (gameObject.name == "HuuCo(Clone)")
            {
                GameManager.Instance.AddOrganic();
            }
            if (gameObject.name == "VoCo(Clone)")
            {
                GameManager.Instance.AddInOrganic();
            }
            if (gameObject.name == "TaiChe(Clone)")
            {
                GameManager.Instance.AddRecycle();
            }
            else
            {
                isRed = false; isGreen = false;
            }          
            isGrabbed = true;
            EventDispatcher.Instance.Dispatch(new EventKey.OnCollect { posMove = transform.position, action = Cautch});
        }
    }
    void Cautch()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            var posTrashBin = isRed ? TrashCan : isGreen ? TrashCan1 : TrashCan2;
            transform.DOMove(posTrashBin.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.DOScale(1.5f, 0.1f).OnComplete(() =>
                {
                    transform.DOScale(0, 0.1f).OnComplete(() =>
                    {
                    });
                });
            });
        }
        else
        {
            var posTrashBin = isRed ? TrashCan : isGreen ? TrashCan1 : TrashCan2;
            transform.DOMove(posTrashBin.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.DOScale(1.5f, 0.1f).OnComplete(() =>
                {
                    transform.DOScale(0, 0.1f).OnComplete(() =>
                    {
                        SpawnTrash.Instance.GenerateTrash(this.gameObject);
                    });
                });
            });
        }
    }
}
