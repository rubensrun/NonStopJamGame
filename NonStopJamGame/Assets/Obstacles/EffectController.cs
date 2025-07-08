using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour
{
    private EffectPool pool;
    public ParticleSystem effect;
    public float duration;
    
    public void SetPool(EffectPool p)
    {
        pool = p;
    }

    private void OnAwake()
    {
        effect.Play();
        StartCoroutine(Wait());
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

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(duration);
        ReturnToPool();
    }
}
