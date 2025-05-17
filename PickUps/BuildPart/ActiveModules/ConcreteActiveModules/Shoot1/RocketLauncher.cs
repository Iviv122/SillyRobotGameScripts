using UnityEngine;

public class RocketLauncher : ActiveModule 
{
    public override ModuleType ModuleType => ModuleType.MainAttack;

    public override float EnergyConsuption => 3;

    GameObject pellet;
    ProjectileScriptableObject projectile;
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/ActiveModules/RocketLauncher");
    }
    public override void LoadData()
    {
        pellet = Resources.Load("Projectile/Rocket") as GameObject;
        projectile = Resources.Load("ProjectileData/Rocket") as ProjectileScriptableObject;
    }
    public override void OnPickUpThis(Player player)
    {
        LoadData();
    }
    public override void Use(Player player)
    {
        Vector2 mousePos = GetMousePos();
        Vector2 baseDir = (mousePos - (Vector2)player.transform.position).normalized;
        float baseAngle = Mathf.Atan2(baseDir.y, baseDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, baseAngle);

        Game.CreateObject(pellet, (Vector2)player.transform.position + baseDir, rotation);
    }

    public override string GetTitle()
    {
        return "Rocket Launcher";
    }

    public override string GetDescription()
    {
        return $"Shoots single rocket with damage {projectile.Damage} and radius {projectile.Radius} while consuming {EnergyConsuption} energy";
    }
}