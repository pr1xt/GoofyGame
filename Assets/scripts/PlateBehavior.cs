using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehavior : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float speed = 1f;
    
    public float LeftBorder = -3f;
    private float bulletSpeed = 20f;
    public float RightBorder = 3f;
    private List<float> PositionsOfBullet = new List<float> {1, 0.7f, 0.5f, 0.3f, -1, -0.7f, -0.5f, -0.3f};

    Vector3 targetPosition = new Vector3(-3f,0.5f,6);
    
    void Update()
    {

        if (Mathf.Approximately(transform.position.x, LeftBorder))
        {
           targetPosition = new Vector3(RightBorder, transform.position.y, transform.position.z);
        }
        else if (Mathf.Approximately(transform.position.x, RightBorder))
        {
            targetPosition = new Vector3(LeftBorder, transform.position.y, transform.position.z);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        // Optional: Handle collision with enemies or objects
        if (other.CompareTag("bullet"))
        {
            float randomNumber = PositionsOfBullet[UnityEngine.Random.Range(0, PositionsOfBullet.Count)];

            Vector3 firepoint = new Vector3(transform.position.x+randomNumber,transform.position.y-1,7);
    
            GameObject bullet = Instantiate(bulletPrefab, firepoint,Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Set the velocity to move along the Z-axis (positive or negative)
                rb.linearVelocity = new Vector3(0, 0, bulletSpeed); // Change to (0, 0, bulletSpeed) if you want it to move in the positive Z direction
            }
            
            
        }
    }
}
