using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    //For health bar
    public float health;
    public float maxHealth = 100f;
    public HealthBar healthbar;

    Vector2 movement;
    Vector2 mousePosition;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        healthbar.setHealth(health, maxHealth);

        if (health <= 0)
        {
            FindObjectOfType<GameManager>().endGame();
        }


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 direction = mousePosition - rb.position;

        float angle = (((Mathf.Atan2(direction.y, direction.x)) * 180) / Mathf.PI) - 90f; // This will calculate the angle of rotation for player
   
        rb.rotation = angle;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 5;
        }
    }
}
