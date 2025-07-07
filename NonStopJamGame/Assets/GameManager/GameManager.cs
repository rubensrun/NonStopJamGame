using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static float speed;
    public static List<ObjectMover> activeObjectMovers = new List<ObjectMover>();
    public ObjectPool CarLeftPool;
    public ObjectPool ScenePool;

    private void Start()
    {
        speed = 30f;
        Spawn();
        GameObject obj = ScenePool.GetFromPool();
        if (obj != null)
        {
            obj.transform.position = new Vector3(0, 0, 0);
            obj.transform.rotation = Quaternion.identity;
            ObjectMover objM = obj.GetComponent<ObjectMover>();
            objM.SetSpeed();
            activeObjectMovers.Add(objM);
        }
        GameObject obj2 = ScenePool.GetFromPool();
        if (obj2 != null)
        {
            obj2.transform.position = new Vector3(24.45f, 0, 0);
            obj2.transform.rotation = Quaternion.identity;
            ObjectMover objM2 = obj2.GetComponent<ObjectMover>();
            objM2.SetSpeed();
            activeObjectMovers.Add(objM2);
        }
    }

    public static void LoseSpeed(float loss)
    {
        speed -= loss;
        Debug.Log(activeObjectMovers.Count);
        for (int i = 0; i < activeObjectMovers.Count; i++)
        {
            Debug.Log("set speed");
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

    public void SpawnScene()
    {
        GameObject obj = ScenePool.GetFromPool();
        if (obj != null)
        {
            obj.transform.position = new Vector3(24.45f, 0, 0);
            obj.transform.rotation = Quaternion.identity;
            ObjectMover objM = obj.GetComponent<ObjectMover>();
            objM.SetSpeed();
            activeObjectMovers.Add(objM);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        Spawn();
    }
}
