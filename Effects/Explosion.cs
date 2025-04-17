using System.Security.Cryptography;
using UnityEngine;

public class Explosion  
{
    GameObject auraVisual;
    MonoBehaviour monoBehaviour;
    SpriteRenderer sr;
    float radius;
    float speed;
    public Explosion(float radius,float speed,MonoBehaviour gameObject){
        monoBehaviour = gameObject;
        this.radius = radius;
        this.speed = speed;

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
    public Explosion(float radius,float speed,MonoBehaviour gameObject,Color color){
        monoBehaviour =gameObject;
        this.radius = radius;
        this.speed = speed;

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
        Game.Instance.StartCoroutine(FadeObject.FadeOutObject(sr,speed));
    }
    public void ExplodeAndDestroy(){
        FadeObject.FullNonTransperent(sr);
        
        sr.gameObject.transform.parent = null; 
        Game.Instance.StartCoroutine(FadeObject.FadeOutObjectDestroy(sr,speed));
    }
}
