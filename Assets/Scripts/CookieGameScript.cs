using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CookieGameScript : MonoBehaviour
{
    [SerializeField] int InsanityCount = 0;
    [SerializeField] int InsanityAdd = 1;
    [SerializeField] int InsanityAddCost = 1;

    public bool EscOpen = false;

    public TMP_Text ShopInsanityCost;
    public TMP_Text InsanityText;
    public TMP_Text InsanityPerClick;
    public SaveData myData;


    [SerializeField] GameObject NoInsanity;
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject ShopButton;
    [SerializeField] GameObject EscMenu;
    void Start()
    {
        InsanityText.text = "Insanity:" + myData.insanityPoints;
        InsanityAdd = 1 * (myData.clickerUpgradeLevel + 1);
        EscOpen = false;
    }

    public void OnCookieClick()
    {
        //InsanityCount++;

        if (InsanityAdd > 1)
        {
            myData.insanityPoints += InsanityAdd;
        }
        else
        {
            myData.insanityPoints += InsanityAdd;
            InsanityCount++;
        }
        InsanityText.text = "Insanity:" + myData.insanityPoints;
    }
    public void Update()
    {
        InsanityText.text = "Insanity:" + myData.insanityPoints;
        ShopInsanityCost.text = InsanityAddCost + "Insanity";
        InsanityPerClick.text = InsanityAdd + "Insanity";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("EscPressed");
            if (EscOpen == false)
            {
                EscMenu.SetActive(true);
                EscOpen = true;
                Debug.Log("no");
            }
            //while (EscOpen == true)
            //{
            //    if (Input.GetKeyDown(KeyCode.Escape))
            //    { }
            //    EscMenu.SetActive(false);
            //    EscOpen = false;
            //    Debug.Log("yes");
            //}
            
        }
    }
    public void OnShopClick()
    {
        Shop.SetActive(true);
        ShopButton.SetActive(false);
    }
    public void ShopButtonClose()
    {
        ShopButton.SetActive(true);
        Shop.SetActive(false);
    }
    public IEnumerator BuyButton()
    {
        if(InsanityCount >= InsanityAddCost)
        {
          
            InsanityCount -= InsanityAddCost;
            InsanityAddCost++;
            InsanityAdd++;
        
        }
    else
        {
         NoInsanity.SetActive(true);
            yield return new WaitForSeconds(1);
            NoInsanity.SetActive(false);
        }

    }
    public void BuyButton1()
    {
        StartCoroutine(BuyButton());
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Shop");
    }
}
