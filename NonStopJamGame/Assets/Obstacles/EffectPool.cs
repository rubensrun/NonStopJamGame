using UnityEngine;
using System.Collections.Generic;

public class EffectPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;

    public Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);

            EffectController eCont = obj.GetComponent<EffectController>();

            if (eCont != null)
            {
                eCont.SetPool(this);
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
        pool.Enqueue(obj);
    }
}