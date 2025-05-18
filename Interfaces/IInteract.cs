using System;

public interface IInteract 
{
    public event Action OnUse;
    abstract public void Use(Object obj);

}
