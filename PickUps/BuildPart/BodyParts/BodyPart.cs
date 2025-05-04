using System.Collections.Generic;
using UnityEngine;

public class BodyPart : IPickUp
{
    protected Sprite sprite;
    public List<StatModifier> Mods { get; }
    public BaseStats Stats { get; }
    public BodyPartsType Type { get; }

    public BodyPart(BaseStats baseStats, BodyPartsType type, List<StatModifier> mods)
    {
        Stats = baseStats;
        Mods = mods;
        Type = type;
        sprite = chooseSprite(type);
    }
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
}
