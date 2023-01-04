using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform Player;
    public  Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float hitpoints;
    public float maxHitpoints = 10f;
    private Vector2 movement; 


    // Start is called before the first frame update
    void Start()
    {
        hitpoints = maxHitpoints;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        float angle = (((Mathf.Atan2(direction.y, direction.x)) * 180) / Mathf.PI);
        rb.rotation = angle;
        direction.Normalize();
        movement = direction; 
    }

    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void takeHit(float damage)
    {
        hitpoints -= damage;

        if (hitpoints <= 0)
        {
            Destroy(gameObject);
            Score.instance.addPoints();
        }
    }
}
