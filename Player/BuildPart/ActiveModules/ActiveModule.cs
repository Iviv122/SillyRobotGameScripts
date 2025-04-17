abstract public class ActiveModule
{
    abstract public ModuleType ModuleType {get;} 
    abstract public void OnPickUpThis(Player player);
    abstract public void Use(Player player);
}
