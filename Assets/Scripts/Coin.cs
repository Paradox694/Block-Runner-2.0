using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            gameObject.SetActive(false);
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Add to the player's score
        GameManager.inst.IncrementScore();

        // Destroy this coin object
        gameObject.SetActive(false);
    }

    void Start()
    {
        // Test
    }

    // Update is called once per frame
    void Update()
    {
        // Test 2
    }
}
