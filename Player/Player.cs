using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour, IDisposable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    [SerializeField] BaseStats baseStats;
    [SerializeField] private Stats stats;
    [SerializeField] private LevelUpManager levelUpManager;
    [SerializeField] private StatsUpdater statsUpdater;
    [SerializeField] private Inventory inventory;
    [SerializeField] private BodyPartsManager bodyPartsManager;
    [SerializeField] private ModuleManager moduleManager;
    [SerializeField] private GameObject inventoryManager; // UI
    [SerializeField] private InteractManager interactManager;
    [SerializeField] private TextMeshProUGUI headLabel;
    [SerializeField] private PlayerMovement playerMovement;
    private MoonTokeCollector moonTokeCollector;
    private InfoWindow InfoWindow;
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
        get
        {
            return stats;
        }
    }
    public BaseStats BaseStats
    {
        get
        {
            return baseStats;
        }
    }
    public MoonTokeCollector MoonTokenCollector
    {
        get
        {
            return moonTokeCollector;
        }
    }
    public ModuleManager ModuleManager
    {
        get
        {
            return moduleManager;
        }
    }
    public PlayerMovement PlayerMovement
    {
        get
        {
            return playerMovement;
        }
    }
    public LevelUpManager LevelUpManager => levelUpManager;

    [Inject]
    void Construct(Camera cam, InfoWindow infoWindow)
    {
        this.cam = cam;
        this.InfoWindow = infoWindow;

    }
    void Awake()
    {
    }
    void Start()
    {
        if (baseStats == null)
        {
            baseStats = new BaseStats(100, 5, 5, 0, 3);
        }
        stats = new Stats(new StatsMediator(), baseStats);
        stats.Die += Die;

        statsUpdater = new(baseStats, stats);

        bodyPartsManager = new BodyPartsManager(this, stats, baseStats);
        moduleManager = new ModuleManager(this);
        playerMovement = GetComponent<PlayerMovement>();
        inventory = new(this, playerMovement);  //ALARM PLAYERMOVEMNT COMPONENT!!!

        interactManager = new InteractManager(this, InfoWindow, headLabel, inventory, bodyPartsManager, moduleManager);
        interactManager.PickUp(new FanOfScrap());

        levelUpManager = new(baseStats);

        moonTokeCollector = new();

        InjectStat injectStat = new();
        baseStats.Add(injectStat.getStats());

        InjectItems injectItems = new();
        GetComponent<SpriteRenderer>().sprite = injectItems.GetCurrentSprite();

        FillBodyParts();
        Warmup();

        Refresh();
    }
    void Die()
    {
        Debug.Log("I am dead =)");
    }
    public void DealDamage(float damage)
    {
        stats.DealDamage(damage);
    }
    public void DealDamageNoProc(float damage)
    {
        Stats.DealDamageNoProc(damage);
    }
    void Update()
    {

        stats.Mediator.Update(Time.deltaTime);
        statsUpdater.Update(Time.deltaTime);
        UpdateEvent?.Invoke();
    }
    public void Warmup()
    {
        interactManager.TryUse();
        Refresh();
    }
    public void Refresh()
    {
        stats.CurrentHealth = stats.Health;
        stats.CurrentEnergy = stats.Energy;
    }
    public void FillBodyParts()
    {
        interactManager.PickUp(new BodyPart(new BaseStats(1, 0, 1, 0, 0), BodyPartsType.Head));
        interactManager.PickUp(new BodyPart(new BaseStats(1, 0, 1, 0, 0), BodyPartsType.Body));
        interactManager.PickUp(new BodyPart(new BaseStats(1, 0, 1, 0, 0), BodyPartsType.Arms));
        interactManager.PickUp(new BodyPart(new BaseStats(1, 2, 1, 0, 0), BodyPartsType.Legs));
        Debug.Log($"Health {Stats.Health}, Energy {Stats.Energy}, Speed {Stats.Speed}");

        InjectItems injectItems = new();
        foreach (var item in injectItems.GetCurrentItemSet())
        {
            interactManager.PickUp(item);
        }

        interactManager.PickUp(new Pulsejump());
    }
    public void OnInventory()
    {
        Debug.Log("Invenory works");
        inventoryManager.SetActive(!inventoryManager.activeSelf);
    }

    void OnAttack()
    {
        Attack?.Invoke();
    }
    void OnAttack1()
    {
        Attack1?.Invoke();
    }
    [Scene]
    public string gameplayEntryPoint;
    [Inject] ZenjectSceneLoader _sceneLoader;

    public void OnRestart()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        _sceneLoader.LoadScene(gameplayEntryPoint, LoadSceneMode.Single);
    }

    void OnModule1()
    {
        Module1?.Invoke();
    }
    void OnModule2()
    {
        Module2?.Invoke();
    }
    void OnModule3()
    {
        Module3?.Invoke();
    }
    void OnModule4()
    {
        Module4?.Invoke();
    }
    void OnInteract()
    {
        Interact?.Invoke();
    }
    void OnUseConsumable()
    {
        UseConsumable?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<IInteract>(out IInteract interact))
        {
            Debug.Log($"I can interact with something");
            interactManager.nearbyPickUps.Add(interact);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<IInteract>(out IInteract interact))
        {
            Debug.Log($"I can`t interact with something");
            interactManager.nearbyPickUps.Remove(interact);
        }
    }
    private void OnDestroy()
    {
        Debug.LogError("PLAYER WAS DESTOYED AAA");
        Debug.Log("PLAYER WAS DESTOYED AAA");
        Debug.LogError(Environment.StackTrace);
        Dispose();
    }
    public void Dispose()
{
    // Unsubscribe from events
    if (stats != null)
        stats.Die -= Die;

    UpdateEvent = null;
    Attack = null;
    Attack1 = null;
    Module1 = null;
    Module2 = null;
    Module3 = null;
    Module4 = null;
    Interact = null;
    UseConsumable = null;

    // Dispose of IDisposable members if any
    (stats as IDisposable)?.Dispose();
    (inventory as IDisposable)?.Dispose();
    (bodyPartsManager as IDisposable)?.Dispose();
    (moduleManager as IDisposable)?.Dispose();
    (interactManager as IDisposable)?.Dispose();
    (moonTokeCollector as IDisposable)?.Dispose();
    (levelUpManager as IDisposable)?.Dispose();
    (statsUpdater as IDisposable)?.Dispose();

    // Optionally null references to help with garbage collection
    rb = null;
    cam = null;
    baseStats = null;
    stats = null;
    levelUpManager = null;
    statsUpdater = null;
    inventory = null;
    bodyPartsManager = null;
    moduleManager = null;
    inventoryManager = null;
    interactManager = null;
    headLabel = null;
    playerMovement = null;
    moonTokeCollector = null;
    InfoWindow = null;
}

}