using UnityEngine;
using TMPro;

public class Clicker : MonoBehaviour
{
    // Public float to increase, starting at 0
    public float valueToIncrease = 0f;

    // Reference to the TextMeshPro text component
    public TMP_Text valueText;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial text to show the value of valueToIncrease (which is 0 at the start)
        valueText.text = "Value: 0";
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the user clicked on the object this script is attached to
        if (Input.GetMouseButtonDown(0)) // 0 means left mouse button
        {
            // Increase the value
            valueToIncrease += 1f;

            // Update the TextMeshPro text with the new value
            valueText.text = "Insanity: " + valueToIncrease.ToString();
        }
    }
}