using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
    [SerializeField] float SpawnPosX;
    [SerializeField] float SpawnPosY;
    [SerializeField] LevelGeneration LevelGen;
    [SerializeField] GameManager gameManager;
    [SerializeField] Player player;
    public static Game Instance { get; private set; }

    [Inject]
    void Construct(Player player,GameManager gameManager)
    {
        this.player = player;
        this.gameManager = gameManager;

    }

    public void StartGame()
    {
        gameManager.StartGame();
    }
    
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static GameObject CreateObject(GameObject gameObject, Vector3 pos, Quaternion rot)
    {
        return Instantiate(gameObject, pos, rot,null);
    }
    public static Item GetRandomCommonItem()
    {
        var test = Assembly.GetAssembly(typeof(Item)).GetTypes().Where(t => t.IsSubclassOf(typeof(Item))).ToArray();
        var type = test[UnityEngine.Random.Range(0, test.Length)];
        Item item = Activator.CreateInstance(type) as Item;
        Debug.Log(type + "Was Given");
        return item;
    }
    public static ActiveModule GetRandomCommonActiveModule()
    {
        var test = Assembly.GetAssembly(typeof(ActiveModule)).GetTypes().Where(t => t.IsSubclassOf(typeof(ActiveModule))).ToArray();
        var type = test[UnityEngine.Random.Range(0, test.Length)];
        ActiveModule item = Activator.CreateInstance(type) as ActiveModule;
        Debug.Log(type + "Was Given");
        return item;
    }
    public static BodyPart GetRandomCommonBodyPart()
    {
        int health = UnityEngine.Random.Range(-2, 3);
        int speed = UnityEngine.Random.Range(-2, 3);
        int energy = UnityEngine.Random.Range(-2, 3);
        int healthR = UnityEngine.Random.Range(-2, 3);
        int energyR = UnityEngine.Random.Range(-2, 3);

        BodyPartsType type = RandomEnumValue<BodyPartsType>();

        BodyPart part = new BodyPart(new BaseStats(health, speed, energy,healthR,energyR), type);
        return part;
    }
    public static Candy GetRandomCandy()
    {
        var test = Assembly.GetAssembly(typeof(Candy)).GetTypes().Where(t => t.IsSubclassOf(typeof(Candy))).ToArray();
        var type = test[UnityEngine.Random.Range(0, test.Length)];
        Candy item = Activator.CreateInstance(type) as Candy;
        Debug.Log(type + "Was Given");
        return item;
    }
    public static T RandomEnumValue<T>()
    {
        var values = Enum.GetValues(typeof(T));
        int random = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(random);
    }
    public static void Log(string text)
    {
        Debug.Log(text);
    }
    public static void LogError(string text)
    {
        Debug.Log(text);
    }
}
