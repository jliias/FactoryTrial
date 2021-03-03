using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Reference to Enemy Factory
    private GameObjectFactory enemyFactory;

    // Reference to Enemy prefab
    [SerializeField] private GameObject enemyPrefab;

    // Spawn rate
    [SerializeField] private float spawnRatePerMinute = 30;

    // Current spawn count
    private int currentCount = 0;

    private void Awake()
    {
        Enemy.DisableGO += DestroyChild;
    }

    private void Start()
    {
        enemyFactory = new GameObjectFactory(10, 30, enemyPrefab);
    }

    private void Update()
    {
        var targetCount = Time.time * (spawnRatePerMinute / 60);
        while (targetCount > currentCount)
        {
            GameObject inst = enemyFactory.GetNewInstance();
            inst.transform.position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-5.0f, 5.0f), 0);
            currentCount++;
        }
    }

    public void DestroyChild(GameObject child)
    {

        enemyFactory.ReturnInstance(child);
    }
}