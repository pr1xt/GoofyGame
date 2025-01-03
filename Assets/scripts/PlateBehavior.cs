using System;
using UnityEngine;

public class PlateBehavior : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float speed = 1f;
    
    public float LeftBorder = -3f;
    private float bulletSpeed = 10f;
    public float RightBorder = 3f;
    Vector3 targetPosition = new Vector3(-3f,0.5f,6);
    
    void Update()
    {
        // Debug.Log(transform.position.x+" "+ LeftBorder);

        if (Mathf.Approximately(transform.position.x, LeftBorder))
        {
           targetPosition = new Vector3(RightBorder, transform.position.y, transform.position.z);
            Debug.Log("Left border touched");
        }
        else if (Mathf.Approximately(transform.position.x, RightBorder))
        {
            targetPosition = new Vector3(LeftBorder, transform.position.y, transform.position.z);
            Debug.Log("Right border touched");
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Connect");
        // Optional: Handle collision with enemies or objects
        if (other.CompareTag("bullet"))
        {
            float randomNumber = UnityEngine.Random.Range(-20f, 20f) / 10f;

            Vector3 firepoint = new Vector3(transform.position.x+randomNumber,transform.position.y+randomNumber,7);
    
            GameObject bullet = Instantiate(bulletPrefab, firepoint, transform.rotation);
            
            
            // Rigidbody rb = bullet.GetComponent<Rigidbody>();
            // if (rb != null)
            // {
            //     rb.linearVelocity = firePoint.forward * bulletSpeed;
            // }
        }
    }
}
