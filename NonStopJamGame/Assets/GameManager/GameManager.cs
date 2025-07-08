using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static float speed;
    public float speedGain;
    public static List<ObjectMover> activeObjectMovers = new List<ObjectMover>();
    public ObjectPool carLeftPool;
    public ObjectPool carRightPool;
    public ObjectPool scenePool;
    public Vector3 spawnLane1;
    public Vector3 spawnLane2;

    private void Start()
    {
        speed = 30f;
        GameObject obj = scenePool.GetFromPool();
        if (obj != null)
        {
            obj.transform.position = new Vector3(0, 0, 0);
            obj.transform.rotation = Quaternion.identity;
            ObjectMover objM = obj.GetComponent<ObjectMover>();
            objM.SetSpeed();
            activeObjectMovers.Add(objM);
        }
        SpawnScene();
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

    private void Spawn(Vector3 location, ObjectPool targetPool)
    {
        GameObject obj = targetPool.GetFromPool();
        if (obj != null)
        {
            obj.transform.position = location;
            obj.transform.rotation = Quaternion.identity;
            ObjectMover objM = obj.GetComponent<ObjectMover>();
            objM.SetSpeed();
            activeObjectMovers.Add(objM);
        }
    }

    public void SpawnScene()
    {
        GameObject obj = scenePool.GetFromPool();
        if (obj != null)
        {
            obj.transform.position = new Vector3(24.45f, 0, 0);
            obj.transform.rotation = Quaternion.identity;
            ObjectMover objM = obj.GetComponent<ObjectMover>();
            objM.SetSpeed();
            activeObjectMovers.Add(objM);
        }
        int rand = Random.Range(0, 4);
        if (rand == 1)
        {
            Spawn(spawnLane1, carLeftPool);
        }
        else if (rand == 2)
        {
            Spawn(spawnLane1, carRightPool);
        }
        rand = Random.Range(0, 4);
        if (rand == 1)
        {
            Spawn(spawnLane2, carLeftPool);
        }
        else if (rand == 2)
        {
            Spawn(spawnLane2, carRightPool);
        }
    }

    private void Update()
    {
        speed += Time.deltaTime * speedGain;
        for (int i = 0; i < activeObjectMovers.Count; i++)
        {
            Debug.Log("set speed");
            activeObjectMovers[i].SetSpeed();
        }
    }
}
