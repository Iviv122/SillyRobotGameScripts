using UnityEngine;

public class SimpleGun : ActiveModule
{
    public override ModuleType ModuleType => ModuleType.MainAttack;

    public override float EnergyConsuption => 2;

    GameObject pellet;
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/ActiveModules/FanOfScrap");
    }
    public override void OnPickUpThis(Player player)
    {
        pellet = Resources.Load("Projectile/FlyingScrap") as GameObject;
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

}