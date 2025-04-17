using UnityEngine;

[RequireComponent(typeof(Collider2D),typeof(Rigidbody2D))]
abstract public class Projectile : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
}
