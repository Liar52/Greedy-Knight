using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused = false;

    [SerializeField] GameObject pausePanel;

    void Update()
    {
        // No permitir pausa si ya es game over
        if (GameOverManager.isGameOver) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pausePanel != null) pausePanel.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null) pausePanel.SetActive(false);
    }

    // Para el botón "Reiniciar" en el panel de pausa
    public void RestartGame()
    {
        Time.timeScale = 1f; // importante: resetear antes de cargar escena
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // Para el botón "Salir al menú" (ajusta el nombre de la escena)
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}