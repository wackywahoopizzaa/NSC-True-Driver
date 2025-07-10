using UnityEngine;

public class AutoTrafficSetController : MonoBehaviour
{
    public PhaseState currentState = PhaseState.Stop;

    [Header("Renderer to Apply Texture To")]
    public Renderer targetRenderer; // The Renderer on the traffic light model

    [Header("Light Textures")]
    public Texture greenTexture;
    public Texture yellowTexture;
    public Texture redTexture;
    public Texture offTexture;
    public Texture flashTexture;

    public void ApplyState(PhaseState state)
    {
        currentState = state;

        if (targetRenderer == null || targetRenderer.material == null)
        {
            Debug.LogWarning($"{gameObject.name}: Renderer or material is not assigned!");
            return;
        }

        switch (state)
        {
            case PhaseState.Go:
                targetRenderer.material.mainTexture = greenTexture;
                break;
            case PhaseState.Warn:
                targetRenderer.material.mainTexture = yellowTexture;
                break;
            case PhaseState.Stop:
                targetRenderer.material.mainTexture = redTexture;
                break;
            case PhaseState.Flash:
                targetRenderer.material.mainTexture = flashTexture;
                break;
            case PhaseState.Off:
                targetRenderer.material.mainTexture = offTexture;
                break;
        }
    }
}
