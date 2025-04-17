using UnityEngine;

abstract public class ActiveModule
{
    abstract public ModuleType ModuleType {get;} 
    virtual public void OnPickUpThis(Player player){}
    abstract public void Use(Player player);

    protected static Vector2 GetMousePos(){
        Vector2 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        //Debug.Log(pos);
        return pos; 
    }
}
