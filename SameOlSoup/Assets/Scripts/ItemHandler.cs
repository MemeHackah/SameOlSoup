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
    private bool artMade = false;
    public GameObject autoMat;
    public GameObject autoSeller;
    public GameObject autoSouper;
    public GameObject artifact;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 30;
        soupCount = 0;
        materialCount = 0;
        moneyCount = 0f;
        soupsMade = 0f;
        humans = 1000000000;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(soupsMade > 100 && !artMade)
        {
            Instantiate(artifact);
            artifact.GetComponent<ArtifactWindow>().manager = this.gameObject.GetComponent<ItemHandler>();
            artMade = true;
        }
        if (humans <= 1)
        {
            SceneManager.LoadScene(1);
        }
        if(timer <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void changeValue(float value)
    {
        soupValue = value;
        timer = 30;
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
        timer = 30;
    }

    public void addSoup(int num)
    {
        soupCount += num;
        soupsMade += num;
        soupText = "Soup: " + soupCount;
        timer = 30;
    }

    public void addMaterials()
    {
        materialCount += 1;
        materialText = "Materials: " + materialCount;
        timer = 30;
    }

    public void addMaterials(float matCount)
    {
        materialCount += (int)matCount;
        materialText = "Materials: " + materialCount;
        timer = 30;
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
        timer = 30;
    }

    public void spendMoney(float money)
    {
        moneyCount -= money;
        moneyText = "Money: " + moneyCount;
        timer = 30;
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
        timer = 30;
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
        timer = 30;
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
        timer = 30;
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
        timer = 30;
    }

    public void spendKarma(float k)
    {
        if (karma - k > 0)
        {
            karma -= k;
            karmaText = "Karma: " + karma;
        }
        timer = 30;
    }
}
