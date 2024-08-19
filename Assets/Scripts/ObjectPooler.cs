using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public GameObject objectToPool;
    public int amountToPool = 10;

    private List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();

        if (objectToPool != null)
        {
            InitializePool();
        }

    }
    public void SetObjectToPool(GameObject obj)
    {
        objectToPool = obj;
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // Optionally, instantiate a new one if all objects are in use
        GameObject newObj = Instantiate(objectToPool);
        newObj.SetActive(false);
        pooledObjects.Add(newObj);
        return newObj;
    }

    public void ActivatePooledObject(Vector3 position, float duration, int power, Vector3 scale)
    {
        GameObject obj = GetPooledObject();
        if (obj != null)
        {
            obj.transform.position = position;
           
            obj.SetActive(true);
            StartCoroutine(DeactivateAfterTime(obj, duration));
        }
    }

    private IEnumerator<WaitForSeconds> DeactivateAfterTime(GameObject obj, float duration)
    {
        yield return new WaitForSeconds(duration);
        obj.SetActive(false);
    }
}
