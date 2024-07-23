using UnityEngine;
using BNG;

public class ChangeColorOnGrab : MonoBehaviour
{
    private GrabbableUnityEvents grabbableUnityEvents;
    private Renderer objectRenderer;
    private Color originalColor;
    public Color grabColor = Color.red;

    private void Awake()
    {
        grabbableUnityEvents = GetComponent<GrabbableUnityEvents>();
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }

        // Add listeners for grab and release events
        grabbableUnityEvents.onGrab.AddListener(OnGrab);
        grabbableUnityEvents.onRelease.AddListener(OnRelease);
    }

    private void OnDestroy()
    {
        // Remove event handlers when the object is destroyed
        grabbableUnityEvents.onGrab.RemoveListener(OnGrab);
        grabbableUnityEvents.onRelease.RemoveListener(OnRelease);
    }

    private void OnGrab(Grabber grabber)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = grabColor;
        }
    }

    private void OnRelease()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }
    }
}
