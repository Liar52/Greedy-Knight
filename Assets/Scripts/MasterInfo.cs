using UnityEngine;
using TMPro;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0;
    public static float distanceRun = 0f;

    [SerializeField] TMP_Text coinCountText;
    [SerializeField] TMP_Text distanceRunText;

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

    public static void AddDistance(float amount)
    {
        distanceRun += amount;
        UpdateUI();
    }

    static void UpdateUI()
    {
        if (instance == null) return;

        if (instance.coinCountText != null)
            instance.coinCountText.text = "COINS : " + coinCount;

        if (instance.distanceRunText != null)
            instance.distanceRunText.text = "DISTANCE : " + Mathf.FloorToInt(distanceRun) + "m";
    }
}