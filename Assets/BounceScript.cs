using UnityEngine;

public class BounceScript : MonoBehaviour
{
    // Original scale of the object
    private Vector3 originalScale;

    // Target scales
    private Vector3 smallerScale;
    private Vector3 largerScale;

    // Speed of the scaling
    public float scaleSpeed = 2f;

    // State tracking for scaling phases
    private enum ScaleState { None, Shrinking, Growing, Returning }
    private ScaleState currentScaleState = ScaleState.None;

    // Time tracker
    private float scaleTime = 0f;

    void Start()
    {
        // Save the original scale of the object
        originalScale = transform.localScale;

        // Calculate target scales
        smallerScale = originalScale * 0.95f;  // 10% smaller
        largerScale = originalScale * 1.1f;   // 20% larger
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0) && currentScaleState == ScaleState.None)
        {
            // Start shrinking
            currentScaleState = ScaleState.Shrinking;
            scaleTime = 0f;  // Reset time tracker
        }

        // Handle the scaling animation
        HandleScaling();
    }

    void HandleScaling()
    {
        if (currentScaleState == ScaleState.Shrinking)
        {
            // Smoothly shrink the object
            scaleTime += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(originalScale, smallerScale, scaleTime);

            if (scaleTime >= 1f)
            {
                // Transition to the growing phase
                currentScaleState = ScaleState.Growing;
                scaleTime = 0f;
            }
        }
        else if (currentScaleState == ScaleState.Growing)
        {
            // Smoothly grow the object
            scaleTime += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(smallerScale, largerScale, scaleTime);

            if (scaleTime >= 1f)
            {
                // Transition to the returning phase
                currentScaleState = ScaleState.Returning;
                scaleTime = 0f;
            }
        }
        else if (currentScaleState == ScaleState.Returning)
        {
            // Smoothly return to the original size
            scaleTime += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(largerScale, originalScale, scaleTime);

            if (scaleTime >= 1f)
            {
                // End the scaling process
                currentScaleState = ScaleState.None;
            }
        }
    }
}