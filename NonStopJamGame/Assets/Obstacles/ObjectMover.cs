using UnityEngine;
using System.Collections;


public class ObjectMover : MonoBehaviour
{
    public float speedModifier;
    public float vertSpeed;
    public Rigidbody2D rb;
    private ObjectPool pool;

    public void SetPool(ObjectPool p)
    {
        pool = p;
    }

    public void SetSpeed()
    {
        rb.linearVelocity = new Vector2(-Mathf.Sqrt(GameManager.speed) + speedModifier, vertSpeed * Mathf.Sqrt(GameManager.speed));
    }

    public void ReturnToPool()
    {
        if (pool != null)
        {
            pool.ReturnToPool(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
