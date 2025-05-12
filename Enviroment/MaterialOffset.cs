using UnityEngine;

public class ScrollMaterialOffset : MonoBehaviour
{
    public Renderer targetRenderer; // Assign in Inspector
    public Vector2 scrollSpeed = new Vector2(0.1f, 0f); // Horizontal scroll

    private Material mat;
    private Vector2 currentOffset;

    void Start()
    {
        if (targetRenderer != null)
        {
            // Use an instance of the material
            mat = targetRenderer.material;
            currentOffset = mat.mainTextureOffset;
        }
    }

    void Update()
    {
        if (mat != null)
        {
            currentOffset += scrollSpeed * Time.deltaTime;
            mat.mainTextureOffset = currentOffset;
        }
    }
}
