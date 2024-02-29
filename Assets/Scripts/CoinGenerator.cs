using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject theCoin;

    public GameObject referenceObject;

    public float coinLength;

    public ObjectPooler theObjectPooler;

    public float randomValue = 0.8f;

    public float timeOffset = 0.4f;

    private float startTime;

    private Vector3 previousCoinPosition;

    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        previousCoinPosition = referenceObject.transform.position;

        coinLength = theCoin.GetComponent<BoxCollider>().size.x + 10;

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeOffset)
        {
            if (Random.value < randomValue)
            {
                direction = mainDirection;
            }
            else
            {
                Vector3 temp = direction;

                direction = otherDirection;

                mainDirection = direction;

                otherDirection = temp;
            }

            startTime = Time.time;

            Vector3 spawnPos = previousCoinPosition + coinLength * direction;

            GameObject newCoin = theObjectPooler.GetPooledObject();

            newCoin.transform.position = spawnPos;

            previousCoinPosition = spawnPos;

            newCoin.transform.rotation = transform.rotation;

            newCoin.SetActive(true);
        }
    }
}
