using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickEffect : MonoBehaviour
{
    public Button button; // Reference to the button
    public GameObject targetObject; // The object to scale

    private Vector3 originalScale;

    void Start()
    {
        originalScale = targetObject.transform.localScale;
        button.onClick.AddListener(() => StartCoroutine(ScaleObject()));
    }

    IEnumerator ScaleObject()
    {
        // Shrink by 5%
        Vector3 smallerScale = originalScale * 0.95f;
        yield return ScaleOverTime(targetObject, smallerScale, 0.02f);

        // Enlarge by 10%
        Vector3 largerScale = originalScale * 1.10f;
        yield return ScaleOverTime(targetObject, largerScale, 0.02f);

        // Return to the original scale
        yield return ScaleOverTime(targetObject, originalScale, 0.02f);
    }

    IEnumerator ScaleOverTime(GameObject obj, Vector3 targetScale, float duration)
    {
        Vector3 currentScale = obj.transform.localScale;
        float time = 0;

        while (time < duration)
        {
            obj.transform.localScale = Vector3.Lerp(currentScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = targetScale; // Ensure the target scale is reached
    }
}