using UnityEngine;
using Zenject;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objects;
    [Inject]
    void Construct(DiContainer container)
    {
        int rand = Random.Range(0, objects.Length);
        container.InstantiatePrefab(objects[rand], transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }
}
