using System;
using System.Linq;
using System.Reflection;
using NaughtyAttributes;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] float X;
    [SerializeField] float Y;


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
        item.LoadData();
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
    [Button]
    public void GetRandomCandy()
    {
        PickUp pickUp = new GameObject().AddComponent<PickUp>();

        Candy item = Game.GetRandomCandy();
        item.LoadData();
        pickUp.item = item;
        pickUp.transform.position = new Vector2(X, Y);
    }

    public static void GetRandomCommonItem(float x, float y)
    {
        PickUp pickUp = new GameObject("CommonItem").AddComponent<PickUp>();

        var itemTypes = Assembly.GetAssembly(typeof(Item)).GetTypes()
                                .Where(t => t.IsSubclassOf(typeof(Item)))
                                .ToArray();

        var type = itemTypes[UnityEngine.Random.Range(0, itemTypes.Length)];
        Item item = Activator.CreateInstance(type) as Item;
        Debug.Log($"{type} was given");

        pickUp.item = item;
        pickUp.transform.position = new Vector2(x, y);
    }

    public static void GetRandomCommonActiveModule(float x, float y)
    {
        PickUp pickUp = new GameObject("ActiveModule").AddComponent<PickUp>();

        var moduleTypes = Assembly.GetAssembly(typeof(ActiveModule)).GetTypes()
                                  .Where(t => t.IsSubclassOf(typeof(ActiveModule)))
                                  .ToArray();

        var type = moduleTypes[UnityEngine.Random.Range(0, moduleTypes.Length)];
        ActiveModule module = Activator.CreateInstance(type) as ActiveModule;
        Debug.Log($"{type} was given");
        module.LoadData();
        pickUp.item = module;
        pickUp.transform.position = new Vector2(x, y);
    }

    public static void GetRandomCommonBodyPart(float x, float y)
    {
        PickUp pickUp = new GameObject("BodyPart").AddComponent<PickUp>();

        int health = UnityEngine.Random.Range(-2, 3);
        int speed = UnityEngine.Random.Range(-2, 3);
        int energy = UnityEngine.Random.Range(-2, 3);
        int healthR = UnityEngine.Random.Range(-2, 3);
        int energyR = UnityEngine.Random.Range(-2, 3);

        BodyPartsType type = RandomEnumValue<BodyPartsType>();
        BodyPart part = new BodyPart(new BaseStats(health, speed, energy, healthR, energyR), type);
        Debug.Log($"{type} BodyPart was given");

        pickUp.item = part;
        pickUp.transform.position = new Vector2(x, y);
    }
    public static void GetRandomCandy(float x, float y)
    {
         PickUp pickUp = new GameObject("ActiveModule").AddComponent<PickUp>();

        var moduleTypes = Assembly.GetAssembly(typeof(Candy)).GetTypes()
                                  .Where(t => t.IsSubclassOf(typeof(Candy)))
                                  .ToArray();

        var type = moduleTypes[UnityEngine.Random.Range(0, moduleTypes.Length)];
        Candy module = Activator.CreateInstance(type) as Candy;
        Debug.Log($"{type} was given");
        module.LoadData();
        pickUp.item = module;
        pickUp.transform.position = new Vector2(x, y);
    }
    public static T RandomEnumValue<T>()
    {
        var values = Enum.GetValues(typeof(T));
        int random = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(random);
    }
}
