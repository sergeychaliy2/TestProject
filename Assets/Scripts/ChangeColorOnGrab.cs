using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeColorOnGrab : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Renderer objectRenderer;
    private Color originalColor;
    public Color grabColor = Color.red;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }

        // Add listener
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDestroy()
    {
        // Removing event handlers when an object is destroyed
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = grabColor;
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }
    }
}
