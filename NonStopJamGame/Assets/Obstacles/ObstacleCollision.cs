using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public float speedLoss;
    public ObjectMover objectMover;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.speed -= speedLoss;
        }
        objectMover.ReturnToPool();
    }
}
