using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TempSpeedUI : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public Slider speedometer;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        speedText.text = Mathf.CeilToInt(GameManager.speed).ToString();
        scoreText.text = Mathf.CeilToInt(GameManager.score).ToString();
        speedometer.value = GameManager.speed;
    }
}
