using UnityEngine;

abstract public class ActiveModule: ISprite, IInfo 
{
    abstract public ModuleType ModuleType {get;}
    abstract public Sprite Sprite();
    abstract public float EnergyConsuption {get ;}
    virtual public void LoadData(){}
    virtual public void OnPickUpThis(Player player) { }
    abstract public void Use(Player player);

    protected static Vector2 GetMousePos(){
        Vector2 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        //Debug.Log(pos);
        return pos; 
    }

    abstract public string GetTitle();
    abstract public string GetDescription();
}
