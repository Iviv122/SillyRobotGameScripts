using UnityEngine;

abstract public class Item : ISprite, IInfo
{

    abstract public Rarity RarityType();
    //Add other events
    virtual public void OnJump(Player player)
    {

    }
    virtual public void OnUpdate(Player player, float DeltaTime)
    {

    }
    virtual public void OnAnyModuleUse(Player player)
    {

    }
    virtual public void OnDeleteThis(Player player)
    {

    }
    virtual public void OnPickUpThis(Player player)
    {

    }
    virtual public void OnItemPickUp(Player player)
    {

    }
    virtual public void OnItemDelete(Player player)
    {

    }
    virtual public void OnDamageTaken(Player player)
    {

    }
    public abstract string GetTitle();
    public abstract string GetDescription();
    abstract public Sprite Sprite();
}
