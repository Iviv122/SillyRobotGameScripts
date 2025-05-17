using TMPro;
using UnityEngine;

public class InfoWindow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Title;
    [SerializeField] TextMeshProUGUI Description;

    void Start()
    {

    }
    public void InputText(IInfo info)
    {
        SetTitle(info.GetTitle());
        SetDescription(info.GetDescription());
    }
    void SetTitle(string title)
    {
        Title.text = title;
    }
    void SetDescription(string description)
    {
        Description.text = description;
    }
}
