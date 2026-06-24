using UnityEngine;
using TMPro;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0;

    [SerializeField] TMP_Text coinCountText;

    private static MasterInfo instance;

    void Awake()
    {
        instance = this;
        UpdateUI();
    }

    public static void AddCoin()
    {
        coinCount += 1;
        UpdateUI();
    }

    static void UpdateUI()
    {
        if (instance != null && instance.coinCountText != null)
        {
            instance.coinCountText.text = "COINS : " + coinCount;
        }
    }
}