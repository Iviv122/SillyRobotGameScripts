
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    readonly List<Item> items = new();
    readonly Player Player;
    public Inventory(Player player, PlayerMovement movement)
    { // add event sources and subscribe
        Player = player;
        player.UpdateEvent += OnUpdate;
        movement.OnJumpInput += OnJump;
        player.ModuleManager.OnModuleUse += OnModuleUse;
    }

    void OnJump()
    {
        foreach (Item item in items)
        {
            item.OnJump(Player);
        }
    }
    void OnUpdate()
    {
        foreach (Item item in items)
        {
            item.OnUpdate(Player, Time.deltaTime);
        }
    }
    public void AddItem(Item item)
    {
        items.Add(item);
        item.OnPickUpThis(Player);
        foreach (Item i in items)
        {
            i.OnItemPickUp(Player);
        }
    }
    public void DeleteItem(Item item)
    {
        item.OnDeleteThis(Player);
        items.Remove(item);
        foreach (Item i in items)
        {
            i.OnItemDelete(Player);
        }
    }
    public void OnModuleUse()
    {
        foreach (Item i in items)
        {
            i.OnAnyModuleUse(Player);
        }
    }
}
