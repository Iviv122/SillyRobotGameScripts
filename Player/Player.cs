using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player: MonoBehaviour 
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    [SerializeField] BaseStats baseStats;
    [SerializeField] private Stats stats;
    [SerializeField] private Inventory inventory;
    [SerializeField] private BodyPartsManager bodyPartsManager;
    [SerializeField] private ModuleManager moduleManager;
    [SerializeField] private GameObject inventoryManager; // UI

    public event Action UpdateEvent;
    public Stats Stats 
    {
        get{
            return stats;
        }
    }
    public BaseStats BaseStats 
    {
        get{
            return baseStats;
        }
    }
    void Awake() {
        
        baseStats = new BaseStats(20,5,5);
        stats = new Stats(new StatsMediator(),baseStats);
        bodyPartsManager = new BodyPartsManager(this,stats,baseStats);
        moduleManager = new ModuleManager(this); 
       
        inventory = new(this,GetComponent<PlayerMovement>());  //ALARM PLAYERMOVEMNT COMPONENT!!!

        inventory.AddItem(new DamageAura());

        moduleManager.AddModule(new RocketLauncher());
        moduleManager.AddModule(new AreaShock());

        FillBodyParts(); 
    }
    void Update(){
    
        stats.Mediator.Update(Time.deltaTime);
        UpdateEvent?.Invoke();
    }

    public void FillBodyParts(){
        bodyPartsManager.AddBodyPart(new BodyPart(new BaseStats(1,0,1),BodyPartsType.Head));
        bodyPartsManager.AddBodyPart(new BodyPart(new BaseStats(1,0,1),BodyPartsType.Body));
        bodyPartsManager.AddBodyPart(new BodyPart(new BaseStats(1,0,1),BodyPartsType.Arms));
        bodyPartsManager.AddBodyPart(new BodyPart(new BaseStats(1,2,1),BodyPartsType.Legs));
        Debug.Log($"Health {Stats.Health}, Energy {Stats.Energy}, Speed {Stats.Speed}");
    }
    public void OnInventory(){
        Debug.Log("Invenory works");
        inventoryManager.SetActive(!inventoryManager.activeSelf); 
    }

    void OnAttack(){
        moduleManager.OnLeftMouse();
    }
    void OnAttack1(){
        moduleManager.OnRightMouse();
    }
}
