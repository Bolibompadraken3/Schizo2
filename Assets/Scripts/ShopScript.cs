using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    //Adonai Österberg
    [SerializeField] int whatItem;
    [SerializeField] int price;

    public SaveData mySaveData;

    public TMP_Text priceText;
    void Start()
    {
        
    }

    void Update()
    {
        switch (whatItem)
        {
            //Clicker Upgrade
            case 0:
                {
                    if (mySaveData.clickerUpgradeLevel <= 10)
                    {
                        price = 10 * mySaveData.clickerUpgradeLevel * 8;
                    }
                    else
                    {
                        price = 10 * mySaveData.clickerUpgradeLevel * (mySaveData.clickerUpgradeLevel/10);
                    }
                    break;
                }
            //Autoclicker
            case 1:
                {
                    price = 100 * (1 + mySaveData.autoClickerUpgrade * 5);
                    break;
                }
        }
        priceText.text = price.ToString();
    }



    public void ButtonPressed()
    {
        //check if the player has enough money to purchase item
        if (mySaveData.insanityPoints >= price)
        {
            mySaveData.insanityPoints -= price;

            switch (whatItem)
            {
                //Clicker Upgrade
                case 0:
                    {
                        mySaveData.clickerUpgradeLevel += 1;
                        break;
                    }

                //Autoclicker
                case 1:
                    {
                        if (mySaveData.autoClicker == true)
                        {
                            mySaveData.autoClickerUpgrade += 1;
                            return;
                        }
                        mySaveData.autoClicker = true;
                        break;
                    }
            }
        }
        //if the player doesn't have enough money return
        else
        {
            return;
        }
    }

}
