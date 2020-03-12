using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoWindow : MonoBehaviour
{
    [SerializeField]
    private screenManager manager;
    private Text txt;

    void Update()
    {
        txt = transform.Find("Text").GetComponent<Text>();

        txt.text = manager.moneyText + "\n" + manager.soupText + "\n" + manager.materialText;
    }
}
