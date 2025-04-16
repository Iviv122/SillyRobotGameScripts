
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    readonly List<Item> items = new();
    readonly Player Player;
    public Inventory(Player player,PlayerMovement movement){ // add event sources and subscribe
        Player = player;
        player.UpdateEvent += OnUpdate; 
        movement.Jump += OnJump;
    }

    void OnJump(){
        foreach (Item item in items)
        {
            item.OnJump(Player);
        }
    }
    void OnUpdate(){
        foreach (Item item in items)
        {
            item.OnUpdate(Player,Time.deltaTime);
        }
    }
    public void AddItem(Item item){
        items.Add(item);
    }
}
