using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();

        GameObject spawnedObject;
        for (int i = 0; i < amountToPool; i++)
        {
            spawnedObject = Instantiate(objectToPool);
            spawnedObject.SetActive(false);
            pooledObjects.Add(spawnedObject);
        }
    }

    public void RemovePooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject currentObject = pooledObjects[i];
            if (currentObject.activeInHierarchy)
            {
                currentObject.SetActive(false);
                MoveToEndOfList(currentObject, pooledObjects);
                break;
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject currentObject = pooledObjects[i];
            if (!currentObject.activeInHierarchy)
            {
                currentObject.SetActive(true);
                MoveToEndOfList(currentObject, pooledObjects);
                return currentObject;
            }
        }
        GameObject pooledObject = pooledObjects[0];
        pooledObject.SetActive(true);
        MoveToEndOfList(pooledObject, pooledObjects);
        return pooledObject;
    }

    private void MoveToEndOfList(GameObject gameObject, List<GameObject> list)
    {
        list.Remove(gameObject);
        list.Add(gameObject);
    }
}
