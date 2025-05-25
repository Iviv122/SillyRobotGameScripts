using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    [SerializeField] public float duration;
    void Start()
    {
        Invoke(nameof(Destroy),duration);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
