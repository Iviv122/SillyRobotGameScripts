using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static void Log(string text){
        Debug.Log(text);
    }
    public static void LogError(string text){
        Debug.Log(text);
    }
    public static Item GetRandomCommonItem(){
        var test = Assembly.GetAssembly(typeof(Item)).GetTypes().Where(t => t.IsSubclassOf(typeof(Item))).ToArray(); 
        Item item = Activator.CreateInstance(test[UnityEngine.Random.Range(0,test.Length)]) as Item; 
        
        return item;
    }
}
