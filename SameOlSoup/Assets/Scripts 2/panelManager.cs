using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelManager : MonoBehaviour
{
    [SerializeField]
    private screenManager manager;

    [SerializeField]
    private GameObject seller;
    [SerializeField]
    private GameObject maker;
    [SerializeField]
    private GameObject info;

    void Start()
    {
        seller.SetActive(false);
        maker.SetActive(false);
        info.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.getMaterial() > 0)
        {
            info.SetActive(true);
        }
        if (manager.getMaterial() > 4) {
            maker.SetActive(true);
        }
        if (manager.getSoup() > 3) {
            seller.SetActive(true);
        }
    }
}
