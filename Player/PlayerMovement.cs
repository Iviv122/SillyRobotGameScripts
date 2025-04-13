using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Player player;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = gameObject.GetComponent<Player>();
        Debug.Log("Movement Works");

        //Debug.Log(rb);
        //Debug.Log(player);

    }

    void Update()
    {
        rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal")*player.Stats.Speed,rb.linearVelocity.y);        
    }

}
