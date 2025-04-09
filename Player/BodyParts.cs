using System;
using UnityEngine;

public class BodyParts : MonoBehaviour
{
    void Awake(){
        stats = GetComponent<PlayerStats>();
    }
    [SerializeField] PlayerStats stats;

    public PlayerStats Stats{
        set{
            if(stats == null){
                stats = value;
            }else{
                Debug.LogError($"trying to override player stats in {gameObject.name}");
            }
        }
    }

    [SerializeField] BodyPart head;
    [SerializeField] BodyPart body;
    [SerializeField] BodyPart leftLeg;
    [SerializeField] BodyPart rightLeg;

    public void AddBodyPart(){
        throw new NotImplementedException();
    }
    private void SwapBodyPart(BodyPart part){
        throw new NotImplementedException();
    }      

    private void SwapHead(){

    }
    private void SwapBody(){

    }
    private void SwapLeftLeg(){

    }
    private void SwapRightLeg(){

    }
}
