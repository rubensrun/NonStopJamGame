using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static float speed;
    public List<ObjectMover> activeObjectMovers = new List<ObjectMover>();
    public ObjectPool CarLeftPool;

    private void Start()
    {
        speed = 30f;
        Spawn();
    }

    public void LoseSpeed(float loss)
    {
        speed -= loss;
        for (int i = 0; i < activeObjectMovers.Count; ++i)
        {
            activeObjectMovers[i].SetSpeed();
        }
    }

    private void Spawn()
    {
        GameObject obj = CarLeftPool.GetFromPool();
        if (obj != null)
        {
            obj.transform.position = new Vector3(10, Random.Range(-4f, 4f), 0);
            obj.transform.rotation = Quaternion.identity;
            ObjectMover objM = obj.GetComponent<ObjectMover>();
            objM.SetSpeed();
            activeObjectMovers.Add(objM);
        }
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        Spawn();
    }
}
