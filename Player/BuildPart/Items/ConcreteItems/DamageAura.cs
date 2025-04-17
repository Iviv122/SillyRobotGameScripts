using UnityEngine;

public class DamageAura : Item 
{
    public override Rarity RarityType(){
        return Rarity.common;
    }

    private GameObject auraVisual;
    float radius = 1.5f;
    float damage = 0.02f;
    public override void OnPickUpThis(Player player)
    {
        auraVisual = new GameObject("DamageAuraVisual");
        auraVisual.transform.SetParent(player.transform);
        auraVisual.transform.localPosition = Vector3.zero;

        SpriteRenderer sr = auraVisual.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("AuraSprite");
        sr.color = new Color(1f, 0f, 0f, 0.3f);
        sr.sortingOrder = -1;

        auraVisual.transform.localScale = new Vector3(radius*2f, radius*2f, 1f); // 2 * radius
    } 
    public override void OnUpdate(Player player,float DeltaTime)
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(player.transform.position,radius);
        foreach (Collider2D i in cols)
        {
            if(i.gameObject.TryGetComponent(out IDamageable a)){
                a.Damage(damage);
            }    
        }
    }
}
