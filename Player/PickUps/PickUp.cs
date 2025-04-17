using UnityEngine;

public class PickUp : MonoBehaviour
{
    SpriteRenderer sr;
    CircleCollider2D col;
    IPickUp item;
    Rigidbody2D rb;
    public PickUpType pickUp; 
    private void Awake() {
        GameObject colliderBox = new GameObject();
        colliderBox.transform.parent = transform;
        colliderBox.layer = LayerMask.NameToLayer("PickUp"); 
        BoxCollider2D box = colliderBox.AddComponent<BoxCollider2D>();
        box.size = new Vector2(1f, 1f);
        colliderBox.AddComponent<Rigidbody>();

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.bodyType = RigidbodyType2D.Kinematic;

        col = gameObject.AddComponent<CircleCollider2D>();
        col.radius = 0.8f;
        col.isTrigger = true;
        col.includeLayers = LayerMask.NameToLayer("Player");

        sr = GetComponent<SpriteRenderer>();
        if (sr == null) sr = gameObject.AddComponent<SpriteRenderer>();

    }
    private void Start() {
        DeterminePickUp();
        WorkWithItem();
    }
    private void WorkWithItem(){
        sr.enabled = true;
        sr.sprite = item.Sprite();
        //Debug.Log(item.Sprite());
    }
    private void DeterminePickUp() 
    {
        switch (pickUp)
        {
            case PickUpType.Item:
                item = Game.GetRandomCommonItem(); 
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            Debug.Log("PickMe Please ;)");
        }
    }
}
