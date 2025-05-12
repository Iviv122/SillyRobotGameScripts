using UnityEngine;

public class SineWaveRotator : MonoBehaviour
{
    public float speed = 1f;         // Speed of the wave
    public float amplitude = 30f;    // Maximum rotation angle
    public Vector3 axis = Vector3.up; // Axis to rotate around (default is Y-axis)

    private float baseAngle;

    void Start()
    {
        baseAngle = transform.eulerAngles.y; // Store initial rotation
    }

    void Update()
    {
        float wave = Time.time * speed * amplitude;
        transform.rotation = Quaternion.Euler(axis * wave + new Vector3(baseAngle, baseAngle, baseAngle));
    }
}
