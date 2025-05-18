using System;

public interface IBuy : IInfo
{
    public event Action OnBuy;
    public void Buy();

    public string GetTitle();
    public string GetDescription();
}
