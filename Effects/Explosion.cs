using UnityEngine;

public class Explosion  
{
    GameObject auraVisual;
    MonoBehaviour monoBehaviour;
    SpriteRenderer sr;
    float radius;
    public Explosion(float radius,MonoBehaviour gameObject){
        monoBehaviour = gameObject;
        this.radius = radius;

        auraVisual = new GameObject("DamageAuraVisual");
        auraVisual.transform.SetParent(gameObject.transform);
        auraVisual.transform.localPosition = Vector3.zero;

        sr = auraVisual.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("AuraSprite");
        sr.color = new Color(1,0,0,0.3f);
        sr.sortingOrder = -1;

        auraVisual.transform.localScale = new Vector3(radius*2f, radius*2f, 1f); // 2 * radius

        FadeObject.FullTransperent(sr);
    }
    public Explosion(float radius,MonoBehaviour gameObject,Color color){
        monoBehaviour =gameObject;
        this.radius = radius;
        
        auraVisual = new GameObject("DamageAuraVisual");
        auraVisual.transform.SetParent(gameObject.transform);
        auraVisual.transform.localPosition = Vector3.zero;

        sr = auraVisual.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("AuraSprite");
        sr.color = color;
        sr.sortingOrder = -1;

        auraVisual.transform.localScale = new Vector3(radius*2f, radius*2f, 1f); // 2 * radius

        FadeObject.FullTransperent(sr);
    }
    public void Explode(){
        FadeObject.FullNonTransperent(sr);
        monoBehaviour.StartCoroutine(FadeObject.FadeOutObject(sr,radius));
    }
}
