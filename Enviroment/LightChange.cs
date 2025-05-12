using UnityEngine;

[RequireComponent(typeof(Light))]
public class SineColorChanger : MonoBehaviour
{
    public float speed = 1f; // Speed of color change
    private Light lightSource;

    void Start()
    {
        lightSource = GetComponent<Light>();
    }

    void Update()
    {
        float time = Time.time * speed;

        // Generate RGB values using sine waves
        float r = Mathf.Sin(time) * 0.5f + 0.5f;
        float g = Mathf.Sin(time + 2f) * 0.5f + 0.5f; // Offset by 2 radians
        float b = Mathf.Sin(time + 4f) * 0.5f + 0.5f; // Offset by 4 radians

        lightSource.color = new Color(r, g, b);
    }
}
