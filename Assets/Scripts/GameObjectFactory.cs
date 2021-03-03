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

    private int pointer;

    // Constructor
    public GameObjectFactory(int initPoolSize, int maxPoolSize, GameObject prefab)
    {
        this.initPoolSize = initPoolSize;
        this.maxPoolSize = maxPoolSize;
        this.prefab = prefab;
        this.objectPool = new List<GameObject>();
        pointer = -1;

        for (int i = 0; i < initPoolSize; i++)
        {
            AddInstanceToPool(prefab);
        }

        Debug.Log("OBJECT COUNT: " + objectPool.Count);
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
        Debug.Log("There are " + (objectPool.Count - 1) + " instances in Pool!");
        // Use Pop() method to get last instance
        return Pop(objectPool);
    }

    // Pop implementation
    public GameObject Pop(List<GameObject> myList)
    {
        // Check that list lenght is more than 1
        int length = objectPool.Count;
        if (length > 0)
        {
            // first assign the  last value to a seperate string 
            GameObject popObj = objectPool[objectPool.Count - 1];
            // then remove it from list
            myList.RemoveAt(myList.Count - 1);
            // Activate and return gameobject 
            popObj.SetActive(true);
            return popObj;
        }
        else {
            return null;
        }
    }

    // Put GameObject back to list (it is returned by spawner)
    public void ReturnInstance(GameObject returnedInstance) {
        if (returnedInstance != null)
        {
            // disable instance and put it back to list
            returnedInstance.SetActive(false);
            objectPool.Add(returnedInstance);
            Debug.Log("There are " + objectPool.Count + " instances in Pool!");
        }
    }
}