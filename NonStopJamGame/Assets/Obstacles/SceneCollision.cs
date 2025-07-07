using UnityEngine;

public class SceneCollision : MonoBehaviour
{
    public float speedLoss;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.LoseSpeed(speedLoss);
        }
    }
}
