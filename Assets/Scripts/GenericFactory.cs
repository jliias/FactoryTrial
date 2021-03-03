using UnityEngine;
using System.Collections.Generic;

// Factory with generics
// This is under development, won't probably work yet as expected.

public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    // Can produce any type of instances
    private T prefab;

    // Initial size for pool
    private int initPoolSize;

    // maximun size for pool. Use 0 for unlimited pool size.
    private int maxPoolSize;

    // List for pool
    private List<GameObject> objectPool;

    // Constructor
    public GenericFactory(int initPoolSize, int maxPoolSize, T prefab)
    {
        this.initPoolSize = initPoolSize;
        this.maxPoolSize = maxPoolSize;
        this.prefab = prefab;
        this.objectPool = new List<GameObject>();
        Debug.Log("PREFAB: " + this.prefab.name);
    }

    // Create new instance of prefab
    public T CreateNewInstance()
    {
        return Instantiate(this.prefab);
    }
}