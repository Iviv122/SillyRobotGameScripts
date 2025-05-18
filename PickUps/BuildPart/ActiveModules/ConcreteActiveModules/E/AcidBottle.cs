using UnityEngine;

public class AcidBottle : ActiveModule
{
    public override ModuleType ModuleType => ModuleType.Skill2;

    public override float EnergyConsuption => 8;

    GameObject pellet;
    ProjectileScriptableObject projectile;
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/ActiveModules/AcidBottle");
    }
    public override void LoadData()
    {
        
        pellet = Resources.Load("Projectile/AcidBottle") as GameObject;
        projectile = Resources.Load("ProjectileData/AcidBottle") as ProjectileScriptableObject;

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
        return "Acid Bottle";
    }

    public override string GetDescription()
    {
        return $"Throws single jar of acid which explodes on contact with {projectile.Damage} damage in {projectile.Radius} on use consumes {EnergyConsuption} energy";
    }
}