using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;

    public GameObject referenceObject;

    public float platformLength;

    public ObjectPooler theObjectPooler;

    public float randomValue = 0.8f;

    public float timeOffset = 0.4f;

    private float startTime;

    private Quaternion originalRotation;

    private Vector3 previousTilePosition;

    private Vector3 direction, mainDirection = new Vector3(1, 0, 0), leftDirection = new Vector3(0, 0, 1), rightDirection = new Vector3(0, 0, -1);

    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;

        platformLength = thePlatform.GetComponent<BoxCollider>().size.x;

        startTime = Time.time;

        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeOffset)
        {
            if (Random.value < randomValue)
            {
                direction = mainDirection;

                ResetRotation();

            }
            else if (Random.value > randomValue)
            {
                direction = leftDirection;

                thePlatform.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                direction = rightDirection;

                thePlatform.transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            startTime = Time.time;

            Vector3 spawnPos = previousTilePosition + platformLength * direction;

            thePlatform = theObjectPooler.GetPooledObject();

            thePlatform.transform.position = spawnPos;

            previousTilePosition = spawnPos;

            thePlatform.SetActive(true);
        }
    }

    public void ResetRotation()
    {
        thePlatform.transform.rotation = originalRotation;
    }
}
