using System.Collections;
using System.Collections.Generic;
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

    private Vector3 previousTilePosition;

    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;

        platformLength = thePlatform.GetComponent<BoxCollider>().size.x;

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

                thePlatform.transform.Rotate(0, -90, 0);
            }
            else
            {
                Vector3 temp = direction;

                direction = otherDirection;

                mainDirection = direction;

                otherDirection = temp;

                thePlatform.transform.Rotate(0, 90, 0);
            }

            startTime = Time.time;

            Vector3 spawnPos = previousTilePosition + platformLength * direction;

            //Quaternion rot1 = Quaternion.Euler(transform.forward);

            //Quaternion rot2 = Quaternion.Euler(transform.right);

            thePlatform = theObjectPooler.GetPooledObject();

            thePlatform.transform.position = spawnPos;

            previousTilePosition = spawnPos;

            //if (direction == mainDirection)
            //{
            //    thePlatform.transform.Rotate(0, -90, 0);
            //    thePlatform.transform.rotation = rot1;
            //}

            //if (direction != mainDirection)
            //{
            //    thePlatform.transform.Rotate(0, 90, 0);
            //    thePlatform.transform.rotation = rot2;
            //}

            thePlatform.SetActive(true);
        }
    }
}
