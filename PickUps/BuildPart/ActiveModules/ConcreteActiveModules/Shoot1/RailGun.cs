using UnityEngine;

public class RailGun : ActiveModule
{
    public override ModuleType ModuleType => ModuleType.MainAttack;

    public override float EnergyConsuption => 8;

    GameObject pellet;
    ProjectileScriptableObject projectile;
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/ActiveModules/RailGun");
    }
    public override void LoadData()
    {
        pellet = Resources.Load("Projectile/FlyingParticle") as GameObject;
        projectile = Resources.Load("ProjectileData/Particle") as ProjectileScriptableObject;
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
        return "Rail Gun";
    }

    public override string GetDescription()
    {
        return $"Shoots single particle on high speeds with damage {projectile.Damage} and consuming {EnergyConsuption}";
    }
}