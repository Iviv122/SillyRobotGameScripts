using NaughtyAttributes;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Tutorial tutorial;
    [SerializeField] GameObject[] levels;
    [SerializeField] GameObject[] EasyLevels;
    [SerializeField] GameObject[] MediumLevels;
    [SerializeField] GameObject[] HardLevels;
    [SerializeField] GameObject[] events;
    [SerializeField] Level _currentLevel;
    [SerializeField] int _levelCounter = 0;
    [SerializeField] Collider2D col;
    [SerializeField] DelayCounter delayCounter;

    [Inject] private DiContainer _container;

    [Inject]
    void Construct(Player player, DelayCounter delayCounter)
    {
        _player = null;
        _player = player;
        this.delayCounter = delayCounter;
        col = gameObject.GetComponent<Collider2D>();

        delayCounter.gameObject.SetActive(false);
        delayCounter.OnEnd += StartLevel;
    }

    [Button]
    public void StartLevel()
    {

        if (_currentLevel != null)
        {
            Debug.LogWarning("Level already started!");
            return;
        }
        delayCounter.gameObject.SetActive(false);
        _player.transform.position = new Vector3(0, -9, 0);
        _currentLevel = _container.InstantiatePrefab(levels[_levelCounter], transform.position, Quaternion.identity, null).GetComponent<Level>();
        _levelCounter++;

        _currentLevel.OnLevelEnd += EndLevel;
    }
    public void EndLevel()
    {
        _currentLevel.OnLevelEnd -= EndLevel;
        Destroy(_currentLevel.gameObject);
        delayCounter.gameObject.SetActive(true);
        delayCounter.StartCount();
    }
    public void StartEventFullRoom()
    {
        delayCounter.gameObject.SetActive(false);

        _player.transform.position = new Vector3(0, -9, 0);
        _currentLevel = _container.InstantiatePrefab(levels[_levelCounter], transform.position, Quaternion.identity, null).GetComponent<Level>();
        _levelCounter++;

        _currentLevel.OnLevelEnd += EndLevel;
    }
    public void StartTutorial()
    {
        delayCounter.gameObject.SetActive(false);
        tutorial = _container.InstantiatePrefab(tutorial, transform.position, Quaternion.identity, null).GetComponent<Tutorial>();
        tutorial.OnTutorialEnd += EndTutorial;
    }
    public void EndTutorial()
    {
        Destroy(tutorial.gameObject);
        delayCounter.gameObject.SetActive(true);
        delayCounter.StartCount();
    }
    void SpawnInsideCol()
    {
        var bounds = col.bounds;
        var px = Random.Range(bounds.min.x, bounds.max.x);
        var py = Random.Range(bounds.min.y, bounds.max.y);
        Vector2 pos = new Vector3(px, py);

    }

}
