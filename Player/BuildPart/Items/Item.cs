abstract public class Item 
{

    abstract public Rarity RarityType(); 
    //Add other events

    virtual public void OnJump(Player player){
    
    }
    virtual public void OnUpdate(Player player,float DeltaTime){
        
    }
    virtual public void OnPickUpThis(Player player){

    }
    virtual public void OnItemPickUp(Player player){

    }
 
}
