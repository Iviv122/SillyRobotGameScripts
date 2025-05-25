using UnityEngine;

public class LemonGrenade : Projectile
{

    void Awake()
    {
        rb.linearVelocity = transform.right * Stats.Speed;
    }
    static Vector2[] directions = new Vector2[]
       {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right,
        (Vector2.up + Vector2.right).normalized,
        (Vector2.up + Vector2.left).normalized,
        (Vector2.down + Vector2.right).normalized,
        (Vector2.down + Vector2.left).normalized
       };

    void RoundShoot(GameObject projectile)
    {
        foreach (Vector2 dir in directions)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            GameObject bul = Instantiate(projectile, (Vector2)transform.position + dir, rotation, null);
            foreach (Behaviour comp in bul.GetComponentsInChildren<Behaviour>(true))
            {
                comp.enabled = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Projectile>(out Projectile proj))
        {
            if (proj is LemonGrenade) {
                return;
            }
            GameObject proj1 = proj.gameObject;
            RoundShoot(proj1);
        }
        Destroy(gameObject);
    }

}