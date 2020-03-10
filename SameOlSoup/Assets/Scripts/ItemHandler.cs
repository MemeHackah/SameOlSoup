using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemHandler : MonoBehaviour
{
    private int soupCount;
    private int materialCount;
    private float moneyCount;
    public string moneyText;
    public string soupText;
    public string materialText;
    public string humanText;
    public string karmaText;
    public float materialValue;
    public float soupValue;
    public float soupCost;
    private float soupsMade;
    public float karma;
    public float humans;
    public GameObject autoMat;
    public GameObject autoSeller;
    public GameObject autoSouper;
    public GameObject artifact;

    // Start is called before the first frame update
    void Start()
    {
        soupCount = 0;
        materialCount = 0;
        moneyCount = 0f;
        soupsMade = 0f;
        humans = 1000000000;
    }

    void Update()
    {
        if(soupsMade > 2)
        {
            Instantiate(artifact);
            artifact.GetComponent<ArtifactWindow>().manager = this.gameObject.GetComponent<ItemHandler>();
        }
        if (humans <= 1)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void changeValue(float value)
    {
        soupValue = value;
    }
    public int getSoup()
    {
        return soupCount;
    }
    public int getMaterial()
    {
        return materialCount;
    }

    public float getMoney()
    {
        return moneyCount;
    }

    public void addSoup()
    {
        if (materialCount >= materialValue)
        {
            soupCount += 1;
            soupsMade += 1;
            soupText = "Soup: " + soupCount;
            materialCount -= (int)materialValue;
            materialText = "Materials: " + materialCount;
        }
    }

    public void addSoup(int num)
    {
        soupCount += num;
        soupsMade += num;
        soupText = "Soup: " + soupCount;
    }

    public void addMaterials()
    {
        materialCount += 1;
        materialText = "Materials: " + materialCount;
    }

    public void addMaterials(float matCount)
    {
        materialCount += (int)matCount;
        materialText = "Materials: " + materialCount;
    }

    public void addMoney()
    {
        if (soupCount >= soupValue)
        {
            moneyCount += soupCost;
            moneyText = "Money: " + moneyCount;
            soupCount -= (int)soupValue;
            soupText = "Soup: " + soupCount;
        }
    }

    public void spendMoney(float money)
    {
        moneyCount -= money;
        moneyText = "Money: " + moneyCount;
    }

    public void autoMaterial(float matPerSec, float money, float soups)
    {
        if(moneyCount >= money)
        {
            Instantiate(autoMat);
            autoMat.GetComponent<AutoMatMaker>().soups = soups;
            autoMat.GetComponent<AutoMatMaker>().matPerSecond = matPerSec;
            autoMat.GetComponent<AutoMatMaker>().manager = this.gameObject.GetComponent<ItemHandler>();
            this.GetComponent<ShopWindow>().turnOff(1);
            spendMoney(money);
        }
        
    }

    public void autoSoup(float soupPerSec, float money)
    {
        if (moneyCount >= money)
        {
            Instantiate(autoSouper);
            autoSouper.GetComponent<AutoSoupMaker>().soupPerSecond = soupPerSec;
            autoSouper.GetComponent<AutoSoupMaker>().manager = this.gameObject.GetComponent<ItemHandler>();
            this.GetComponent<ShopWindow>().turnOff(2);
            spendMoney(money);
        }
    }

    public void autoSell(float sellPerSec, float money)
    {
        if (moneyCount >= money)
        {
            Instantiate(autoSeller);
            autoSeller.GetComponent<AutoSeller>().sellPerSecond = sellPerSec;
            autoSeller.GetComponent<AutoSeller>().manager = this.gameObject.GetComponent<ItemHandler>();
            this.GetComponent<ShopWindow>().turnOff(3);
            spendMoney(money);
        }
    }

    public void addKarma(float k)
    {
        karma += k;
        humans -= k * 5;
        if(humans <= 0)
        {
            humans = 1;
        }
        karmaText = "Karma: " + karma;
        humanText = "Humans left: " + humans;
    }

    public void spendKarma(float k)
    {
        if (karma - k > 0)
        {
            karma -= k;
            karmaText = "Karma: " + karma;
        }
    }
}
