
using UnityEngine;

public class RocketBattery : ActiveModule
{
    public override ModuleType ModuleType => ModuleType.Skill4;

    public override float EnergyConsuption => 10;

    GameObject pellet;
    ProjectileScriptableObject projectile;
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/ActiveModules/RocketBattery");
    }
    public override void LoadData()
    {

        pellet = Resources.Load("Projectile/ClasterGrenade") as GameObject;
        projectile = Resources.Load("ProjectileData/ClasterGrenade") as ProjectileScriptableObject;

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
        Vector3 direction = Quaternion.Euler(0, 0, baseAngle) * Vector3.right;

        Game.CreateObject(pellet, player.transform.position + direction.normalized, rotation);
    }

    public override string GetTitle()
    {
        return "Rocket Battery";
    }

    public override string GetDescription()
    {
        return $"Does nothing, if projectile hits it then copy projectile in 8 directions. Consumes {EnergyConsuption}";
    }
}
