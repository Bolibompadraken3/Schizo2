using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoclickerUpgrade : MonoBehaviour
{
    //Adonai Österberg
    [SerializeField] bool canClick = false;
    [SerializeField] int minPoints = 1;
    [SerializeField] int maxPoints = 3;
    public SaveData mySaveData;
    
    void Start()
    {
        if (mySaveData.autoClicker == true)
        {
            StartCoroutine(AutoClicker());
        }
    }

    
    void Update()
    {

    }

    private IEnumerator AutoClicker()
    {
        WaitForSeconds wait = new WaitForSeconds(5f);
        canClick = true;
        while (canClick)
        {
            mySaveData.insanityPoints += Random.Range(minPoints * (mySaveData.clickerUpgradeLevel + 1) * (1 + (mySaveData.autoClickerUpgrade / 2)), maxPoints * (mySaveData.clickerUpgradeLevel + 1) * (1 + (mySaveData.autoClickerUpgrade / 2)));
            yield return wait;
        }

    }
}
