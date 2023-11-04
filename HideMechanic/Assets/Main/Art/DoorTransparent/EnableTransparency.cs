using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTransparency : MonoBehaviour
{
    private Renderer objectRenderer;

    void Start()
    {
        // Get the Renderer component of the object
        objectRenderer = GetComponent<Renderer>();

        // Enable transparency for the material
        objectRenderer.material.SetFloat("_Mode", 3); // Set rendering mode to transparent

        // Make sure the material supports transparency
        objectRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        objectRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        objectRenderer.material.SetInt("_ZWrite", 0);
        objectRenderer.material.DisableKeyword("_ALPHATEST_ON");
        objectRenderer.material.EnableKeyword("_ALPHABLEND_ON");
        objectRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        objectRenderer.material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
    }
}
