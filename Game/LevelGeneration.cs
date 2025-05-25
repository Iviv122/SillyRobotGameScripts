using System;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelGeneration : MonoBehaviour
{
    DiContainer container;

    public Transform[] startingPoint;
    public GameObject Border;
    public int randStartingPoint;
    public GameObject[] rooms;
    public GameObject[] LRRooms;
    public GameObject[] LRDRooms;
    public GameObject[] LDRTRooms;
    public GameObject[] LRTRooms;
    public GameObject Exit;
    public GameObject Entrance;

    private int direction;
    private int lastDir;

    private float moveAmount;
    private int downCounter = 0;
    private Vector2 InitPos;

    public int Width;
    public int Height;
    private float minX;
    private float minY; // how deep
    private float maxX;

    bool stopGeneratingPath = false;
    bool fillingRooms = false;
    bool EntrancePlaced = false;

    public event Action OnPathGenerated;
    public event Action OnRoomsFilled;
    public event Action OnEntrancePlaced;
    [Inject]
    void Construct(DiContainer container)
    {
        this.container = container;
    }

    [Button]
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    [Button]
    public void Clear()
    {
        Vector3 currentPos = InitPos;

        for (float y = InitPos.y; y >= minY; y -= moveAmount)
        {
            for (float x = InitPos.x; x <= maxX; x += moveAmount)
            {
                currentPos = new Vector3(x, y);

                Debug.Log(currentPos);

                DestroyRoom(currentPos);
            }
        }

    }
    public void PlaceOnSpawn(Transform trans)
    {
        trans.position = transform.position = startingPoint[randStartingPoint].position;
    }
    [Button]
    public void GenerateFromZero()
    {
        Clear();
        StartGenerate();
    }
    [Button]
    public void StartGenerate()
    {
        randStartingPoint = UnityEngine.Random.Range(0, startingPoint.Length);
        transform.position = startingPoint[randStartingPoint].position;

        stopGeneratingPath = false;
        fillingRooms = true;
        EntrancePlaced = false;
    }
    [Button]
    public void StopGenerate()
    {

        stopGeneratingPath = true;
        fillingRooms = false;
        EntrancePlaced = true;
    }
    void Awake()
    {
        GameObject border = container.InstantiatePrefab(Border, new Vector3(0, 0, 0), Quaternion.identity, null);

        if (startingPoint == null || startingPoint.Length == 0)
        {
            var tempList = new System.Collections.Generic.List<Transform>();
            for (int i = 0; i < border.transform.childCount; i++)
            {
                tempList.Add(border.transform.GetChild(i));
            }

            startingPoint = tempList.ToArray();
        }

    }
    void Start()
    {
        moveAmount = startingPoint[1].position.x - startingPoint[0].position.x;

        minX = startingPoint[0].position.x;
        maxX = startingPoint[0].position.x + moveAmount * Width;
        minY = startingPoint[0].position.y - moveAmount * Height;

        InitPos = new(startingPoint[0].position.x, startingPoint[0].position.y);
        StopGenerate();
    }
    bool IsThereRoom(Vector2 pos)
    {
        Vector2 boxSize = new Vector2(moveAmount, moveAmount) * 0.98f; // slightly smaller
        return Physics2D.OverlapBoxAll(pos, boxSize, 0).Count() > 0;
    }
    void DestroyRoom(Vector2 pos)
    {
        Vector2 boxSize = new Vector2(moveAmount, moveAmount) * 0.95f;
        Collider2D[] list = Physics2D.OverlapBoxAll(pos, boxSize, 0);
        foreach (var item in list)
        {
            Destroy(item.gameObject);
        }
    }
    void Update()
    {
        if (!stopGeneratingPath)
        {

            ChangeDirection();
            Move();
            if (!IsThereRoom(transform.position))
            {
                SpawnRoom();
            }
            OnPathGenerated?.Invoke();
            return;
        }
        else if (fillingRooms)
        {
            FillRooms();
            OnRoomsFilled?.Invoke();
            return;
        }
        else if (!EntrancePlaced)
        {

            DestroyRoom(transform.position);
            DestroyRoom(startingPoint[randStartingPoint].transform.position);
            container.InstantiatePrefab(Exit, transform.position, Quaternion.identity, null);
            container.InstantiatePrefab(Entrance, startingPoint[randStartingPoint].transform.position, Quaternion.identity, null);

            EntrancePlaced = true;
            StopGenerate();
            OnEntrancePlaced?.Invoke();
            return;
        }


    }
    private void FillRooms()
    {
        Vector3 currentPos = InitPos;

        for (float y = InitPos.y; y >= minY; y -= moveAmount)
        {
            for (float x = InitPos.x; x <= maxX; x += moveAmount)
            {
                currentPos = new Vector3(x, y);

                Debug.Log(currentPos);

                if (!IsThereRoom(currentPos))
                {
                    Debug.Log("Spawned room at " + currentPos);
                    SpawnRoom(0, currentPos);
                }
            }
        }

        fillingRooms = false;
    }

    private void SpawnRoom()
    {
        GameObject desiredRoom = null;
        if (lastDir == 0)
        {
            lastDir = 2;
            desiredRoom = GetRoomFromList(LRRooms);
        }
        else
        {
            if (InBounds(lastDir, 0, 5) && InBounds(direction, 0, 5))
            {
                //  All dirs
                desiredRoom = GetRoomFromList(LRRooms);
            }
            else if (InBounds(lastDir, 0, 5) && direction == 5)
            {
                // Delete Last Room And Gen A new One with all top and down

                //Spawn with drop 
                desiredRoom = GetRoomFromList(LRDRooms);
            }
            else if (lastDir == 5)
            {
                // without roof
                desiredRoom = GetRoomFromList(LRTRooms);
            }
        }

        container.InstantiatePrefab(desiredRoom, transform.position, Quaternion.identity, null);
    }
    private void SpawnRoom(int index, Vector2 pos)
    {
        GameObject desiredRoom = null;
        switch (index)
        {
            case 1:
                desiredRoom = GetRoomFromList(LRRooms);
                break;
            case 2:
                desiredRoom = GetRoomFromList(LRTRooms);
                break;
            case 3:
                desiredRoom = GetRoomFromList(LRDRooms);
                break;
            case 4:
                desiredRoom = GetRoomFromList(LDRTRooms);
                break;
            default:
                desiredRoom = GetRoomFromList(rooms);
                break;
        }

        container.InstantiatePrefab(desiredRoom, pos, Quaternion.identity, null);

    }
    private GameObject GetRoomFromList(GameObject[] list)
    {
        return list[UnityEngine.Random.Range(0, list.Count())];
    }
    private bool InBounds(int x, int a, int b)
    {
        return x > a && x < b;
    }
    private void Move()
    {
        Vector2 initPos = transform.position;
        Vector2 newPos = transform.position;

        if (direction == 1 || direction == 2)
        { // move right
            if (transform.position.x < maxX)
            {
                newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
            }
            else
            {
                direction = 5;
                return;
            }
        }
        else if (direction == 3 || direction == 4)
        { // move left 
            if (transform.position.x > minX)
            {
                newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
            }
            else
            {
                direction = 5;
                return;
            }
        }
        else if (direction == 5)
        { // move down
            downCounter++;
            if (transform.position.y > minY)
            {
                Vector2 abovePos = transform.position;
                newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);

                if (IsTop(transform.position))
                {
                    DestroyRoom(transform.position);
                    SpawnRoom(4, transform.position); // Room with top entrance
                }

                if (downCounter >= 2)
                {
                    // Ensure room above has a bottom entrance
                    DestroyRoom(abovePos);
                    SpawnRoom(4, transform.position); // Example: Room with bottom entrance

                    // Ensure room below has a top entrance
                    DestroyRoom(newPos);
                    SpawnRoom(4, transform.position); // Room with top entrance
                }
            }
            else
            {
                stopGeneratingPath = true;
                return;
            }
        }

        transform.position = newPos;

        if (IsThereRoom(newPos))
        {
            transform.position = initPos;
            return;
        }

        if (direction != 5)
        {
            downCounter = 0;
        }

        lastDir = direction;
    }

    private bool IsTop(Vector2 pos)
    {
        return Physics2D.Raycast(pos, Vector2.up, moveAmount * 2f);
    }
    private void ChangeDirection()
    {
        direction = UnityEngine.Random.Range(1, 6);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(moveAmount, moveAmount, 0));
    }
}