using UnityEngine;
[CreateAssetMenu(fileName = "ProjectileData", menuName = "Custom/ProjectileData")]
public class ProjectileScriptableObject : ScriptableObject
{
    public float Damage = 1;
    public float Speed = 1;
    public float Radius = 1;
    public Color ExplosionColor;
}
