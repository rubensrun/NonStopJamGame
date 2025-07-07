using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public GameManager gManage;
    public int poolSize = 10;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);

            ObjectMover objM = obj.GetComponent<ObjectMover>();

            if (objM != null)
            {
                objM.SetPool(this);
            }

            pool.Enqueue(obj);
        }
    }

    public GameObject GetFromPool()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return null;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        ObjectMover objM = obj.GetComponent<ObjectMover>();
        GameManager.activeObjectMovers.Remove(objM);
        pool.Enqueue(obj);
    }
}
