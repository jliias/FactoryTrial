using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Enemy class for demoing GameObjectFactory

// delegate telling that enemy instance is done and can be put back to pool
public delegate void AllDone(GameObject GO);

public class Enemy : MonoBehaviour
{
    private Vector3 rotationVector;
    private new MeshRenderer renderer;
    private GameObject myParent;

    // Instance lifetime
    private float lifeTime;

    // DisableGO will be triggered when lifetime is met
    public static event AllDone DisableGO;

    // Start is called before the first frame update
    void Start()
    {
        // Let's set lifetime
        lifeTime = UnityEngine.Random.Range(10f, 20f);
        Invoke("DestroyMe", lifeTime);

        // Random rotation vector
        rotationVector = new Vector3(
            UnityEngine.Random.Range(-10f, 10f),
            UnityEngine.Random.Range(-10f, 10f),
            UnityEngine.Random.Range(-10f, 10f)
            );

        // Random color
        renderer = GetComponent<MeshRenderer>();
        Material material = renderer.material;
        material.color = new Color(
            UnityEngine.Random.Range(0.0f, 1.0f),
            UnityEngine.Random.Range(0.0f, 1.0f),
            UnityEngine.Random.Range(0.0f, 1.0f),
            UnityEngine.Random.Range(0.5f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate GameObject
        transform.Rotate(rotationVector * Time.deltaTime * 10f);
    }

    // This will tell EnemySpawner to put specific instance back to pool
    // to wait for re-use
    private void DestroyMe() {
        Debug.Log("removing: " + this.gameObject);
        DisableGO(this.gameObject);
    }
}
