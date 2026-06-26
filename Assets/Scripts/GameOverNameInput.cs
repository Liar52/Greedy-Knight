using UnityEngine;
using TMPro;

public class GameOverNameInput : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInputField;

    public void SaveAndContinue()
    {
        string playerName = nameInputField.text;

        if (string.IsNullOrEmpty(playerName))
            playerName = "Player"; // nombre por defecto si no escribió nada

        LeaderboardManager.SaveScore(playerName, MasterInfo.distanceRun);
    }
}