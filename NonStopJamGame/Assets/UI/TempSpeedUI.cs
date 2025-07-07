using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TempSpeedUI : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public Slider speedometer;

    void Update()
    {
        speedText.text = Mathf.CeilToInt(GameManager.speed).ToString();
        speedometer.value = GameManager.speed;
    }
}
