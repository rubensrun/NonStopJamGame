using UnityEngine;

public class SceneController : MonoBehaviour
{
    public ObjectMover objectMover;
    public GameManager gameManager;

    private void Start()
    {
        GameObject obj = GameObject.Find("GameManager");
        if (obj != null)
        {
            gameManager = obj.GetComponent<GameManager>();
        }
    }

    private void Update()
    {
        if(gameObject.transform.position.x <= -24.45f)
        {
            gameManager.SpawnScene();
            objectMover.ReturnToPool();
        }
    }
}
