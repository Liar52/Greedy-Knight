using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public static float finalDistance = 0f;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text finalDistanceText;
    [SerializeField] TMP_InputField nameInputField;

    [Header("Bono por monedas")]
    [SerializeField] int coinsPerBonus = 20;     
    [SerializeField] float bonusMeters = 10f;     

    private static GameOverManager instance;

    void Awake()
    {
        instance = this;
        isGameOver = false;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public static void TriggerGameOver()
{
    isGameOver = true;

    if (instance == null) return;

    int bonusGroups = MasterInfo.coinCount / instance.coinsPerBonus;
    float bonusDistance = bonusGroups * instance.bonusMeters;

    Debug.Log("coinCount: " + MasterInfo.coinCount + " | coinsPerBonus: " + instance.coinsPerBonus + " | bonusGroups: " + bonusGroups + " | bonusDistance: " + bonusDistance + " | distanceRun: " + MasterInfo.distanceRun);

    finalDistance = MasterInfo.distanceRun + bonusDistance;

    instance.gameOverPanel.SetActive(true);

    if (instance.finalDistanceText != null)
    {
        string text = "Distancia: " + Mathf.FloorToInt(finalDistance) + "m";

        if (bonusDistance > 0)
            text += " (+" + Mathf.FloorToInt(bonusDistance) + "m bono)";

        instance.finalDistanceText.text = text;
    }
}

    public void SaveScoreButton()
    {
        string playerName = nameInputField.text;

        if (string.IsNullOrEmpty(playerName))
            playerName = "Player";

        LeaderboardManager.SaveScore(playerName, finalDistance); 

        nameInputField.interactable = false;
    }

    public void RetryButton()
    {
        string currentLevel = SceneManager.GetActiveScene().name;

        MasterInfo.distanceRun = 0f;
        MasterInfo.coinCount = 0; 
        LoadToStage.sceneToLoad = currentLevel;
        SceneManager.LoadScene("Loading");
    }

    public void MainMenuButton()
    {
        MasterInfo.distanceRun = 0f;
        MasterInfo.coinCount = 0; 
        SceneManager.LoadScene("MainMenu");
    }
}