using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedometerController : MonoBehaviour
{
    public Rigidbody carRigidbody;       
    public Slider speedometerSlider;    
    public TMP_Text speedTextTMP;        

    public float maxSpeed = 100f;        
    public float vibrationAmount = 1f;   

    void Update()
    {
        // speed math
        float speed = carRigidbody.linearVelocity.magnitude * 3.6f;

        // speed limit
        float clampedSpeed = Mathf.Clamp(speed, 0f, maxSpeed);

        // max speed vibration
        if (clampedSpeed >= maxSpeed)
        {
            float vibration = Random.Range(-vibrationAmount, vibrationAmount);
            clampedSpeed = maxSpeed + vibration;
            clampedSpeed = Mathf.Clamp(clampedSpeed, maxSpeed - 1f, maxSpeed); //  99 - 100
        }

        // Slider Update
        speedometerSlider.value = clampedSpeed;

        // TMP Text Update
        speedTextTMP.text = Mathf.RoundToInt(clampedSpeed).ToString() ;
    }
}
