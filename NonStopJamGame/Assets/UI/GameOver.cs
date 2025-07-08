using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public GameObject explosion;
    public TextMeshProUGUI finalScoreText;
    public GameObject scoreText;
    public GameObject speedo;

    private void OnEnable()
    {
        finalScoreText.text = "Final Score: " + Mathf.CeilToInt(GameManager.score).ToString();
        explosion.transform.position = player.transform.position;
        player.SetActive(false);
        explosion.SetActive(true);
        scoreText.SetActive(false);
        speedo.SetActive(false);
    }
}
