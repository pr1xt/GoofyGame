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
        // Instantiate the bullet at the firePoint's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Apply force to the bullet to make it move
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}
