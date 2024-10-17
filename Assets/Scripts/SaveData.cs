using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "Scriptable Objects/DataStorage")]
public class SaveData : ScriptableObject
{
    //Adonai Österberg
    [SerializeField] public int insanityPoints; //Saves your current points.
    [SerializeField] public int clickerUpgradeLevel; //Saves the amount of upgrades you’ve made.
    [SerializeField] public int autoClickerUpgrade; //Saves your autoclicker upgrades.
    [SerializeField] public bool autoClicker; //Tells and saves whether or not you’ve purchased the auto clicker upgrade.
}
