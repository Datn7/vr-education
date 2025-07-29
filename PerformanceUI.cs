using TMPro;
using UnityEngine;
using UnityEngine.Profiling;

public class PerformanceUI : MonoBehaviour
{
    public TextMeshProUGUI textField;
    private float deltaTime = 0.0f;

    void Update()
    {
        // Smooth FPS calculation
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        // Approximate batch count by counting active Renderers
        int rendererCount = 0;
        var renderers = FindObjectsOfType<Renderer>();
        foreach (var r in renderers)
        {
            if (r.enabled && r.isVisible)
                rendererCount++;
        }

        // Display on UI
        textField.text = $"FPS: {fps:F1}\n~Batches: {rendererCount}";
    }
}