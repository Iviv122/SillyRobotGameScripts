using UnityEngine;

public class StrangeCandy : Candy
{
    GameObject rainbowLight; 
    [SerializeField] float Gain = 3;
    public override string GetDescription()
    {
        return $"It doesn't look like a candy";
    }

    public override string GetTitle()
    {
        return $"Strange Candy";
    }

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Candies/StrangeCandy");
    }

    public override void Use(Player player)
    {
        player.BaseStats.Health += Gain;

        rainbowLight = Resources.Load<GameObject>("Prefabs/PsycoLight") as GameObject;
        GameObject gmb = Game.Instantiate(rainbowLight, new Vector3(0, 0, 0), Quaternion.identity);
        gmb.AddComponent<SelfDestruction>().duration = 60;
    }
}