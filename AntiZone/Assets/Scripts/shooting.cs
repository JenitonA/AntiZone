using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float canFire = 0.5f;
    public float fireRate = 0.5f;
    public float bulletForce = 20f;

     void Shoot()
    {
        FindObjectOfType<audioManager>().Play("LaserShot");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(0f, 0f, 90f);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
 
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > canFire)
        {
            Shoot();
            canFire = Time.time + fireRate;
        }
    }
}
