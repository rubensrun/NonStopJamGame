using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    public GameObject QuitButton;
    public GameObject RestartButton;



    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;

        if (AudioManager.Instance != null && AudioManager.Instance.gameOverSFX != null)
        {
            AudioManager.Instance.PauseMusic();
            AudioManager.Instance.PlaySFX(AudioManager.Instance.gameOverSFX);
        }
    }

    public void QuitGame()
    {
        Application.Quit();

    }
    public void Restart()
    {
        SceneManager.LoadScene("rorys scene");
        Time.timeScale = 1;
    }
}
