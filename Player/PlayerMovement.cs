using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(Rigidbody2D), typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D col;
    [SerializeField] Player player;
    [SerializeField] PlayerState state;
    public PlayerState State => state;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask groundLayer;

    Vector2 input;
    public event Action Jump;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = gameObject.GetComponent<Player>();
        Debug.Log("Movement Works");

        //Debug.Log(rb);
        //Debug.Log(player);

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(input.x * player.Stats.Speed, rb.linearVelocity.y);
    }
    private void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }
    private void DisablePlayerCollider()
    {
        col.enabled = false;
    }
    private void EnablePlayerCollider()
    {
        col.enabled = true;
    }
    void Update()
    {
        isGrounded = OnGround();

        HandleState();

        if(state == PlayerState.InPlatform){
            DisablePlayerCollider();
        }else{
            EnablePlayerCollider();
        }

    }
    void OnJump()
    {
        if (isGrounded)
        {
            rb.linearVelocity += new Vector2(0, player.Stats.Speed);
            Jump?.Invoke();
        }
    }

    bool OnGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.45f, groundLayer);
    }

    void HandleState()
    {

        if (!isGrounded)
        {
            state = PlayerState.Air;
        }
        else if (Input.GetAxisRaw("Horizontal") != 0)
        {
            state = PlayerState.Walking;
        }
        else
        {
            state = PlayerState.Idle;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.45f);
    }
}
