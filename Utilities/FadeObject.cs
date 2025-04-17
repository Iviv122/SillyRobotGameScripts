using System.Collections;
using UnityEngine;

public class FadeObject 
{
    public static IEnumerator FadeOutObject(SpriteRenderer spriteRenderer,float fadeSpeed){

        while (spriteRenderer.color.a > 0)
        {
            Color objectColor = spriteRenderer.color;
            float FadeAmount = objectColor.a - (fadeSpeed*Time.deltaTime);

            objectColor = new Color(objectColor.r,objectColor.g,objectColor.b,FadeAmount);
            spriteRenderer.color = objectColor;

            yield return null;
        }
    }
    public static IEnumerator FadeInObject(SpriteRenderer spriteRenderer,float fadeSpeed){

        while (spriteRenderer.color.a < 1)
        {
            Color objectColor = spriteRenderer.color;
            float FadeAmount = objectColor.a + (fadeSpeed*Time.deltaTime);

            objectColor = new Color(objectColor.r,objectColor.g,objectColor.b,FadeAmount);
            spriteRenderer.color = objectColor;

            yield return null;
        }
    }
    public static void FullTransperent(SpriteRenderer sprite){
        sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,0);
    }
    public static void FullNonTransperent(SpriteRenderer sprite){
        sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,1);
    }
}
