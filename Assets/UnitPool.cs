using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class UnitPool : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] int initialPoolSize;
    private Stack<GameObject> pooledObjects = new Stack<GameObject>();

    private void Awake()
    {
        // Create pool
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject spawned = Instantiate(Prefab);
            spawned.gameObject.SetActive(false);
            pooledObjects.Push(spawned);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject obj = GetObject(Random.insideUnitSphere * 10);
                StartCoroutine(ReturnObjectAfterTime(obj));
            }

        }

        if (Input.GetKey(KeyCode.V))
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject obj = Instantiate(Prefab, Random.insideUnitSphere * 10, Quaternion.identity);
                Destroy(obj, 5);
            }
        }
    }

    WaitForSeconds wait5Seconds = new WaitForSeconds(5);

    IEnumerator ReturnObjectAfterTime(GameObject obj)
    {
        yield return wait5Seconds;
        ReturnObject(obj);
    }

    public GameObject GetObject(Vector3 position)
    {
        if (pooledObjects.TryPop(out GameObject obj))
        {
            obj.transform.position = position;
            obj.SetActive(true);
            return obj;
        }

        GameObject newObject = Instantiate(Prefab, position, Quaternion.identity);
        return newObject;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pooledObjects.Push(obj);
    }
}
