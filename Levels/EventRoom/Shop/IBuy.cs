using System;

public interface IBuy
{
    public event Action OnBuy;
    public void Buy();
}
