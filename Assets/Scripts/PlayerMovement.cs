using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    private bool turnLeft, turnRight;

    private void FixedUpdate() 
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    private void Update()
    {
        turnLeft = Input.GetKeyDown(KeyCode.Q);
        turnRight = Input.GetKeyDown(KeyCode.E);

        if (turnLeft)
        {
            transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
        }
        else if (turnRight)
        {
            transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
        }

        horizontalInput = Input.GetAxis("Horizontal");

        if(transform.position.y < -5)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Die()
    {
        alive = false;

        //Restart the game
        Invoke("Restart", 1);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
