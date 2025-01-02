using UnityEngine;

public class HeroShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab to shoot
    public Transform firePoint; // Point from where the bullet is spawned
    public float bulletSpeed = 10f; // Speed of the bullet

    void Update()
    {
        // Check for Space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void OnMouseDown()
    {
        // Shoot when the hero object is clicked
        Shoot();
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
