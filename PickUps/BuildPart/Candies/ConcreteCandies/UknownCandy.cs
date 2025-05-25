using UnityEngine;

public class UknownCandy : Candy
{
    [SerializeField] float Gain = 1;
    public override string GetDescription()
    {
        return $"???";
    }

    public override string GetTitle()
    {
        return $"??? Candy";
    }

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Candies/UknownCandy");
    }

    public void HalfHealthItem(Player player)
    {
        player.DealDamage(player.Stats.CurrentHealth / 2);
        ItemSpawner.GetRandomCommonItem(player.transform.position.x,player.transform.position.y); 
    }

    public override void Use(Player player)
    {
        HalfHealthItem(player);
    }
}