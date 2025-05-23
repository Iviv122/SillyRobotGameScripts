using UnityEngine;

public class FanOfScrap : ActiveModule 
{
    public override ModuleType ModuleType => ModuleType.MainAttack;

    public override float EnergyConsuption => 2;

    GameObject pellet;
    ProjectileScriptableObject projectile;
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/ActiveModules/FanOfScrap");
    }
    public override void LoadData()
    {
        
        pellet = Resources.Load("Projectile/FlyingScrap") as GameObject;
        projectile = Resources.Load("ProjectileData/FlyingScrap") as ProjectileScriptableObject;

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

        int numProjectiles = 3;
        float spreadAngle = 25f; // degrees between each projectile

        for (int i = 0; i < numProjectiles; i++)
        {
            float angleOffset = (i - 1) * spreadAngle;
            float finalAngle = baseAngle + angleOffset;

            Quaternion rotation = Quaternion.Euler(0, 0, finalAngle);
            Vector3 direction = Quaternion.Euler(0, 0, finalAngle) * Vector3.right;

            Game.CreateObject(pellet, player.transform.position + direction.normalized, rotation);
        }
    }

    public override string GetTitle()
    {
        return "Fan Of Scrap";
    }

    public override string GetDescription()
    {
        return $"Shoots spray of 3 scap pieces each deals {projectile.Damage} and consuming {EnergyConsuption}";
    }
}
