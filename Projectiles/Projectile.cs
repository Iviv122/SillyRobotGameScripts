using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D),typeof(Rigidbody2D))]
abstract public class Projectile : MonoBehaviour
{
    public event Action OnHit;
    public event Action OnDestroy;
    [SerializeField] public ProjectileScriptableObject Stats; 
    [SerializeField] public Rigidbody2D rb;
}
