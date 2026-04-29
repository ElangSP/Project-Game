using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    public void TriggerGameOver()
    {
        Debug.Log("Game Over!");
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f; // hentikan waktu
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}