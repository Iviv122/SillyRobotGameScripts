using UnityEngine;

public class InteractManager 
{
    public readonly EventList<IInteract> nearbyPickUps =new();
    readonly Transform playerTransform;
    readonly Inventory inventory;
    readonly BodyPartsManager bodyPartsManager;
    readonly ModuleManager moduleManager;
    readonly GameObject useLabel;
    public InteractManager(Player player,GameObject UseLabel,Inventory inventory, BodyPartsManager bodyPartsManager, ModuleManager moduleManager){
        this.inventory = inventory;
        this.bodyPartsManager = bodyPartsManager;
        this.moduleManager = moduleManager;
        this.playerTransform = player.transform;
        this.useLabel = UseLabel;

        player.Interact += TryUse;

        nearbyPickUps.OnAdd += UpdateUseLabel;
        nearbyPickUps.OnRemove += UpdateUseLabel;
    }
    public void TryUse(){
        Debug.Log("Interacts count: " + nearbyPickUps.Count);
        if(nearbyPickUps.Count > 0){
            nearbyPickUps[0].Use(this);
        }

    }
    private void UpdateUseLabel(){
        useLabel.SetActive(nearbyPickUps.Count > 0);
    }    
    public void PickUp(IPickUp item){
        switch (item)
        {
            case Item i:
                inventory.AddItem(i);
            break;
            case ActiveModule i:
                moduleManager.AddModule(i);
            break;
            case BodyPart i:
                bodyPartsManager.AddBodyPart(i);
            break;
        }
    }
}
