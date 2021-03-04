using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    // Reference to Enemy Factory
    private GameObjectFactory enemyFactory;
    private IEnumerator coroutine;

    // Reference to Enemy prefab
    [SerializeField] private GameObject enemyPrefab;

    // Spawn rate
    [SerializeField] private float spawnRatePerMinute = 60f;
    [SerializeField] private int maxNumberOfEnemies = 20;

    // Current spawn count
    private int currentCount = 0;

    private void Awake()
    {
        Enemy.DisableGO += DestroyChild;
    }

    private void Start()
    {
        enemyFactory = new GameObjectFactory(10, 30, enemyPrefab);
        coroutine = SpawnNewObject(60 / spawnRatePerMinute);
        StartCoroutine(coroutine);
    }

    private IEnumerator SpawnNewObject(float waitTime)
    {
        while (true) 
        {
            yield return new WaitForSeconds(waitTime);
            if (currentCount < maxNumberOfEnemies)
            {
                GameObject inst = enemyFactory.GetNewInstance();
                inst.transform.position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-5.0f, 5.0f), 0);
                currentCount++;
            }
        }
    }

    public void DestroyChild(GameObject child)
    {
        enemyFactory.ReturnInstance(child);
        currentCount--;
    }
}