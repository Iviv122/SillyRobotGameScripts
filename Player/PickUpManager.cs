using TMPro;
using UnityEngine;

public class InteractManager
{
    public readonly EventList<IInteract> nearbyPickUps = new();
    readonly Transform playerTransform;
    readonly Inventory inventory;
    readonly BodyPartsManager bodyPartsManager;
    readonly ModuleManager moduleManager;
    readonly TextMeshProUGUI useLabel;
    readonly InfoWindow infoWindow;
    public InteractManager(Player player, InfoWindow infoWindow, TextMeshProUGUI UseLabel, Inventory inventory, BodyPartsManager bodyPartsManager, ModuleManager moduleManager)
    {
        this.inventory = inventory;
        this.bodyPartsManager = bodyPartsManager;
        this.moduleManager = moduleManager;
        this.playerTransform = player.transform;
        this.useLabel = UseLabel;
        this.infoWindow = infoWindow;

        player.Interact += TryUse;

        nearbyPickUps.OnAdd += UpdateUseLabel;
        nearbyPickUps.OnRemove += UpdateUseLabel;
    }
    public void TryUse()
    {
        // TODO: PickUp nearest
        Debug.Log("Interacts count: " + nearbyPickUps.Count);
        if (nearbyPickUps.Count > 0)
        {
            nearbyPickUps[0].Use(this);
        }

    }
    private void UpdateUseLabel()
    {
        useLabel.gameObject.SetActive(nearbyPickUps.Count > 0);
        if (nearbyPickUps.Count > 0)
        {

            updateLabelText(nearbyPickUps[0]);
            if (nearbyPickUps[0] is IInfo || nearbyPickUps[0] is PickUp)
            {
                infoWindow.gameObject.SetActive(true);
            }
        }
        else
        {
            infoWindow.gameObject.SetActive(false);
        }

    }
    public void PickUp(ISprite item)
    {
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
    private void updateLabelText(IInteract item)
    {
        if (item is PickUp pickUp)
        {
            switch (pickUp.item)
            {
                case Item i:
                    useLabel.SetText("Pick up");
                    infoWindow.InputText(i);
                    break;
                case ActiveModule i:
                    useLabel.SetText("Install");
                    infoWindow.InputText(i);
                    break;
                case BodyPart i:
                    useLabel.SetText("Install");
                    infoWindow.InputText(i);
                    break;
            }
        }
        else if (item is IBuy Seller)
        {
            useLabel.SetText("Buy");
            infoWindow.InputText(Seller);
        }
        else
        {
            useLabel.SetText("Use");
            if (item is IInfo)
            {
                infoWindow.InputText((IInfo)item);
            }
        }
    }


}