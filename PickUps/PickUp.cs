using System;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteract
{
    SpriteRenderer sr;
    CircleCollider2D col;
    public IPickUp item;
    Rigidbody2D rb;
    public PickUpType pickUp;
    public event Action OnUse;
    public void Use(object obj)
    {
        if (obj is InteractManager interactManager)
        {
            interactManager.PickUp(item);
        }
        Destroy(gameObject);
    }
    public IPickUp Get()
    {
        return item;
    }

    private void Awake()
    {
        GameObject colliderBox = new GameObject();
        colliderBox.transform.parent = transform;
        colliderBox.layer = LayerMask.NameToLayer("PickUp");
        colliderBox.transform.localPosition = new Vector3(0, 0, 0);
        BoxCollider2D box = colliderBox.AddComponent<BoxCollider2D>();
        box.size = new Vector2(1f, 1f);
        colliderBox.AddComponent<Rigidbody>();

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.bodyType = RigidbodyType2D.Dynamic;

        col = gameObject.AddComponent<CircleCollider2D>();
        col.radius = 0.8f;
        col.isTrigger = true;
        col.includeLayers = LayerMask.NameToLayer("Player");

        sr = GetComponent<SpriteRenderer>();
        if (sr == null) sr = gameObject.AddComponent<SpriteRenderer>();

    }
    public void Start()
    {
        if (item == null)
        {
            DeterminePickUp();
        }
        WorkWithItem();
    }

    private void WorkWithItem()
    {
        sr.enabled = true;
        sr.sprite = item.Sprite();
    }
    private void DeterminePickUp()
    {
        switch (pickUp)
        {
            case PickUpType.Item:
                item = (IPickUp)Game.GetRandomCommonItem();
                break;
            case PickUpType.ActiveModule:
                item = (IPickUp)Game.GetRandomCommonActiveModule();
                break;
            case PickUpType.BodyPart:
                item = (IPickUp)Game.GetRandomCommonBodyPart();
                break;
        }

    }


}
