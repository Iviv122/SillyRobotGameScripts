using UnityEngine;
public class AreaShock : ActiveModule 
{
    public override ModuleType ModuleType => ModuleType.SecondAttack;
    GameObject auraVisual;
    SpriteRenderer sr;
    float radius = 5;
    float damage = 5;
    public override void OnPickUpThis(Player player)
    {
        auraVisual = new GameObject("DamageAuraVisual");
        auraVisual.transform.SetParent(player.transform);
        auraVisual.transform.localPosition = Vector3.zero;

        sr = auraVisual.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("AuraSprite");
        sr.color = new Color(0.537f, 0.812f, 0.941f,0.3f);
        sr.sortingOrder = -1;

        auraVisual.transform.localScale = new Vector3(radius*2f, radius*2f, 1f); // 2 * radius

        FadeObject.FullTransperent(sr);
    }

    override public void Use(Player player){

        FadeObject.FullNonTransperent(sr);
        player.StartCoroutine(FadeObject.FadeOutObject(sr,5));
        Collider2D[] cols = Physics2D.OverlapCircleAll(player.transform.position,5);
        foreach (Collider2D i in cols)
        {
            IDamageable a;
            if(i.gameObject.TryGetComponent<IDamageable>(out a)){
                a.Damage(damage);
            }    
        }
    }
}
