using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 20;
    [SerializeField] private int currentHealth = 20;
    [SerializeField] private float speed = 3;

    public int Health{
        set{
            currentHealth = value;
            if(currentHealth <= 0){
                Debug.Log("Player is Dead");
            }
        }
    }
    public float Speed{
        set{
            speed = value;
            if(speed < 0){
                speed = 1;
            }
        }
        get{
            return speed;
        }
    }
    public int MaxHealth{
        set{ 
            maxHealth = value;
        }
        get{ return maxHealth;}
    }
}
public enum PlayerStat{
    Health,
    Energy
}