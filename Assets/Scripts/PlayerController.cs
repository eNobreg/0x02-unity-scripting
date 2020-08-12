using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float speed = 10;
    float moveHorizontal;
    float moveVertical;
    private int score = 0;
    public int health = 5;
    void Start()
    {
        health = 5;
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis ("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        if (health == 0)
        {
            Debug.Log("Game Over!");
            health = 5;
            score = 0;
            SceneManager.LoadScene("maze");
        }
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(move * speed);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            Debug.Log($"Score: {score}");
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            health -= 1;
            Debug.Log($"Health: {health}");
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
}
