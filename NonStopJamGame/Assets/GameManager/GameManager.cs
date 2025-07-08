using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static float speed;
    public static float score;
    public float speedGain;
    public static List<ObjectMover> activeObjectMovers = new List<ObjectMover>();
    public ObjectPool carLeftPool;
    public ObjectPool carRightPool;
    public ObjectPool barrierPool;
    public ObjectPool scenePool;
    public ObjectPool cyclistPool;
    public ObjectPool verticarPool;
    public Vector3 spawnLane1;
    public Vector3 spawnLane2;
    public Vector3 pave1;
    public Vector3 pave2;
    public Vector3 pave3;
    public Vector3 pave4;
    public Vector3 cycleLane;
    public Vector3 central1;
    public Vector3 central2;
    public Vector3 topRoad;
    private float minSpeed = 10f;
   private float maxSpeed = 50f;

    public GameObject gameOver;

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
        for (int i = 0; i < activeObjectMovers.Count; i++)
        {
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
        GameObject obj;
        obj = scenePool.GetFromPool();
        if (obj != null)
        {
            obj.transform.position = new Vector3(24.45f, 0, 0);
            obj.transform.rotation = Quaternion.identity;
            ObjectMover objM = obj.GetComponent<ObjectMover>();
            objM.SetSpeed();
            activeObjectMovers.Add(objM);
        }
        int rand = Random.Range(0, 5);
        if (rand == 0)
        {
            Spawn(central1, barrierPool);
        }
        if (rand == 1)
        {
            Spawn(spawnLane1, carLeftPool);
        }
        else if (rand == 2)
        {
            Spawn(spawnLane1, carRightPool);
        }
        else if (rand == 3)
        {
            Spawn(spawnLane1, barrierPool);
        }
        rand = Random.Range(0, 5);
        if (rand == 0)
        {
            Spawn(central2, barrierPool);
        }
        if (rand == 1)
        {
            Spawn(spawnLane2, carLeftPool);
        }
        else if (rand == 2)
        {
            Spawn(spawnLane2, carRightPool);
        }
        else if (rand == 3)
        {
            Spawn(spawnLane2, barrierPool);
        }
        rand = Random.Range(0, 3);
        if (rand == 1)
        {
            Spawn(pave1, barrierPool);
        }
        rand = Random.Range(0, 3);
        if (rand == 1)
        {
            Spawn(pave2, barrierPool);
        }
        rand = Random.Range(0, 3);
        if (rand == 1)
        {
            Spawn(pave3, barrierPool);
        }
        rand = Random.Range(0, 3);
        if (rand == 1)
        {
            Spawn(pave4, barrierPool);
        }
        rand = Random.Range(0, 2);
        if (rand == 1)
        {
            Spawn(cycleLane, cyclistPool);
        }
        rand = Random.Range(0, 2);
        if (rand >= 1)
        {
            Spawn(topRoad, verticarPool);
        }
    }

    private void Update()
    {
        speed += Time.deltaTime * speedGain;
        if (speed < minSpeed)
        {
            gameOver.SetActive(true);
        }
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        maxSpeed += Time.deltaTime * speedGain * 0.8f;
        minSpeed += Time.deltaTime * speedGain * 0.8f;
        for (int i = 0; i < activeObjectMovers.Count; i++)
        {
            activeObjectMovers[i].SetSpeed();
        }
        score += speed * Time.deltaTime;
    }
}
