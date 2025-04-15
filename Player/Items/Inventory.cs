
using System.Collections.Generic;

public class Inventory 
{
    readonly List<Item> items = new();
    readonly Player Player;
    public Inventory(Player player,PlayerMovement movement){ // add event sources and subscribe
        Player = player; 
        movement.Jump += OnJump;
    }

    void OnJump(){
        foreach (Item item in items)
        {
            item.OnJump(Player);
        }
    }
    public void AddItem(Item item){
        items.Add(item);
    }
}
