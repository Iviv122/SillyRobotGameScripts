using System;

public interface IBuy : IInfo
{
    public event Action OnBuy;
    public void Buy();


    public void BuySound()
    {
        throw new NotImplementedException();
    }
    public void DenySound()
    {
        throw new NotImplementedException();
    }

    public string GetTitle();
    public string GetDescription();
}
