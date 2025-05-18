using UnityEngine;

public class BulletBattery : Item
{
    GameObject bullet;
    ProjectileScriptableObject bulletData;

    int counterProcs = 4;
    int counter = 5;

    public BulletBattery()
    {

        bullet = Resources.Load("Projectile/FlyingScrap") as GameObject;
        bulletData = Resources.Load("ProjectileData/FlyingScrap") as ProjectileScriptableObject;
    }

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Items/BulletBattery");
    }
    public override Rarity RarityType()
    {
        return Rarity.common;
    }

    public override string GetTitle()
    {
        return "Electric Aura";
    }
    public override void OnPickUpThis(Player player)
    {
        counter = counterProcs;
    }
    public override void OnAnyModuleUse(Player player)
    {
        if (counter == 0)
        {
            Vector2 dir;
            dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            Game.Instantiate(bullet, player.transform.position + (Vector3)dir, rotation);

            counter = counterProcs;
        }
        else
        {
            counter--;
        }

    }
    public override string GetDescription()
    {
        return $"Shoots bullet in random direction every {counter} modules uses wich deals {bulletData.Damage} damage";
    }
}
