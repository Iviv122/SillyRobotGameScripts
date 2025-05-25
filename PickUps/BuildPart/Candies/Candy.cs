
using UnityEngine;

abstract public class Candy : ISprite, IInfo
{
    abstract public Sprite Sprite();
    virtual public void LoadData() { }
    abstract public void Use(Player player);

    abstract public string GetTitle();
    abstract public string GetDescription();

}
