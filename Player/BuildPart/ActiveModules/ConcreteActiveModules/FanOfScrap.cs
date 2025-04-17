using UnityEngine;

public class FanOfScrap : ActiveModule 
{
    public override ModuleType ModuleType => ModuleType.MainAttack;

    GameObject pellet;
    public override void OnPickUpThis(Player player)
    {
        pellet = Resources.Load("Projectile/FlyingScrap") as GameObject;
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
            // -1, 0, 1 --> center projectile is i=1
            float angleOffset = (i - 1) * spreadAngle;
            float finalAngle = baseAngle + angleOffset;

            // Мы крутим верктор вокруг кватерниона

            Quaternion rotation = Quaternion.Euler(0, 0, finalAngle);
            Vector3 direction = Quaternion.Euler(0, 0, finalAngle) * Vector3.right;

            Game.CreateObject(pellet, player.transform.position + direction.normalized, rotation);
        }
    }

}
