using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSpawner : MonoBehaviour
{

    public Transform HP;
    private bool finished = false;
    

    void Start()
    {
        StartCoroutine(Counter(Random.Range(30.0f, 100.0f)));
    }

    void Update()
    {
        if (finished)
        {
            StopAllCoroutines();
            StartCoroutine(Counter(Random.Range(30.0f, 100.0f)));
            finished = false;
        }
    }

    public IEnumerator Counter(float t)
    {
        while (t > 0)
        {
            if (t < 1)
            {
                SpawnObject();
                finished = true;
            }

            t--;
            yield return new WaitForSeconds(1);
        }
    }

    void SpawnObject()
    {
        Instantiate(HP, new Vector2(Random.Range(-10.0f, 10.0f), 4), Quaternion.identity);
    }
}
