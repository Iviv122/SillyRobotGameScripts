using System.Collections.Generic;
using UnityEngine;

public class InjectItems
{

    private const string CharacterToken = "CurrentCharacter";
    public static int characterSet;
    static int TotalCharacterSets = 3;
    public static void NextCharacter()
    {
        characterSet = (characterSet + 1) % TotalCharacterSets;
    }

    public List<Item> GetCurrentItemSet()
    {
        return GetSet(characterSet);
    }
    public List<Item> GetSet(int characterSet)
    {
        switch (characterSet)
        {
            case 0:
                return new List<Item>();

            case 1:
                List<Item> items = new()
                {
                    new RedMushRoom(),
                    new RedMushRoom()
                };
                return items;
            case 2:
                List<Item> items1 = new()
                {
                    new StrangeMask(),
                    new StrangeMask(),
                };
                return items1;
            default:
                return new List<Item>();
        }
    }
    public Sprite GetCurrentSprite()
    {
        return GetSprite(characterSet);
    }
    public Sprite GetSprite(int characterSet)
    {
        switch (characterSet)
        {
            case 0:
                return Resources.Load<Sprite>("Sprites/Characters/1");
            case 1:
                return Resources.Load<Sprite>("Sprites/Characters/2");
            case 2:
                return Resources.Load<Sprite>("Sprites/Characters/3");
            default:
                return Resources.Load<Sprite>("Sprites/Characters/1");
        }
    }
}
