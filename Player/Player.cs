using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

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
    [SerializeField] private InteractManager interactManager;
    [SerializeField] private TextMeshProUGUI headLabel;

    public event Action UpdateEvent;
    public event Action Attack;
    public event Action Attack1;
    public event Action Module1;
    public event Action Module2;
    public event Action Module3;
    public event Action Module4;
    public event Action Interact;
    public event Action UseConsumable;
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
    [Inject]
    void Construct(Camera cam){
        this.cam =cam;
    }
    void Awake() {
        
        baseStats = new BaseStats(100,5,5);
        baseStats.Die += Die;
        stats = new Stats(new StatsMediator(),baseStats);
        bodyPartsManager = new BodyPartsManager(this,stats,baseStats);
        moduleManager = new ModuleManager(this); 
       
        inventory = new(this,GetComponent<PlayerMovement>());  //ALARM PLAYERMOVEMNT COMPONENT!!!

        interactManager = new InteractManager(this,headLabel,inventory,bodyPartsManager,moduleManager);

        interactManager.PickUp(new SimpleGun());

        FillBodyParts(); 
        Warmup();
    }
    void Start()
    {
        Warmup();
    }
    void Die(){
        Debug.Log("I am dead =)");
    }
    void Update(){
    
        stats.Mediator.Update(Time.deltaTime);
        UpdateEvent?.Invoke();
    }
    public void Warmup(){
        interactManager.TryUse();
        BaseStats.CurrentHealth = BaseStats.CurrentHealth;
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
        Attack?.Invoke();
    }
    void OnAttack1(){
        Attack1?.Invoke();
    }
    void OnRestart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
    }
    void OnModule1(){
        Module1?.Invoke();
    }
    void OnModule2(){
        Module2?.Invoke();
    }
    void OnModule3(){
        Module3?.Invoke();
    }
    void OnModule4(){
        Module4?.Invoke();
    }
    void OnInteract(){
        Interact?.Invoke();
    }
    void OnUseConsumable(){
        UseConsumable?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.TryGetComponent<IInteract>(out IInteract interact)){
            Debug.Log($"I can interact with something");
            interactManager.nearbyPickUps.Add(interact);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.TryGetComponent<IInteract>(out IInteract interact)){
            Debug.Log($"I can`t interact with something");
            interactManager.nearbyPickUps.Remove(interact);
        }
    }
}