using UnityEngine;

public class IDropPickUp
{
    public void DropPickUp(ISprite item, Transform position)
    {
        GameObject obj = new GameObject();
        PickUp pickUp = obj.AddComponent<PickUp>();
        obj.transform.position = (Vector2)position.position + new Vector2(0, 0.2f);

        pickUp.item = item;

        pickUp.Start();
    }
}
