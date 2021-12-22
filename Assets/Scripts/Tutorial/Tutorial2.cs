using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2 : MonoBehaviour
{
    Rigidbody2D rig;
    [SerializeField] private GameObject focus;
    [SerializeField] private GameObject pointer;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rig.tag == "trash0")
        {
            if (collision.tag == "RTC")
            {
                focus.SetActive(false);
                Destroy(pointer);
            }
        }
    }
}
