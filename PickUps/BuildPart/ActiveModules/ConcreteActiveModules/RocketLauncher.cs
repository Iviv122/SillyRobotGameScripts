using UnityEngine;

public class RocketLauncher : ActiveModule 
{
    public override ModuleType ModuleType => ModuleType.MainAttack;
    GameObject pellet;
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/ActiveModules/RocketLauncher");
    }
    public override void OnPickUpThis(Player player)
    {
        pellet = Resources.Load("Projectile/Rocket") as GameObject;
    }
    public override void Use(Player player)
    {
        Vector2 mousePos = GetMousePos();
        Vector2 baseDir = (mousePos - (Vector2)player.transform.position).normalized;
        float baseAngle = Mathf.Atan2(baseDir.y, baseDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, baseAngle);

        Game.CreateObject(pellet, (Vector2)player.transform.position + baseDir, rotation);
    }
}