using UnityEngine;
using TMPro;

public class FlagUI : MonoBehaviour
{
    public TextMeshProUGUI flagText;

    public static FlagUI instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateFlagText(int flag)
    {
        flagText.text = "" + flag;
    }
}
