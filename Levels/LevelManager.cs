using NaughtyAttributes;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] GameObject[] levels;
    [SerializeField] int _levelCounter = 0;
    [SerializeField] Collider2D col;

    [Inject] private DiContainer _container;

    [Inject]
    void Construct(Player player)
    {
        _player = player;
        col = gameObject.GetComponent<Collider2D>();
    }

    [Button]
    public void StartLevel()
    {
        _container.InstantiatePrefab(levels[0], transform.position, Quaternion.identity, null); 
        _levelCounter++;
    }
    void _StartLevel(){

    }
    void SpawnInsideCol()
    {
        var bounds = col.bounds;
        var px = Random.Range(bounds.min.x, bounds.max.x);
        var py = Random.Range(bounds.min.y, bounds.max.y);
        Vector2 pos = new Vector3(px, py);

    }

}
