using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TempSpeedUI : MonoBehaviour
{
    public TextMeshProUGUI speedText;

    void Update()
    {
        speedText.text = Mathf.CeilToInt(GameManager.speed).ToString();
    }
}
