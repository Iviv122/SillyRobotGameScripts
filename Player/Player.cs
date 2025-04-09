using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private PlayerStats stats; 
    private PlayerMovement movement;
    private BodyParts parts;
    void Awake() {

        stats = gameObject.AddComponent<PlayerStats>();
        movement = gameObject.AddComponent<PlayerMovement>();
        parts = gameObject.AddComponent<BodyParts>();

        GiveStartParts();
    }
    void GiveStartParts(){
        throw new NotImplementedException();
    }

}
