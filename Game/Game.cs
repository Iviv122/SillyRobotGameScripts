using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

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
    public static void Log(string text){
        Debug.Log(text);
    }
    public static void LogError(string text){
        Debug.Log(text);
    }
    public static GameObject CreateObject(GameObject gameObject,Vector3 pos,Quaternion rot){
        return Instantiate(gameObject,pos,rot);
    }
    public static Item GetRandomCommonItem(){
        var test = Assembly.GetAssembly(typeof(Item)).GetTypes().Where(t => t.IsSubclassOf(typeof(Item))).ToArray(); 
        var type =  test[UnityEngine.Random.Range(0,test.Length)];
        Item item = Activator.CreateInstance(type) as Item; 
        Debug.Log(type + "Was Given"); 
        return item;
    }
    public static ActiveModule GetRandomCommonActiveModule(){
        var test = Assembly.GetAssembly(typeof(ActiveModule)).GetTypes().Where(t => t.IsSubclassOf(typeof(ActiveModule))).ToArray(); 
        var type =  test[UnityEngine.Random.Range(0,test.Length)];
        ActiveModule item = Activator.CreateInstance(type) as ActiveModule; 
        Debug.Log(type + "Was Given"); 
        return item;
    }
}
