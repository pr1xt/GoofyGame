using UnityEngine;

public class HeroShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab to shoot
    public Transform firePoint; // Point from where the bullet is spawned
    public float bulletSpeed = 10f; // Speed of the bullet
    public float shootInterval = 1.5f; // Time between shots
    private float shootTimer = 0f;

    void Update()
    {
        shootTimer += Time.deltaTime;

        // Check if it's time to shoot
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f; // Reset the timer
        }
    }

    void Shoot()
    {
        Vector3 firePoint = new Vector3(transform.position.x,transform.position.y,-2);
    
        // Instantiate the bullet at the firePoint's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint, Quaternion.identity);

        // Apply force to the bullet to make it move
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Set the velocity to move along the Z-axis (positive or negative)
            rb.linearVelocity = new Vector3(0, 0, bulletSpeed); // Change to (0, 0, bulletSpeed) if you want it to move in the positive Z direction
        }
    }
}
