using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public ObjectPool<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public int maxPool = 5;
    // Collection checks will throw errors if we try to release an item that is already in the pool.
    public bool collectionChecks = false;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, amountToPool, maxPool);
    }
    
    private GameObject CreatePooledItem()
    {
        return Instantiate(objectToPool); 
    }

    void OnTakeFromPool(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    void OnReturnedToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    void OnDestroyPoolObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
