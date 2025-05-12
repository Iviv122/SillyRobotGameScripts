using System;
using System.Linq;
using System.Reflection;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
    [SerializeField] float SpawnPosX;
    [SerializeField] float SpawnPosY;
    [SerializeField] LevelManager levelManager;
    public static Game Instance { get; private set; }

    [Inject]
    void Construct(LevelManager manager){
        levelManager =manager; 
    }

    public void StartGame(){
        levelManager.StartTutorial();
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
        return Instantiate(gameObject, pos, rot);
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

        BodyPartsType type = RandomEnumValue<BodyPartsType>();

        BodyPart part = new BodyPart(new BaseStats(health, speed, energy), type);
        return part;
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
