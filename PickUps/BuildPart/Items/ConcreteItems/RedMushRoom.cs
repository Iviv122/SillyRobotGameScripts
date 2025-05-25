using UnityEngine;
public class RedMushRoom : Item
{
    GameObject rainbowLight; 
    public override string GetTitle()
    {
        return "Red Mushroom";
    }
    public override string GetDescription()
    {
        return $"Gives some positive permanent base stats, makes you feel high";
    }
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Items/MushRoom");
    }
    public override Rarity RarityType()
    {
        return Rarity.common;
    }
    public override void OnPickUpThis(Player player)
    {
        rainbowLight = Resources.Load<GameObject>("Prefabs/PsycoLight") as GameObject;
        Game.Instantiate(rainbowLight, new Vector3(0, 0, 0), Quaternion.identity);

        player.BaseStats.Add(new BaseStats(10,1,1,0,1));
    }
}