using UnityEngine;

public class BodyPart : ISprite, IInfo
{
    protected Sprite sprite;
    public BaseStats Stats { get; }
    public BodyPartsType Type { get; }

    public BodyPart(BaseStats baseStat, BodyPartsType type)
    {
        Stats = baseStat;
        Type = type;
        sprite = chooseSprite(type);
    }
    private Sprite chooseSprite(BodyPartsType type)
    {
        switch (type)
        {
            case BodyPartsType.Head:
                return chooseSpriteByPath("Heads");
            case BodyPartsType.Body:
                return chooseSpriteByPath("Torsos");
            case BodyPartsType.Arms:
                return chooseSpriteByPath("Arms");
            case BodyPartsType.Legs:
                return chooseSpriteByPath("Legs");
            default:
                return null;
        }

    }
    private Sprite chooseSpriteByPath(string path)
    {
        string fullPath = "Sprites/BodyParts/" + path;
        Debug.Log("Attempting to load from: " + fullPath);

        Sprite[] sprites = Resources.LoadAll<Sprite>(fullPath);

        if (sprites.Length == 0)
        {
            Debug.LogWarning("No sprites found in " + fullPath);
            return null;
        }

        int randomIndex = UnityEngine.Random.Range(0, sprites.Length);
        return sprites[randomIndex];
    }

    public Sprite Sprite()
    {
        return sprite;
    }

    public string GetTitle()
    {
        switch (Type)
        {
            case BodyPartsType.Head:
                return "Head";
            case BodyPartsType.Body:
                return "Body";
            case BodyPartsType.Arms:
                return "Arms";
            case BodyPartsType.Legs:
                return "Legs";
            default:
                return "Error";
        }

    }

    public string GetDescription()
    {
        string output = "";

        output += "This body part grant next: " + "\n";

        output += "MaxHealth: " + Stats.Health + "\n";
        output += "MaxEnergy: " + Stats.Energy + "\n";
        output += "Speed: " + Stats.Speed + "\n";
        output += "HealthRegen: " + Stats.HealthRegen + "\n";
        output += "EnergyRegen: " + Stats.EnergyRegen + "\n";
        return output;
    }
}
