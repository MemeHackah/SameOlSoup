using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenManager : MonoBehaviour
{
    private int soupCount;
    [SerializeField]
    private int materialCount;
    private float moneyCount;

    private int manMaterials = 1;

    public string moneyText;
    public string soupText;
    public string materialText;

    private float timer;

    void Start()
    {
        soupCount = 0;
        materialCount = 0;
        moneyCount = 0f;
        timer = 30;
    }

    void Update()
    {
        materialText = "Materials: " + materialCount;
        soupText = "Soup: " + soupCount;
        moneyText = "Money: " + moneyCount;
    }

    public void addMaterial()
    {
        materialCount += manMaterials;
    }
}
