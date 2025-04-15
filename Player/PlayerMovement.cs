using System;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Player player;
    [SerializeField] PlayerState state;
    public PlayerState State => state;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask groundLayer;

    public event Action Jump;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = gameObject.GetComponent<Player>();
        Debug.Log("Movement Works");

        //Debug.Log(rb);
        //Debug.Log(player);

    }

    private void FixedUpdate() {
        rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal")*player.Stats.Speed,rb.linearVelocity.y);
    }
    void Update()
    {
        isGrounded = OnGround();

        HandleState();
    }
    void OnJump(){
        if(isGrounded){
            rb.linearVelocity += new Vector2(0,player.Stats.Speed);
            Jump?.Invoke();
        }
    }

    bool OnGround(){
        return Physics2D.Raycast(transform.position,Vector2.down,0.45f,groundLayer);
    }

    void HandleState(){
        
        if(!isGrounded){
            state = PlayerState.Air;
        }else if(Input.GetAxisRaw("Horizontal") != 0){
            state = PlayerState.Walking;
        }else{
            state = PlayerState.Idle;
        }
    
    }
    private void OnDrawGizmosSelected() {
        Debug.DrawRay(transform.position, Vector2.down * 0.45f);
    }
}
