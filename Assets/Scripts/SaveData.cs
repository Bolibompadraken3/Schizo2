using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "Scriptable Objects/DataStorage")]
public class SaveData : ScriptableObject
{
    [SerializeField] float insanityPoints; //Saves your current points.
    [SerializeField] float clickerUpgradeLevel; //Saves the amount of upgrades you’ve made.
    [SerializeField] bool autoClicker; //Tells and saves whether or not you’ve purchased the auto clicker upgrade.
}
