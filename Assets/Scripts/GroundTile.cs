using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public static GroundTile instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(coinPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        GameObject coin = GroundTile.instance.GetPooledObject();

        if (coin != null)
        {
            coin.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            coin.SetActive(true);
        }
        //int coinsToSpawn = 10;
        //for (int i = 0; i < coinsToSpawn; i++)
        //{
        //    GameObject temp = Instantiate(coinPrefab, transform);
        //    temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        //}
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}