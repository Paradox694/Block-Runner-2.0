using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int randomValue = Random.Range(0, 4);

        // Pattern A
        if (randomValue == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (randomValue != 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        // Pattern B
        if (randomValue == 1)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (randomValue != 1)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }

        // Pattern C
        if (randomValue == 2)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (randomValue != 2)
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }

        // Pattern D
        if (randomValue == 3)
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (randomValue != 3)
        {
            transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
