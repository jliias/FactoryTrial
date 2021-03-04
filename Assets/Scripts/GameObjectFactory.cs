using UnityEngine;
using System.Collections.Generic;

// Factory for GameObjects.
// This is somehow working now.

/* TO-DO:
 * - implement variable pool size
 * - error handling in case if objectPool list length is 0
 * - more testing required
 */
public class GameObjectFactory
{
    // Can produce any type of instances
    private GameObject prefab;

    // Initial size for pool
    private int initPoolSize;

    // maximun size for pool. Use 0 for unlimited pool size.
    private int maxPoolSize;

    // List for pool
    private List<GameObject> objectPool;

    private int totalCount;

    // Constructor
    public GameObjectFactory(int initPoolSize, int maxPoolSize, GameObject prefab)
    {
        this.initPoolSize = initPoolSize;
        this.maxPoolSize = maxPoolSize;
        this.prefab = prefab;
        this.objectPool = new List<GameObject>();

        for (int i = 0; i < initPoolSize; i++)
        {
            AddInstanceToPool(prefab);
            totalCount++;
        }

        Debug.Log("OBJECT COUNT: " + totalCount);
    }

    // Instantiate GameObject instance from prefab, 
    // de-activate it and add to objectPool list
    private void AddInstanceToPool(GameObject addPrefab)
    {
        // Use Instantiate from Monodevelop
        GameObject newObj = (GameObject)GameObject.Instantiate(addPrefab);
        newObj.SetActive(false);
        objectPool.Add(newObj);
    }

    // Return last instance from the objectPool list
    public GameObject GetNewInstance()
    {
        // Use Pop() method to get last instance
        return Pop(objectPool);
    }

    // Pop implementation
    public GameObject Pop(List<GameObject> myList)
    {
        int length = objectPool.Count;
        // If list length is 1 (or less)
        // Add new instance to pool to avoid empty list situation
        if (length <= 1)
        {
            AddInstanceToPool(prefab);
            totalCount++;
        }
        // first assign the last object to a variable
        GameObject popObj = objectPool[objectPool.Count - 1];
        // then remove it from list
        myList.RemoveAt(myList.Count - 1);
        ReportPoolStatus();

        // Activate and return gameobject 
        popObj.SetActive(true);
        return popObj;
    }

    // Put GameObject back to list (it is returned by spawner)
    public void ReturnInstance(GameObject returnedInstance)
    {
        if (returnedInstance != null)
        {
            // disable instance and put it back to list
            returnedInstance.SetActive(false);
            objectPool.Add(returnedInstance);
            ReportPoolStatus();
        }
    }

    private void ReportPoolStatus()
    {
        Debug.Log("Pool depth: " + totalCount + " | " + " unused instances: " + objectPool.Count);
    }
}