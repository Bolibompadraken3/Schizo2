using UnityEngine;

public class BounceScript : MonoBehaviour
{
    private Vector3 originalScale;

    private Vector3 smallerScale;
    private Vector3 largerScale;

    public float scaleSpeed = 2f;

    private enum ScaleState { None, Shrinking, Growing, Returning }
    private ScaleState currentScaleState = ScaleState.None;

    private float scaleTime = 0f;

    void Start()
    {
        originalScale = transform.localScale;

        smallerScale = originalScale * 0.95f;
        largerScale = originalScale * 1.1f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentScaleState == ScaleState.None)
        {
            currentScaleState = ScaleState.Shrinking;
            scaleTime = 0f;
        }

        HandleScaling();
    }

    void HandleScaling()
    {
        if (currentScaleState == ScaleState.Shrinking)
        {
            scaleTime += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(originalScale, smallerScale, scaleTime);

            if (scaleTime >= 1f)
            {
                currentScaleState = ScaleState.Growing;
                scaleTime = 0f;
            }
        }
        else if (currentScaleState == ScaleState.Growing)
        {
            scaleTime += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(smallerScale, largerScale, scaleTime);

            if (scaleTime >= 1f)
            {
                currentScaleState = ScaleState.Returning;
                scaleTime = 0f;
            }
        }
        else if (currentScaleState == ScaleState.Returning)
        {
            scaleTime += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(largerScale, originalScale, scaleTime);

            if (scaleTime >= 1f)
            {
                currentScaleState = ScaleState.None;
            }
        }
    }
}