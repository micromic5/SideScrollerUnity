using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceStairs : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField]
    private float distanceToPlayer = 3f;
    private List<GameObject> placedPrefabs = new List<GameObject>();

    void Start()
    {
    }



    void Update()
    {
        /* PERFORMANCE DEMO, EACH FRAME A STAIR IS SPAWNED
         * 
        if (!Input.GetButton("PlaceObject"))
        {
            Instantiate(prefab, transform.position + transform.forward * distanceToPlayer, Quaternion.identity);
        }*/

        /* INSTANTIACTE DEMO
         * 
        if (Input.GetButtonDown("PlaceObject"))
        {
            placedPrefabs.Add(Instantiate(prefab, transform.position + transform.forward * distanceToPlayer, Quaternion.identity));
        }*/

        /* DESTROY DEMO
         * 
        if (Input.GetButtonDown("DestroyObject") && placedPrefabs.Count != 0)
        {
            Destroy(placedPrefabs[placedPrefabs.Count - 1]);
            placedPrefabs.RemoveAt(placedPrefabs.Count - 1);
        }*/

        /*
         * OBJECT POOL DEMO
         */
        if (Input.GetButtonDown("PlaceObject"))
        {

            GameObject spawnedObject = ObjectPool.SharedInstance.pooledObjects.Get();
            spawnedObject.transform.position = transform.position + transform.forward * distanceToPlayer;
            spawnedObject.transform.rotation = Quaternion.identity;
            placedPrefabs.Add(spawnedObject);
            /* OBJECT POOL WITHOUT OBJECTPOOL<> CLASS
             * 
            GameObject objectToSpawn = ObjectPooling.SharedInstance.GetPooledObject();
            if (objectToSpawn != null)
            {
                objectToSpawn.transform.position = transform.position + transform.forward * distanceToPlayer;
                objectToSpawn.transform.rotation = Quaternion.identity;
                objectToSpawn.SetActive(true);
            }*/
        }
        if (Input.GetButtonDown("DestroyObject"))
        {
            if(placedPrefabs.Count > 0)
            {
                ObjectPool.SharedInstance.pooledObjects.Release(placedPrefabs[placedPrefabs.Count - 1]);
                placedPrefabs.RemoveAt(placedPrefabs.Count - 1);
            }

            /* OBJECT POOL WITHOUT OBJECTPOOL<> CLASS
             * 
             ObjectPooling.SharedInstance.RemovePooledObject();
            */
        }
    }
}
