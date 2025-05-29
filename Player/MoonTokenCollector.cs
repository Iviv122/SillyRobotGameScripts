using UnityEngine;

public class MoonTokeCollector
{
    private const string TokenKey = "MoonTokens";

    private int tokens;
    public int Tokens => tokens;

    public MoonTokeCollector()
    {
        Load();
    }

    public void AddTokens(int amount)
    {
        tokens += amount;
        Save();
    }

    public bool SpendTokens(int amount)
    {
        if (tokens >= amount)
        {
           tokens -= amount;
            Save();
            return true;
        }
        return false;
    }

    public void Load()
    {
        tokens = PlayerPrefs.GetInt(TokenKey, 0);
    }

    public void Save()
    {
        PlayerPrefs.SetInt(TokenKey, tokens);
        PlayerPrefs.Save();
    }

    ~MoonTokeCollector()
    {
        Save();
    }
}
