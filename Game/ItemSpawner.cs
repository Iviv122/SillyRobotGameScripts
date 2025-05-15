using System;
using System.Linq;
using System.Reflection;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] float X;
    [SerializeField] float Y;

    [Inject]

    [Button]
    public void GetRandomCommonItem()
    {
        PickUp pickUp = new GameObject().AddComponent<PickUp>();

        var test = Assembly.GetAssembly(typeof(Item)).GetTypes().Where(t => t.IsSubclassOf(typeof(Item))).ToArray();
        var type = test[UnityEngine.Random.Range(0, test.Length)];
        Item item = Activator.CreateInstance(type) as Item;
        Debug.Log(type + " was given");

        pickUp.item = item;
        pickUp.transform.position = new Vector2(X, Y);
    }

    [Button]
    public void GetRandomCommonActiveModule()
    {
        PickUp pickUp = new GameObject().AddComponent<PickUp>();

        var test = Assembly.GetAssembly(typeof(ActiveModule)).GetTypes().Where(t => t.IsSubclassOf(typeof(ActiveModule))).ToArray();
        var type = test[UnityEngine.Random.Range(0, test.Length)];
        ActiveModule item = Activator.CreateInstance(type) as ActiveModule;
        Debug.Log(type + " was given");

        pickUp.item = item;
        pickUp.transform.position = new Vector2(X, Y);
    }

    [Button]
    public void GetRandomCommonBodyPart()
    {
        PickUp pickUp = new GameObject().AddComponent<PickUp>();

        int health = UnityEngine.Random.Range(-2, 3);
        int speed = UnityEngine.Random.Range(-2, 3);
        int energy = UnityEngine.Random.Range(-2, 3);
        int healthR = UnityEngine.Random.Range(-2, 3);
        int energyR = UnityEngine.Random.Range(-2, 3);

        BodyPartsType type = RandomEnumValue<BodyPartsType>();
        BodyPart part = new BodyPart(new BaseStats(health, speed, energy, healthR, energyR), type);
        Debug.Log(type + " BodyPart was given");

        pickUp.item = part;
        pickUp.transform.position = new Vector2(X, Y);
    }

    public static T RandomEnumValue<T>()
    {
        var values = Enum.GetValues(typeof(T));
        int random = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(random);
    }
}
