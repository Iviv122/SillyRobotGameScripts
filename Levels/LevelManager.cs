using NaughtyAttributes;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Tutorial tutorial;
    [SerializeField] GameObject[] levels;
    [SerializeField] Level _currentLevel;
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
        _player.transform.position = new Vector3(0,-9,0);
        _currentLevel = _container.InstantiatePrefab(levels[_levelCounter], transform.position, Quaternion.identity, null).GetComponent<Level>(); 
        _levelCounter++;

        _currentLevel.OnLevelEnd += EndLevel; 
    }
    public void EndLevel(){
        _currentLevel.OnLevelEnd -= EndLevel;
        Destroy(_currentLevel.gameObject);
        // ? Delay();
        StartLevel();
    }
    public void StartTutorial(){
        tutorial = _container.InstantiatePrefab(tutorial,transform.position,Quaternion.identity,null).GetComponent<Tutorial>();
        tutorial.OnTutorialEnd += EndTutorial;
    }
    public void EndTutorial(){
        Destroy(tutorial.gameObject);
        // ? Delay();
        StartLevel();
    }
    void SpawnInsideCol()
    {
        var bounds = col.bounds;
        var px = Random.Range(bounds.min.x, bounds.max.x);
        var py = Random.Range(bounds.min.y, bounds.max.y);
        Vector2 pos = new Vector3(px, py);

    }

}
