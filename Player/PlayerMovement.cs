using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerStats stats;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        stats = gameObject.GetComponent<PlayerStats>();
        Debug.Log("Movement Works");

    }

    void Update()
    {
        rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal")*stats.Speed,rb.linearVelocityY);        
    }

}
